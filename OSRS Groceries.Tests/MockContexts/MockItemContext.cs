using OSRS_Groceries.Models;
using OSRS_Groceries.Models.ViewModels;
using OSRS_Groceries.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace OSRS_Groceries.Tests.MockContexts
{
    class MockItemsContext : IItemRepo
    {
        private List<Item> items = new List<Item>();

        public MockItemsContext()
        {
            FakeItems();
        }

        public Item CreateItem(Item item)
        {
            return item;
        }

        public void DeleteItem(int id)
        {
            throw new NotImplementedException();
        }

        public Item GetItemById(int id)
        {
            return items[id];
        }

        public ICollection<Item> GetItems()
        {
            return items;
        }

        public Item UpdateItem(Item item)
        {
            Item itemnew = new Item();
            itemnew.Name = "Dragon warhammer";
            return itemnew;
        }

        private void FakeItems()
        {
            int[] itemids = new int[] { 11832, 22324, 11834, 13239, 13576 };

            for (int i = 0; i < 5; i++)
            {
                items.Add(new Item { ID = i, Name = "Title" + i, RSID = itemids[i] });
            }

        }

        
    }
}
