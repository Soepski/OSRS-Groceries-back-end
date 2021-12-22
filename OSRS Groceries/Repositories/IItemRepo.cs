using OSRS_Groceries.Models;
using System.Collections.Generic;

namespace OSRS_Groceries.Repositories
{
    public interface IItemRepo
    {
        public ICollection<Item> GetItems();
        public Item GetItemById(int id);
        public Item CreateItem(Item item);
        public void DeleteItem(int id);
        public Item UpdateItem(Item item);
    }
}
