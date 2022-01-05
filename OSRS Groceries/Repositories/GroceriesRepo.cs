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

        public ICollection<Item> CreateGroceries(User user, List<Item> items)
        {
            List<Item_User> iu = new List<Item_User>();
            foreach (Item item in items)
            {
                iu.Add(new Item_User(user, item));
            }

            _context.Items_Users.AddRange(iu);
            _context.SaveChanges();
            return items;
        }

        ICollection<Item> IGroceriesRepo.GetGroceries(User user)
        {
            throw new NotImplementedException();
        }
    }

}
