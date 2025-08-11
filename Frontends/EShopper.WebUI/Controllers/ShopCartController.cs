using Microsoft.AspNetCore.Mvc;

namespace EShopper.WebUI.Controllers
{
    public class ShopCartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
