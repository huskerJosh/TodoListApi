using System;
namespace TodoList.Models
{
    public class TodoItem
    {

        public int Id { get; set; }
        public string itemName { get; set; }
        public string description { get; set; }
        public bool isActive { get; set; }

    }
}
