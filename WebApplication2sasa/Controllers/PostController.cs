using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Interfaces;
using BLL.ModelDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;
        private readonly IMapper _mapper;

        public PostController(IPostService _postService, IMapper _mapper)
        {
            this._postService = _postService;
            this._mapper = _mapper;
        }

        [HttpPost]
        [Route("CreatePost")]
        public async Task<IActionResult> CreatePost(PostDTO postDTO, int userProfileDTOId)
        {
            var serviceActionResult = await _postService.CreatePostAsync(postDTO, userProfileDTOId);
            return serviceActionResult.Succedeed
                       ? (IActionResult)Ok(serviceActionResult)
                       : BadRequest(serviceActionResult);
        }

        [HttpPut]
        [Route("UpdatePost")]
        public async Task<IActionResult> UpdatePost(PostDTO post)
        {
            var serviceActionResult = await _postService.UpdatePostAsync(post);
            return serviceActionResult.Succedeed
                       ? (IActionResult)Ok(serviceActionResult)
                       : BadRequest(serviceActionResult);
        }

        [HttpDelete]
        [Route("DeletePost")]
        public async Task<IActionResult> DeletePost(int id)
        {
            var serviceActionResult = await _postService.DeletePostAsync(id);
            return serviceActionResult.Succedeed
                       ? (IActionResult)Ok(serviceActionResult)
                       : BadRequest(serviceActionResult);
        }

        [HttpGet]
        [Route("GetAllPosts")]
        public async Task<IActionResult> GetAllPosts()
        {
            return Ok(await _postService.GetAllPost());
        }

        [HttpGet]
        [Route("GetPostById")]
        public async Task<IActionResult> GetPostById(int id)
        {
            return Ok(await _postService.GetPostById(id));
        }

        [HttpGet]
        [Route("GetPostsByUser")]
        public async Task<IActionResult> GetPostsByUser(int id)
        {
            return Ok(await _postService.GetAllPostByUser(id));
        }
    }
}