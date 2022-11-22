using Microsoft.AspNetCore.Mvc;

namespace Software_Lanch.Controllers
{
    public class ContactoController : Controller
    {
        public IActionResult Index()
        {
            if(User.Identity.IsAuthenticated)
                return View();
            return RedirectToAction("Login", "Account");
        }
    }
}
