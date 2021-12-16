using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OSRS_Groceries.Data;
using OSRS_Groceries.Logic;
using OSRS_Groceries.Models;
using OSRS_Groceries.Models.ViewModels;
using OSRS_Groceries.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace OSRS_Groceries.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private ItemLogic _logic;

        public ItemController(IItemRepo itemRepo, IMapper mapper)
        {
            _logic = new ItemLogic(itemRepo, mapper);
        }

        [HttpGet]
        [Route("all")]
        public IActionResult GetAllItems()
        {
            try
            {
                ICollection<ItemViewModel> items = _logic.GetItems();
                return Ok(items);
            }
            catch (Exception ex)
            {
                return this.Content(ex.Message);
            }
        }

        [HttpPost]
        [Route("create")]
        public IActionResult CreateItem([FromBody] ItemViewModel item)
        {
            try
            {
                ItemViewModel itemviewmodel = _logic.CreateItem(item.Name, item.RSID);
                return Ok(itemviewmodel);
            }
            catch (Exception ex)
            {
                return this.Content(ex.Message);
            }
        }


    }
}
