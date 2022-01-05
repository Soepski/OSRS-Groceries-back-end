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

        public GroceriesController(IGroceriesRepo groceriesRepo, IMapper mapper)
        {
            _logic = new GroceriesLogic(groceriesRepo, mapper);
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<List<ItemViewModel>>> CreateGroceries([FromBody] UserItemsViewModel userItemsViewModel)
        {
            try
            {
                List<ItemViewModel> itemViewModels = _logic.CreateGroceries(userItemsViewModel);
                return CreatedAtAction("CreateGroceries", userItemsViewModel.items);
            }
            catch (Exception ex)
            {
                return this.Content(ex.Message + " while creating item");
            }
        }
    }
}
