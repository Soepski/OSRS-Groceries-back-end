using OSRS_Groceries.Data;
using OSRS_Groceries.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OSRS_Groceries.Repositories
{
    public class ItemRepo : IItemRepo
    {
        private readonly ItemContext _context;
        public ItemRepo(ItemContext context)
        {
            _context = context;
        }

        public Item GetItemById(int id)
        {
            return _context.Item.Where(i => i.ID == id).FirstOrDefault();
        }

        public ICollection<Item> GetItems()
        {
            return _context.Item.ToList();
        }
    }
}
