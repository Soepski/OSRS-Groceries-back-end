using Microsoft.EntityFrameworkCore;
using OSRS_Groceries.Data;
using OSRS_Groceries.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OSRS_Groceries.Repositories
{
    public class GroceriesRepo : IGroceriesRepo
    {
        private readonly DatabaseContext _context;

        public GroceriesRepo(DatabaseContext context)
        {
            _context = context;
        }

        public List<int> GetAllGroceries()
        {
            List<int> itemids = _context.Item_User
                .Select(i => i.ItemID)
                .ToList();

            return itemids;
        }

        public List<int> CreateGroceries(User user, List<Item> items)
        {
            List<Item_User> items_users = new List<Item_User>();

            foreach (Item item in items)
            {
                items_users.Add(new Item_User(user, item));
            }

            _context.Database.ExecuteSqlRaw($"DELETE FROM Item_User WHERE UserID = {user.id}");
            _context.Item_User.AddRange(items_users);
            _context.SaveChanges();
            return GetGroceriesById(user.id);

        }

        public List<int> GetGroceriesById(int id)
        {
            List<int> itemids = _context.Item_User
                        .Where(u => u.UserID == id)
                        .Select(u => u.ItemID)
                        .ToList();

            return itemids;

        }
    }

}
