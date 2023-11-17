using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvc_web_app.Data;
using mvc_web_app.Models;

namespace mvc_web_app.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    DbTest01Context DB = new DbTest01Context();

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
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

    public IActionResult TableEMP()
    {
        List<UserInfo> data = DB.UserInfos.ToList();

        var data1 = from em in DB.UserInfos select em;
        var data2 = DB.UserInfos
            .Where(a => a.Name != null)
            .OrderByDescending(a => a.Name)
            .Take(2)
            .ToList();
        String sql = "";
        var data3 = DB.UserInfos.FromSqlRaw(sql);

        return View(data);
    }

    [HttpPost]
    public IActionResult TableEMP(string model)
    {
        string message = "";

        if (ModelState.IsValid)
        {
            message = "product " + model + " created successfully";
        }
        else
        {
            message = "Failed to create the product. Please try again";
        }
        return Content(message);
    }
}
