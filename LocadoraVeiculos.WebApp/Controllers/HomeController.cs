
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LocadoraVeiculos.WebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
