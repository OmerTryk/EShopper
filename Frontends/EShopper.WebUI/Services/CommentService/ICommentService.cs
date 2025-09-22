using EShopper.DtoLayer.CommentDtos;

namespace EShopper.WebUI.Services.CommentService
{
    public interface ICommentService
    {
        Task<List<ResultCommentDto>> GetCommentsAsync();
        Task<GetByIdCommentDto> GetCommentByIdAsync(int id);
        Task CreateCommentAsync(CreateCommentDto createCommentDto);
        Task DeleteCommentAsync(int id);
        Task UpdateCommentAsync(UpdateCommentDto updateCommentDto);
        Task<List<ResultCommentDto>> GetCommentByProductId(string id);
    }
}
