using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OSRS_Groceries.Models
{
    public class Item
    {
        public Item()
        {

        }

        public Item(int iD)
        {
            ID = iD;
        }

        public Item(string name, int rSID)
        {
            Name = name;
            RSID = rSID;
        }

        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public int RSID { get; set; }
        //public List<Item_User> Item_User { get; set; }
    }
}
