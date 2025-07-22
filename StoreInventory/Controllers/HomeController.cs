using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using StoreInventory.Models;

namespace StoreInventory.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    //Get all store inventory data
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult CreateAndEdit()
    {
        return View();
    }

    public IActionResult CreateEditExpenseForm(Item model)
    {
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
