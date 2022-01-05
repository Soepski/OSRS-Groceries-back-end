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
        public ICollection<Item> GetGroceries(User user);
        public ICollection<Item> CreateGroceries(User user, List<Item> items);
    }
}
