﻿using OSRS_Groceries.Models;
using System.Collections.Generic;

namespace OSRS_Groceries.Repositories
{
    public interface IItemRepo
    {
        public ICollection<Item> GetItems();
        public Item GetItemById(int id);
    }
}
