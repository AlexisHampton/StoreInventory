using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using StoreInventory.Data;
using StoreInventory.Mappings;
using StoreInventory.Models;

namespace StoreInventory.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly StoreInventoryContext _context;

    public HomeController(ILogger<HomeController> logger, StoreInventoryContext context)
    {
        _logger = logger;
        _context = context;
    }

    //Get all store inventory data
    public IActionResult Index()
    {
        var allItems = _context.Items.ToList();
        List<ItemForViewing> itemForViewings = new();
        foreach (var item in allItems)
            itemForViewings.Add(item.ToView(_context));
        return View(itemForViewings);
    }

    public IActionResult CreateAndEdit(int? id)
    {
        var allTypes = _context.ItemTypes.ToList().Select(type => type.Type);
        ViewBag.AllTypes = allTypes;

        //If editing an exisitng item
        if (id is not null)
        {
            var item = _context.Items.Find(id);
            return View(item!.ToView(_context));
        }
        return View();
    }

    public IActionResult CreateEditExpenseForm(ItemForViewing model)
    {
        Item item = model.ToItem(_context);
        //if no model, create one
        if (model.Id == 0)
            _context.Add(item);
        else
            _context.Items.Update(item);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Delete(int? id)
    {
        var item = _context.Items.Find(id);
        if (item is not null)
        {
            _context.Remove(item);
            _context.SaveChanges();
        }

        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
