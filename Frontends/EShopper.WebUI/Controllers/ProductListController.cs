using Microsoft.AspNetCore.Mvc;

namespace EShopper.WebUI.Controllers
{
    public class ProductListController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ProductDetails()
        {
            return View();
        }
    }
}
