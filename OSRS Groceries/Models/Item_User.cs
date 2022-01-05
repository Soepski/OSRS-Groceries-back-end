using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OSRS_Groceries.Models
{
    public class Item_User
    {
        public Item_User(User user, Item item)
        {
            User = user;
            Item = item;
        }


        public int ID { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
        public int ItemID { get; set; }
        public Item Item { get; set; }
    }
}
