using Microsoft.AspNetCore.Mvc;

namespace EShopper.WebUI.Controllers
{
    public class AuthLayoutController : Controller
    {
        public IActionResult _AuthLayout()
        {
            return View();
        }
    }
}
