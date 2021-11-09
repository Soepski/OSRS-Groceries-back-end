using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OSRS_Groceries.Models
{
    public class UserItem
    {
        [Key]
        public int ID { get; set; }
        public virtual User User { get; set; }
        public virtual Item Item { get; set; }
    }
}
