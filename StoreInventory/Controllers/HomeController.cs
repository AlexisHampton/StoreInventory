using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using StoreInventory.Data;
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
        return View(allItems);
    }

    public IActionResult CreateAndEdit()
    {

        return View();
    }

    public IActionResult CreateEditExpenseForm(Item model)
    {
        //if no model, create one
        if (model.Id == 0)
            _context.Add(model);
        else
            _context.Items.Update(model);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }


    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
