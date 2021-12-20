using AutoMapper;
using OSRS_Groceries.Models;
using OSRS_Groceries.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OSRS_Groceries.Profiles
{
    public class ItemProfile : Profile
    {
        public ItemProfile()
        {
            CreateMap<Models.Item, ItemViewModel>().ReverseMap();
        }
    }
}
