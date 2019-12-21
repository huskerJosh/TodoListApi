using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using TodoList.Models;

namespace TodoList.Services
{
    public class TodoServices : ITodoServices
    {
        IOptions<MySettingsModel> appSettings;

        public TodoServices(IOptions<MySettingsModel> app)
        {
            appSettings = app;
        }


        public TodoItem AddItem(TodoItem item)
        {
            var optionBuilder = new DbContextOptionsBuilder<TodoListApiContext>();
            optionBuilder.UseNpgsql(appSettings.Value.DbConnection);
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
