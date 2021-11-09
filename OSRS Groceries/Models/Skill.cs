using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OSRS_Groceries.Models
{
    public class Skill
    {
        public Skill(string name, int rank, int level, int experience)
        {
            Name = name;
            Rank = rank;
            Level = level;
            Experience = experience;
        }

        public string Name { get; set; }
        public int Rank { get; set; }
        public int Level { get; set; }
        public int Experience { get; set; }
    }
}
