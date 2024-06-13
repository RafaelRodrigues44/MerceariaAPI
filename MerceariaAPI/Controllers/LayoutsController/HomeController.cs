using Microsoft.AspNetCore.Mvc;

namespace MerceariaAPI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // Recupera as informações do TempData
            var token = HttpContext.Session.GetString("Token");
            var username = HttpContext.Session.GetString("Username");

            if (!string.IsNullOrEmpty(token) && !string.IsNullOrEmpty(username))
            {
                ViewData["User"] = username;
                ViewData["Token"] = token;
            }
            return View();
        }
    }
}
