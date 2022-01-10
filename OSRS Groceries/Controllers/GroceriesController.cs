using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OSRS_Groceries.Logic;
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
    public class GroceriesController : ControllerBase
    {
        private GroceriesLogic _logic;

        public GroceriesController(IGroceriesRepo groceriesRepo, IItemRepo itemRepo, IMapper mapper)
        {
            _logic = new GroceriesLogic(groceriesRepo, itemRepo, mapper);
        }

        [HttpGet]
        [Route("all")]
        public IActionResult GetAllGroceries()
        {
            try

            {
                ICollection<ItemViewModel> items = _logic.GetAllGroceries();
                return Ok(items);
            }
            catch (Exception ex)
            {
                return this.Content(ex.Message + " while getting groceries");
            }
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<List<ItemViewModel>>> CreateGroceries([FromBody] UserItemsViewModel userItemsViewModel)
        {
            try
            {
                ICollection<ItemViewModel> itemViewModels = _logic.CreateGroceries(userItemsViewModel);
                return Ok(itemViewModels);
            }
            catch (Exception ex)
            {
                return this.Content(ex.Message + " while creating groceries");
            }
        }

        [HttpGet]
        [Route("get/{id}")]
        public async Task<ActionResult<List<ItemViewModel>>> GetGroceriesById(int id)
        {
            try
            {
                ICollection<ItemViewModel> itemViewModels = _logic.GetGroceriesById(id);
                return Ok(itemViewModels);
            }
            catch (Exception ex)
            {
                return this.Content(ex.Message + " while getting groceries by id");
            }
        }
    }
}
