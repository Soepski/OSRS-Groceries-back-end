using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OSRS_Groceries.Models
{
    public class Grocerylist
    {
        public virtual User User { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}
