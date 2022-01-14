using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OSRS_Groceries.Logic;
using OSRS_Groceries.Models;
using OSRS_Groceries.Repositories;
using OSRS_Groceries.Models.ViewModels;
using OSRS_Groceries.Tests.MockContexts;
using System.Collections.Generic;

namespace OSRS_Groceries.Tests
{
    [TestClass]
    public class GroceriesTests
    {
        private readonly GroceriesLogic _logic;
        private readonly ItemLogic _itemlogic;
        private readonly IMapper _mapper;
        private readonly ItemGEInfo itemGeInfo = new ItemGEInfo();

        public GroceriesTests()
        { 

            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Item, ItemViewModel>().ReverseMap();
            });

            _mapper = new Mapper(config);

            IGroceriesRepo groceriesRepo = new MockGroceriesContext();
            IItemRepo itemRepo = new MockItemsContext();

            _logic = new GroceriesLogic(groceriesRepo, itemRepo, _mapper);

            FillGeInfo();

        }
   

        [TestMethod]
        public void GetAllGroceries_Valid()
        {
            //Arrange

            //Act
            ICollection<ItemViewModel> itemViewModels = _logic.GetAllGroceries();

            //Assert
            Assert.IsNotNull(itemViewModels);
        }

        [TestMethod]
        public void GetAllGroceries_InValid()
        {
            //Arrange

            //Act
            List<ItemViewModel> itemViewModels = new List<ItemViewModel>();

            //Assert
            Assert.IsNotNull(itemViewModels);
        }

        [TestMethod]
        public void CreateGroceries_Valid()
        {
            //Arrange
            User user = new User(5, "Ron Liebregts");
            List<Item> items = new List<Item>();
            items.Add(new Item("helm", 5));
            items.Add(new Item("zwaard", 10));
            items.Add(new Item("schild", 15));

            UserItemsViewModel userItemsViewModel = new UserItemsViewModel();
            userItemsViewModel.user = user;
            userItemsViewModel.items = items;

            //Act
            ICollection<ItemViewModel> itemViewModels = _logic.CreateGroceries(userItemsViewModel);

            //Assert
            Assert.IsNotNull(itemViewModels);
        }
        


        private void FillGeInfo()
        {
            itemGeInfo.icon = "https://secure.runescape.com/m=itemdb_oldschool/1641812469448_obj_sprite.gif?id=11834";
            itemGeInfo.icon_large = "https://secure.runescape.com/m=itemdb_oldschool/1641812469448_obj_big.gif?id=11834";
            itemGeInfo.id = 11834;
            itemGeInfo.type = "Default";
            itemGeInfo.typeIcon = "https://www.runescape.com/img/categories/Default";
            itemGeInfo.name = "Bandos tassets";
            itemGeInfo.description = "A sturdy pair of tassets.";
            Current current = new Current();
            current.trend = "neutral";
            current.price = "19.6m";
            itemGeInfo.current = current;
            Today today = new Today();
            today.trend = "neutral";
            today.price = "0";
            itemGeInfo.today = today;
            itemGeInfo.members = "true";
            Day30 day30 = new Day30();
            day30.trend = "negative";
            day30.change = "-29.0%";
            Day90 day90 = new Day90();
            day30.trend = "negative";
            day30.change = "-1.0%";
            Day180 day180 = new Day180();
            day30.trend = "negative";
            day30.change = "-12.0%";
        }
    }
}
