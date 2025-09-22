using System.Threading.Tasks;
using EShopper.DtoLayer.IdentityDtos.LoginDtos;
using EShopper.WebUI.Services.CatalogService.CategoryService;
using EShopper.WebUI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EShopper.WebUI.Controllers
{
    public class SingInTestController : Controller
    {
        private readonly IIdentityService _identityService;
        private readonly ICategoryService _categoryService;

        public SingInTestController(IIdentityService identityService, ICategoryService categoryService)
        {
            _identityService = identityService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index(SingInDto singInDto)
        {
            singInDto.Username = "OmerTiryaki";
            singInDto.Password = "Omer123-";
            await _identityService.SingIn(singInDto);
            return RedirectToAction("Index","User");
        }

        public async Task<IActionResult> Test2()
        {
            var values = await _categoryService.GetAllCategoryAsync();
            return View(values);
        }
    }
}
