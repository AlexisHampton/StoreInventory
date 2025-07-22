namespace StoreInventory.Models;

public class Item
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public int ItemType { get; set; }
    public float Price { get; set; }
    public int Amount { get; set; }
}