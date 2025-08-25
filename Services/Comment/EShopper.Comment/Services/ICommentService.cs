using EShopper.Comment.Dtos;
using EShopper.Comment.Entities;

namespace EShopper.Comment.Services
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
