using Microsoft.EntityFrameworkCore;

namespace TodoList.Models
{
    public class TodoListApiContext : DbContext
    {
        public TodoListApiContext(DbContextOptions<TodoListApiContext> options) : base(options){}

        public DbSet<InventoryItem> InventoryItem { get; set; }
    }
}
