using System.Windows.Input;
using EShopper.Comment.Context;
using EShopper.Comment.Dtos;
using EShopper.Comment.Entities;
using EShopper.Comment.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EShopper.Comment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet]
        public async Task<IActionResult> CommentList()
        {
            var values = await _commentService.GetCommentsAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> CommentGetById(int id)
        {
            var value = await _commentService.GetCommentByIdAsync(id);
            return Ok(value);
        }

        [HttpGet("getcommendbyproductid/{id}")]
        public async Task<IActionResult> GetCommendByProductId(string id)
        {
            var values = await _commentService.GetCommentByProductId(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(CreateCommentDto userComment)
        {
            if (userComment == null)
            {
                return BadRequest("Yorum verisi boş");
            }
            await _commentService.CreateCommentAsync(userComment);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            await _commentService.DeleteCommentAsync(id);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateComment(UpdateCommentDto userComment)
        {
            await _commentService.UpdateCommentAsync(userComment);
            return Ok();
        }
    }
}
