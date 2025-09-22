using Microsoft.AspNetCore.Mvc;

namespace EShopper.WebUI.Controllers
{
    public class PaymentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
