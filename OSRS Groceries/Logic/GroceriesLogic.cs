using AutoMapper;
using OSRS_Groceries.Models;
using OSRS_Groceries.Models.ViewModels;
using OSRS_Groceries.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OSRS_Groceries.Logic
{
    public class GroceriesLogic
    {
        private readonly IGroceriesRepo _repo;
        private readonly IMapper _mapper;

        public GroceriesLogic(IGroceriesRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public List<ItemViewModel> GetGroceriesById(User user)
        {
            return _mapper.Map<List<ItemViewModel>>(_repo.GetGroceries(user));
        }

        public List<ItemViewModel> CreateGroceries(UserItemsViewModel userItemsViewModel)
        {
            return _mapper.Map<List<ItemViewModel>>(_repo.CreateGroceries(_mapper.Map<User>(userItemsViewModel.user), _mapper.Map<List<Item>>(userItemsViewModel.items)));
        }
    }
}
