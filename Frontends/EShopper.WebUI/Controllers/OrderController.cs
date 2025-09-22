using EShopper.DtoLayer.OrderDtos.OrderAddressDtos;
using EShopper.WebUI.Services.Interfaces;
using EShopper.WebUI.Services.OrderService.OrderAddressService;
using Microsoft.AspNetCore.Mvc;

namespace EShopper.WebUI.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderAddressService _orderAddressService;
        private readonly IUserService _userService;
        public OrderController(IOrderAddressService orderAddressService, IUserService userService)
        {
            _orderAddressService = orderAddressService;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateOrderAddressDto createOrderAddressDto)
        {
            var values = await _userService.GetUserInfo();
            createOrderAddressDto.UserId = values.Id;
            createOrderAddressDto.Description = "aa";

            await _orderAddressService.CreateOrderAddress(createOrderAddressDto);

            return RedirectToAction("Index", "Payment");
        }
    }
}
