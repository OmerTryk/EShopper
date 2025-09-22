namespace SignalRApi.Services.CommentService
{
    public interface ISignalRCommentService
    {
        Task<int> GetTotalCommentCount();
    }
}
