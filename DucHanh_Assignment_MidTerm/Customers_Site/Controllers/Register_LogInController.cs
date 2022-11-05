using Microsoft.AspNetCore.Mvc;

namespace Customers_Site.Controllers
{
    public class Register_LogInController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult LogIn()
        {
            return View();
        }
    }
}
