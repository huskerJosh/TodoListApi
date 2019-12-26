using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using TodoList.Services;
using TodoList.Models;
using System.Collections.Generic;

namespace TodoList.Controllers
{
    [Route("v1")]
    [ApiController]
    public class TodoController : ControllerBase
    {

        public static IConfiguration _config;

        public static IOptions<MySettingsModel> appSettings;

        public TodoController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
        }

        private ITodoServices _service = new TodoServices(appSettings);

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

        [Route("[controller]")]
        [HttpGet]
        public ActionResult<List<TodoItem>> getAll()
        {
            List<TodoItem> result = _service.GetAll();
            return result;
        }

        [Route("[controller]/{id}")]
        [HttpGet]
        public ActionResult<TodoItem> getItem(int id)
        {
            TodoItem result = _service.GetItem(id);

            if (result == null)
            {
                return NotFound();
            }

            return result;
        }

        [Route("[controller]")]
        [HttpPatch]
        public ActionResult<TodoItem> updateItem(TodoItem item)
        {
            return _service.UpdateItem(item);

        }

        [Route("[controller]/{id}")]
        [HttpDelete]
        public ActionResult<bool> deleteItem(int id)
        {
            return _service.DeleteItem(id);

        }
        
    }
}
