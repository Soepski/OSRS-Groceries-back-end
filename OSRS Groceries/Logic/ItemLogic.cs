using AutoMapper;
using Newtonsoft.Json;
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
            return itemViewModels;
        }

        public ItemViewModel GetItemById(int id)
        {
            ItemViewModel item = _mapper.Map<ItemViewModel>(_repo.GetItemById(id));
            return item;
        }

        public bool CreateItem(string name, int rsid)
        {
            return true;
        }
    }
}
