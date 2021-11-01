using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OSRS_Groceries.Models
{
    public class User
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
