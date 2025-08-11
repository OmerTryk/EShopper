using Microsoft.AspNetCore.Mvc;

namespace EShopper.WebUI.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult _UILayout()
        {
            return View();
        }
    }
}
