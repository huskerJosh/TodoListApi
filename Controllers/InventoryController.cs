using Microsoft.AspNetCore.Mvc;
using TodoList.Services;
using TodoList.Models;

namespace TodoList.Controllers
{
    [Route("v1")]
    [ApiController]
    public class InventoryController : ControllerBase
    {

        private IInventoryServices _service;

        [HttpPost]
        public ActionResult<InventoryItem> addItem(InventoryItem item)
        {
            _service.AddItem(item);

            if(item == null)
            {
                return NotFound(); 
            }

            return item;
        }

        [HttpGet]
        public ActionResult<InventoryItem> getItem(InventoryItem item)
        {
            _service.GetItem(item);

            if (item == null)
            {
                return NotFound();
            }

            return item;
        }
        
    }
}
