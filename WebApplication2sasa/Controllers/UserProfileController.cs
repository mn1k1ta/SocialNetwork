using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "User")]
    public class UserProfileController : ControllerBase
    {
        private readonly IUserProfileService _userProfileService;
        private readonly IMapper _mapper;

        public UserProfileController(IUserProfileService _userProfileService, IMapper _mapper)
        {
            this._mapper = _mapper;
            this._userProfileService = _userProfileService;
        }


        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllUserProfile()
        {
            return Ok(await _userProfileService.GellAllUserProfileAsync());
        }

    }
}