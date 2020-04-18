using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Interfaces;
using BLL.ModelDTO;
using BLL.Services.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.ViewModels;

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
        [Route("GetAllUserProfile")]
        public async Task<IActionResult> GetAllUserProfile()
        {
            return Ok(await _userProfileService.GellAllUserProfileAsync());
        }

        [HttpGet]
        [Route("GetUserProfileByName")]
        public async Task<IActionResult> GetUserProfileByName(string name)
        {
            return Ok(await _userProfileService.FindUserProfileByNameAsync(name));
        }

        [HttpGet]
        [Route("GetUserProfileById")]
        public async Task<IActionResult> GetUserProfileById(int id)
        {
            return Ok(await _userProfileService.FindUserProfileByIdAsync(id));
        }

        [HttpGet]
        [Route("SearchByFilters")]
        public async Task<IActionResult> FindUsers([FromQuery] FilterModel filterModel)
        {
            var filters = new List<IFilter>();
            filters.Add(new NameFilter(filterModel.Name));
            filters.Add(new GenderFilter(filterModel.Gender));
            filters.Add(new CountryFilter(filterModel.Country));
            filters.Add(new CityFilter(filterModel.City));
            filters.Add(new AgeFilter(filterModel.MinAge, filterModel.MaxAge));
            return Ok(await _userProfileService.FilterManagerAsync(filters.ToArray()));
        }

        [HttpPut]
        [Route("EditUserProfile")]
        public async Task<IActionResult> EditUserProfile(UserProfileDTO userProfileDTO)
        {
            return Ok(await _userProfileService.UpdateUserProfileAsync(userProfileDTO));
        }

        [HttpGet]
        [Route("GetUserProfileByApplicationUserId")]
        public async Task<IActionResult> GetUserProfileByApplicationUserId(string userId)
        {
            return Ok(await _userProfileService.GetUserProfileByApplicationUserId(userId));
        }
    }
}