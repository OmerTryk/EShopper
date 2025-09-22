using EShopper.DtoLayer.MessageDtos;

namespace EShopper.WebUI.Services.MessageService
{
    public interface IMessageService
    {
        Task<List<ResultInboxMessageDto>> GetInboxMessageAsync(string id);
        Task<List<ResultSendboxMessageDto>> GetSendboxMessageAsync(string id);
        Task<int> GetTotalMessageCountByReceiverId(string id);
    }
}
