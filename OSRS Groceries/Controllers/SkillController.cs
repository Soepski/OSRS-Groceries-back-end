using Microsoft.AspNetCore.Mvc;
using OSRS_Groceries.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OSRS_Groceries.Controllers
{
    
    [Route("[controller]")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        readonly string[] skillnames = new string[] { "Overall", "Attack", "Defence", "Strength", "Hitpoints", "Ranged", "Prayer", "Magic", "Cooking", "Woodcutting", "Fletching", "Fishing", "Firemaking", "Crafting", "Smithing", "Mining", "Herblore", "Agility", "Thieving", "Slayer", "Farming", "Runecrafting", "Hunter", "Construction" };
        readonly string[] activitynames = new string[] { "League Points", "Bounty Hunter - Hunter", "Bounty Hunter - Rogue", "Clue Scrolls (all)", "Clue Scrolls (beginner)", "Clue Scrolls (easy)", "Clue Scrolls (medium)", "Clue Scrolls (hard)", "Clue Scrolls (elite)", "Clue Scrolls (master)", "LMS - Rank", "Soul Wars Zeal", "Abyssal Sire", "Alchemical Hydra", "Barrows Chests", "Bryophyta", "Callisto", "Cerberus", "Chambers of Xeric", "Chambers of Xeric: Challenge Mode", "Chaos Elemental", "Chaos Fanatic", "Commander Zilyana", "Corporeal Beast", "Crazy Archaeologist", "Dagannoth Prime", "Dagannoth Rex", "Dagannoth Supreme", "Deranged Archaeologist", "General Graardor", "Giant Mole", "Grotesque Guardians", "Hespori", "Kalphite Queen", "King Black Dragon", "Kraken", "Kree'Arra", "K'ril Tsutsaroth", "Mimic", "Nex", "Nightmare", "Phosani's Nightmare", "Obor", "Sarachnis", "Scorpia", "Skotizo", "Tempoross", "The Gauntlet", "The Corrupted Gauntlet", "Theatre of Blood", "Theatre of Blood: Hard Mode", "Thermonuclear Smoke Devil", "TzKal-Zuk", "TzTok-Jad", "Venenatis", "Vet'ion", "Vorkath", "Wintertodt", "Zalcano", "Zulrah" };


        // GET api/<SkillController>/{username}
        [HttpGet("{username}")]
        public Highscores Get(string username)
        {
            WebClient client = new WebClient();
            List<Skill> skills = new List<Skill>();
            List<Activity> activities = new List<Activity>();
            int skillcount = 0;
            int activitycount = 0;
            string downloadString;


            try
            {
                downloadString = client.DownloadString("https://secure.runescape.com/m=hiscore_oldschool/index_lite.ws?player=" + username);
            }
            catch (Exception ex)
            {

                throw new ArgumentException(ex.ToString());
            }
            

            string[] splits = downloadString.Split('\n');

            foreach (string split in splits)
            {
                string[] items = split.Split(',');

                if (items.Count() == 3)
                {

                    skills.Add(new Skill(skillnames[skillcount], int.Parse(items[0]), int.Parse(items[1]), int.Parse(items[2])));

                    skillcount++;
                }
                else if(items.Count() == 2)
                {
                    activities.Add(new Activity(activitynames[activitycount], int.Parse(items[0]), int.Parse(items[1])));

                    activitycount++;
                }
            }

            Highscores highscore = new Highscores(skills, activities);

            return highscore;
        }

        // POST api/<SkillController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
            throw new NotImplementedException();
        }

        // PUT api/<SkillController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            throw new NotImplementedException();
        }

        // DELETE api/<SkillController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
