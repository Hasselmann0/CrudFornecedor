using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CrudFornecedor.Models;

namespace CrudFornecedor.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
