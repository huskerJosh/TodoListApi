using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
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
                context.Entry(item).State = EntityState.Added;
                context.SaveChanges();
            }
            return item;
        }

        public List<TodoItem> GetAll()
        {
            var optionBuilder = new DbContextOptionsBuilder<TodoListApiContext>();
            optionBuilder.UseNpgsql(appSettings.Value.DbConnection);
            var context = new TodoListApiContext(optionBuilder.Options);

            return context.TodoItem.ToList();
            
        }

        public TodoItem GetItem(int id)
        {
            var optionBuilder = new DbContextOptionsBuilder<TodoListApiContext>();
            optionBuilder.UseNpgsql(appSettings.Value.DbConnection);
            var context = new TodoListApiContext(optionBuilder.Options);

            return context.TodoItem.Single(item => item.Id == id);
        }

        public TodoItem UpdateItem(TodoItem item)
        {
            var optionBuilder = new DbContextOptionsBuilder<TodoListApiContext>();
            optionBuilder.UseNpgsql(appSettings.Value.DbConnection);
            var context = new TodoListApiContext(optionBuilder.Options);

            TodoItem result = context.TodoItem.SingleOrDefault(i => i.Id == item.Id);

            if(result ==null)
            {
                return null;
            }

            result.itemName = item.itemName;
            result.isActive = item.isActive;
            result.description = item.description;

            context.SaveChanges();

            return item;
        }

        public bool DeleteItem(int id)
        {
            var optionBuilder = new DbContextOptionsBuilder<TodoListApiContext>();
            optionBuilder.UseNpgsql(appSettings.Value.DbConnection);
            var context = new TodoListApiContext(optionBuilder.Options);

            context.TodoItem.Remove(context.TodoItem.Find(id));
            context.SaveChanges();

            TodoItem result = context.TodoItem.SingleOrDefault(i => i.Id == id);

            if (result == null)
            {
                return true;
            } else
            {
                return false;
            }
        }
    }
}
