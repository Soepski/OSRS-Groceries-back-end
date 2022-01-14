using OSRS_Groceries.Models;
using OSRS_Groceries.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace OSRS_Groceries.Tests.MockContexts
{
    class MockGroceriesContext : IGroceriesRepo
    {
        private List<Item> items = new List<Item>();

        public MockGroceriesContext()
        {
            FillItems();
        }

        public List<int> CreateGroceries(User user, List<Item> items)
        {
            return GetItemIds(items);
        }

        public List<int> GetAllGroceries()
        {
            return GetItemIds(items);
        }

        public List<int> GetGroceriesById(int id)
        {
            throw new NotImplementedException();
        }

        private void FillItems()
        {
            int[] itemids = new int[] { 11832, 22324, 11834, 13239, 13576 };

            for (int i = 0; i < 5; i++)
            {
                items.Add(new Item { ID = i, Name = "Title" + i, RSID = itemids[i] });
            }
        }

        public List<int> GetItemIds(List<Item> items)
        {
            List<int> itemids = new List<int>();

            foreach (Item item in items)
            {
                itemids.Add(item.ID);
            }

            return itemids;
        }
    }
}
