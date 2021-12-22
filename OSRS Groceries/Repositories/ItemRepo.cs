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

        public Item CreateItem(Item item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();
            return item;
        }

        public void DeleteItem(int id)
        {
            Item item = _context.Items.SingleOrDefault(i => i.ID == id);
            _context.Items.Remove(item);
            _context.SaveChanges();
        }

        public Item GetItemById(int id)
        {
            return _context.Items.Where(i => i.ID == id).FirstOrDefault();
        }

        public ICollection<Item> GetItems()
        {
            return _context.Items.ToList();
        }

        public Item UpdateItem(Item item)
        {
            Item updateitem = _context.Items.SingleOrDefault(i => i.ID == item.ID);
            updateitem.Name = item.Name;
            updateitem.RSID = item.RSID;
            _context.Items.Update(updateitem);
            _context.SaveChanges();
            return item;
        }
    }
}
