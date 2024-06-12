using Microsoft.AspNetCore.Mvc;

namespace MerceariaAPI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // Recupera as informações do TempData
            var username = TempData["Username"]?.ToString();
            var token = TempData["Token"]?.ToString();

            // Passa as informações para a view através do ViewBag
            ViewBag.Username = username;
            ViewBag.Token = token;

            return View();
        }
    }
}
