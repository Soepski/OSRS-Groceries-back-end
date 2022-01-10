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
    public class GroceriesLogic
    {
        private readonly string apiURL = "https://secure.runescape.com/m=itemdb_oldschool/api/catalogue/detail.json?item=";
        private readonly IGroceriesRepo _repo;
        private readonly IItemRepo _itemrepo;
        private readonly IMapper _mapper;

        public GroceriesLogic(IGroceriesRepo repo, IItemRepo itemrepo, IMapper mapper)
        {
            _repo = repo;
            _itemrepo = itemrepo;
            _mapper = mapper;
        }
        public ICollection<ItemViewModel> GetAllGroceries()
        {
            List<int> itemids = _repo.GetAllGroceries();

            ICollection<Item> items = new List<Item>();

            foreach (int i in itemids)
            {
                items.Add(_itemrepo.GetItemById(i));
            }

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

        public ICollection<ItemViewModel> GetGroceriesById(int id)
        {
            List<int> itemids = _repo.GetGroceriesById(id);

            ICollection<Item> items = new List<Item>();

            foreach (int i in itemids)
            {
                items.Add(_itemrepo.GetItemById(i));
            }

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

        public ICollection<ItemViewModel> CreateGroceries(UserItemsViewModel userItemsViewModel)
        {
            List<int> itemids = _mapper.Map<List<int>>(_repo.CreateGroceries(_mapper.Map<User>(userItemsViewModel.user), _mapper.Map<List<Item>>(userItemsViewModel.items)));

            ICollection<Item> items = new List<Item>();

            foreach (int i in itemids)
            {
                items.Add(_itemrepo.GetItemById(i));
            }

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
    }
}
