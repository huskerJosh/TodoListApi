﻿using Microsoft.EntityFrameworkCore;

namespace TodoList.Models
{
    public class TodoListApiContext : DbContext
    {
        public TodoListApiContext(DbContextOptions<TodoListApiContext> options) : base(options){}

        public DbSet<TodoItem> TodoItem { get; set; }
    }
}
