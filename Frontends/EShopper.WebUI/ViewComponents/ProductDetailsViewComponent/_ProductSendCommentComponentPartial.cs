using Microsoft.AspNetCore.Mvc;

namespace EShopper.WebUI.ViewComponents.ProductDetailsViewComponent
{
    public class _ProductSendCommentComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke(string id)
        {
            ViewBag.ProductIdSendComment = id;
            return View();
        }
    }
}
