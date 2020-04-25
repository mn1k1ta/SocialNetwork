using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;
        public MessageController(IMessageService _messageService)
        {
            this._messageService = _messageService;
        }

        [HttpGet]
        [Route("GetAllMessagesByDialog")]
        public async Task<IActionResult> GetAllMessagesByDialog(string userId, string friendId)
        {
           return Ok(await _messageService.GetAllMessageByDialog(userId, friendId));
        }
    }
}