using AutoMapper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OSRS_Groceries.Models;
using OSRS_Groceries.Models.ViewModels;
using OSRS_Groceries.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace OSRS_Groceries.Logic
{
    public class ItemLogic
    {
        private readonly string apiURL = "https://secure.runescape.com/m=itemdb_oldschool/api/catalogue/detail.json?item=";
        private readonly IItemRepo _repo;
        private readonly IMapper _mapper;

        public ItemLogic(IItemRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public ICollection<ItemViewModel> GetItems()
        {
            
            ICollection<Item> items = _repo.GetItems().ToList();
            ICollection<ItemViewModel> itemViewModels = _mapper.Map<ICollection<ItemViewModel>>(items);

            foreach (ItemViewModel itemViewModel in itemViewModels)
            {              
                string json = new WebClient().DownloadString(apiURL + itemViewModel.RSID);
                var item = JObject.Parse(json).SelectToken("item").ToString();
                ItemGEInfo itemgeinfo = JsonConvert.DeserializeObject<ItemGEInfo>(item);
                itemViewModel.geinfo = itemgeinfo;
            }

            return itemViewModels;
        }

        public ICollection<ItemViewModel> GetItemsTest()
        {
            
            ICollection<Item> items = _repo.GetItems().ToList();
            ICollection<ItemViewModel> itemViewModels = _mapper.Map<ICollection<ItemViewModel>>(items);

            return itemViewModels;
        }


        public ItemViewModel GetItemById(int id)
        {
            ItemViewModel item = _mapper.Map<ItemViewModel>(_repo.GetItemById(id));
            return item;
        }

        public ItemViewModel CreateItem(ItemViewModel item)
        {
            return _mapper.Map<ItemViewModel>(_repo.CreateItem(_mapper.Map<Item>(item)));
        }

        public void DeleteItem(int id)
        {
            _repo.DeleteItem(id);
        }

        public ItemViewModel UpdateItem(ItemViewModel item)
        {
            return _mapper.Map<ItemViewModel>(_repo.UpdateItem(_mapper.Map<Item>(item)));
        }
    }
}
