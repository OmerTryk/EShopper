using AutoMapper;
using EShopper.Comment.Context;
using EShopper.Comment.Dtos;
using EShopper.Comment.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace EShopper.Comment.Services
{
    public class CommentService : ICommentService
    {
        private readonly CommentDbContext _context;
        private readonly IMapper _mapper;

        public CommentService(CommentDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateCommentAsync(CreateCommentDto createCommentDto)
        {
            try
            {
                var value = _mapper.Map<UserComment>(createCommentDto);
                await _context.UserComments.AddAsync(value);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
                throw;
            }
        }

        public async Task DeleteCommentAsync(int id)
        {
            try
            {
                var value = await _context.UserComments.FindAsync(id);
                if (value == null)
                {
                    throw new Exception("Yorum bulunamadı");
                }
                _context.UserComments.Remove(value);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
                throw;
            }
        }

        public async Task<GetByIdCommentDto> GetCommentByIdAsync(int id)
        {
            try
            {
                var value = await _context.UserComments.FindAsync(id);
                if (value == null)
                {
                    throw new Exception("Yorum bulunamadı");
                }
                return _mapper.Map<GetByIdCommentDto>(value);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
                throw;
            }
        }

        public async Task<List<ResultCommentDto>> GetCommentByProductId(string id)
        {
            try
            {
                var values = await _context.UserComments
                    .Where(x => x.ProductId == id)
                    .ToListAsync();
                if (values == null || !values.Any())
                {
                    throw new Exception("Yorum bulunamadı");
                }
                return _mapper.Map<List<ResultCommentDto>>(values);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
                throw;
            }
        }

        public async Task<List<ResultCommentDto>> GetCommentsAsync()
        {
            try
            {
                var values = await _context.UserComments.ToListAsync();
                if (values == null || !values.Any())
                {
                    throw new Exception("Yorum bulunamadı");
                }
                return _mapper.Map<List<ResultCommentDto>>(values);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
                throw;
            }
        }

        public async Task UpdateCommentAsync(UpdateCommentDto updateCommentDto)
        {
            try
            {

                var value = _mapper.Map<UserComment>(updateCommentDto);
                if (value == null)
                {
                    throw new Exception("Yorum bulunamadı");
                }
                _context.UserComments.Update(value);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
                throw;
            }
        }
    }
}
