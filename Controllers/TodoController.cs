using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using TodoList.Services;
using TodoList.Models;

namespace TodoList.Controllers
{
    [Route("v1")]
    [ApiController]
    public class TodoController : ControllerBase
    {

        public static IConfiguration _config;

        public TodoController(IConfiguration config)
        {
            _config = config;
        }

        private ITodoServices _service = new TodoServices(_config);

        [Route("AddItem")]
        [HttpPost]
        public ActionResult<TodoItem> addItem(TodoItem item)
        {
            _service.AddItem(item);

            if(item == null)
            {
                return NotFound(); 
            }

            return item;
        }

        [Route("GetItem")]
        [HttpGet]
        public ActionResult<TodoItem> getItem(TodoItem item)
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
