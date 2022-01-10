using OSRS_Groceries.Models;
using OSRS_Groceries.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OSRS_Groceries.Repositories
{
    public interface IGroceriesRepo
    {
        public List<int> GetAllGroceries();
        public List<int> GetGroceriesById(int id);
        public List<int> CreateGroceries(User user, List<Item> items);
    }
}
