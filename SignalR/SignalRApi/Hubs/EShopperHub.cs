using Microsoft.AspNetCore.SignalR;
using SignalRApi.Services.CommentService;

namespace SignalRApi.Hubs
{
    public class EShopperHub : Hub
    {
        private readonly ISignalRCommentService _signalRCommentService;
        public EShopperHub(ISignalRCommentService signalRCommentService)
        {
            _signalRCommentService = signalRCommentService;
        }

        public async Task SendStatisticCount()
        {
            var getTotalCommentCount = await _signalRCommentService.GetTotalCommentCount();
            await Clients.All.SendAsync("ReceiveCommentCount", getTotalCommentCount);

        }
    }
}
