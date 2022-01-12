using OSRS_Groceries.Models;
using OSRS_Groceries.Models.ViewModels;
using OSRS_Groceries.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace OSRS_Groceries.Tests.MockContexts
{
    class MockItemContext : IItemRepo
    {
        private List<Item> items = new List<Item>();

        public MockItemContext()
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
            throw new NotImplementedException();
        }

        private void FakeItems()
        {
            for (int i = 0; i < 5; i++)
            {
                items.Add(new Item { ID = i, Name = "Title" + i, RSID = 1000 + 1 });
            }

        }

        
    }
}
