using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreInventory.Models;

public class ItemForViewing
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string Type { get; set; }
    public float Price { get; set; }
    public int Amount { get; set; }
}