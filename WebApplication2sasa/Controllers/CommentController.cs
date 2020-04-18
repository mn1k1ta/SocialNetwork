using System.Threading.Tasks;
using AutoMapper;
using BLL.Interfaces;
using BLL.ModelDTO;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;
        public CommentController(ICommentService _commentService, IMapper _mapper)
        {
            this._mapper = _mapper;
            this._commentService = _commentService;
        }

        [HttpPost]
        [Route("CreateComment")]
        public async Task<IActionResult> CreateComment(CommentDTO commentDTO,int postId)
        {
            return Ok(await _commentService.CreateCommentAsync(commentDTO, postId));
        }

        [HttpPut]
        [Route("EditComment")]
        public async Task<IActionResult> EditComment(CommentDTO commentDTO)
        {
            return Ok(await _commentService.UpdateCommentAsync(commentDTO));
        }

        [HttpGet]
        [Route("GetAllCommentsByPosts")]
        public async Task<IActionResult> GetAllCommentsByPosts(int postId)
        {
            return Ok(await _commentService.GetAllCommentsByPostAsync(postId));
        }

        [HttpDelete]
        [Route("DeleteComment")]
        public async Task<IActionResult> DeleteComment(int commentId)
        {
            return Ok(await _commentService.DeleteCommentAsync(commentId));
        }

        [HttpGet]
        [Route("GetCommentById")]
        public async Task<IActionResult> GetCommentById(int id)
        {
            return Ok(await _commentService.GetCommentById(id));
        }

    }
}