using System.Collections.Generic;
using TodoList.Models;

namespace TodoList.Services
{
    public interface ITodoServices
    {
       public TodoItem AddItem(TodoItem item)
        {
            throw new System.NotImplementedException();
        }

        public List<TodoItem> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public TodoItem GetItem(int item)
        {
            throw new System.NotImplementedException();
        }

        public TodoItem UpdateItem(TodoItem item)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteItem(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
 