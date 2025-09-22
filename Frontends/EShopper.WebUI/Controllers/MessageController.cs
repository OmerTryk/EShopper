using EShopper.WebUI.Services.Interfaces;
using EShopper.WebUI.Services.MessageService;
using Microsoft.AspNetCore.Mvc;

namespace EShopper.WebUI.Controllers
{
    public class MessageController : Controller
    {
        private readonly IMessageService _messageService;
        private readonly IUserService _userService;
        public MessageController(IMessageService messageService, IUserService userService)
        {
            _messageService = messageService;
            _userService = userService;
        }
        public async Task<IActionResult> Inbox()
        {
            //var user = await _userService.GetUserInfo();
            var values = await _messageService.GetInboxMessageAsync("2");
            return View(values);
        }

        public async Task<IActionResult> Sendbox()
        {
            //var user = await _userService.GetUserInfo();
            var values = await _messageService.GetSendboxMessageAsync("1");
            return View(values);
        }
    }
}
