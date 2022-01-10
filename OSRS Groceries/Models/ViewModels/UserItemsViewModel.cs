using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OSRS_Groceries.Models.ViewModels
{
    public class UserItemsViewModel
    {
        public User user { get; set; }
        public ICollection<Item> items { get; set; }
    }
}
