using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OSRS_Groceries.Models
{
    public class Highscores
    {
        public Highscores(List<Skill> skills, List<Activity> activities)
        {
            Skills = skills;
            Activities = activities;
        }

        public List<Skill> Skills { get; set; }
        public List<Activity> Activities { get; set; }
    }
}
