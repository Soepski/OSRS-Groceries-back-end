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
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        
    }
}
