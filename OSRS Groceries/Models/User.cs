using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OSRS_Groceries.Models
{
    public class User
    {
        public User()
        {

        }

        public User(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        [Key]
        public int id { get; set; }
        public string name { get; set; }
    }
}
