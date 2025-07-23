using System;
using StoreInventory.Data;
using StoreInventory.Models;

namespace StoreInventory.Mappings;

public static class ItemMappings
{

    public static ItemForViewing ToView(this Item item, StoreInventoryContext dbContext)
    {
        string itemType;
        //if item type is null, default to ingredient 
        if (item.ItemType == 0)
            itemType = "Ingredient";
        else
            itemType = dbContext.ItemTypes.Find(item.ItemType)!.Type;
        ItemForViewing newItem = new()
        {
            Id = item.Id,
            Name = item.Name,
            Description = item.Description,
            Type = itemType,
            Price = item.Price,
            Amount = item.Amount
        };
        return newItem;
    }

    public static Item ToItem(this ItemForViewing itemForViewing, StoreInventoryContext context)
    {
        var itemType = context.ItemTypes.Where(type => type.Type == itemForViewing.Type).First<ItemType>();
        int itemTypeId = 1; //Item type by default is ingredient
        if (itemType is not null)
            itemTypeId = itemType.Id;

        Item item = new()
        {
            Id = itemForViewing.Id,
            Name = itemForViewing.Name,
            Description = itemForViewing.Description,
            ItemType = itemTypeId,
            Amount = itemForViewing.Amount,
            Price = itemForViewing.Price
        };

        return item;
    }
}
