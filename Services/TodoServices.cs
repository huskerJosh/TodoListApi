using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using TodoList.Models;

namespace TodoList.Services
{
    public class TodoServices : ITodoServices
    {
        IConfiguration _config;

        public TodoServices(IConfiguration config)
        {
            _config = config;
        }


        public TodoItem AddItem(TodoItem item)
        {
            var optionBuilder = new DbContextOptionsBuilder<TodoListApiContext>();
            optionBuilder.UseNpgsql("Host=localhost;Database=TodoList.Dev;Username=mye223;Password=password");
            using (var context = new TodoListApiContext(optionBuilder.Options))
            {
                item.itemName = "Wash Car";
                item.description = "Wash dirt off Jeep";

                context.Entry(item).State = EntityState.Added;
                context.SaveChanges();
            }
            return item;
        }

        public TodoItem GetItem(TodoItem item)
        {
            throw new NotImplementedException();
        }
    }
}
