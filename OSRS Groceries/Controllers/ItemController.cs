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
                return this.Content(ex.Message + " while getting items");
            }
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<ItemViewModel>> CreateItem([FromBody] ItemViewModel item)
        {
            try
            {
                ItemViewModel itemviewmodel = _logic.CreateItem(item);
                return CreatedAtAction("CreateItem", item);
            }
            catch (Exception ex)
            {
                return this.Content(ex.Message + " while creating item");
            }
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<ActionResult<ItemViewModel>> DeleteItem(int id)
        {
            try
            {
                _logic.DeleteItem(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return this.Content(ex.Message + " while deleting item");
            }
            
        }

        [HttpPut]
        [Route("update")]
        public async Task<ActionResult<ItemViewModel>> UpdateItem([FromBody] ItemViewModel item)
        {
            try
            {
                if (item.RSID != 0 && item.Name != null)
                {
                    _logic.UpdateItem(item);
                }
                return Ok(_logic.GetItems());
            }
            catch (Exception ex)
            {
                return this.Content(ex.Message + " while updating item");
            }

            
        }

    }
}
