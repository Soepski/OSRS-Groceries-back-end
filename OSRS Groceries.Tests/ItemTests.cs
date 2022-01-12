using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OSRS_Groceries.Logic;
using OSRS_Groceries.Models;
using OSRS_Groceries.Repositories;
using OSRS_Groceries.Models.ViewModels;
using OSRS_Groceries.Tests.MockContexts;

namespace OSRS_Groceries.Tests
{
    [TestClass]
    public class ItemTests
    {
        private readonly ItemLogic _logic;
        private readonly IMapper _mapper;
        private readonly ItemGEInfo itemGeInfo = new ItemGEInfo();

        public ItemTests()
        { 

            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Item, ItemViewModel>().ReverseMap();
            });

            _mapper = new Mapper(config);

            IItemRepo itemRepo = new MockItemContext();

            _logic = new ItemLogic(itemRepo, _mapper);

            FillGeInfo();

        }

        [TestMethod]
        public void NewItem_Valid()
        {
            //Arrange
            ItemViewModel item = new ItemViewModel(1, "Twisted bow", 20997, itemGeInfo);

            //Act
            ItemViewModel itemViewModel = _logic.CreateItem(item);

            //Assert
            Assert.AreEqual(item.Name, itemViewModel.Name);
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
