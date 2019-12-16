using System;
namespace TodoList.Models
{
    public class InventoryItem
    {
        public int Id { get; set; }
        public string itemName { get; set; }
        public double price {get; set;}

        public InventoryItem()
        {
        }
    }
}
