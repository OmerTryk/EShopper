using Microsoft.AspNetCore.Mvc;

namespace EShopper.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
