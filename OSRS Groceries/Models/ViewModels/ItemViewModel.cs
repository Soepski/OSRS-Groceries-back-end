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

        public ItemViewModel(string name, int RSID)
        {
            Name = name;
            this.RSID = RSID;
        }

        public ItemViewModel()
        {

        }
    }
}
