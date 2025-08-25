using Microsoft.AspNetCore.Mvc;

namespace EShopper.WebUI.Controllers
{
    public class ProductListController : Controller
    {
        public IActionResult Index(string id)
        {
            ViewBag.CategoryId = id;
            return View();
        }
        public IActionResult ProductDetails(string id)
        {
            ViewBag.ProductId = id;
            return View();
        }
    }
}
