using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OSRS_Groceries.Models.ViewModels
{
    public class ItemViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int RSID { get; set; }
        public ItemGEInfo geinfo { get; set; }
       

        public ItemViewModel()
        {

        }

        public ItemViewModel(int iD, string name, int rSID, ItemGEInfo itemGEInfo)
        {
            ID = iD;
            Name = name;
            RSID = rSID;
            this.geinfo = itemGEInfo;
        }
    }
}
