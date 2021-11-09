using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OSRS_Groceries.Models
{
    public class Activity
    {
        public Activity(string name, int rank, int level)
        {
            Name = name;
            Rank = rank;
            Level = level;
        }

        public string Name { get; set; }
        public int Rank { get; set; }
        public int Level { get; set; }
    }
}
