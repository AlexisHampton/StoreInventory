using System;
using Microsoft.EntityFrameworkCore;
using StoreInventory.Models;

namespace StoreInventory.Data;

public class StoreInventoryContext : DbContext
{
    public DbSet<Item> Items { get; set; }
    public DbSet<ItemType> ItemTypes { get; set; }

    public StoreInventoryContext(DbContextOptions<StoreInventoryContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ItemType>().HasData(
            new { Id = 1, Type = "Ingredient" },
            new { Id = 2, Type = "Pastry" },
            new { Id = 3, Type = "Beverage" }
        );
    }
}
