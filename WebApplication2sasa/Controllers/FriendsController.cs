using System.Threading.Tasks;
using AutoMapper;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "User")]
    public class FriendsController : ControllerBase
    {
        private readonly IFriendsServices _friendsServices;
        private readonly IMapper _mapper;
        private readonly IUserProfileService _userProfileService;

        public FriendsController(IFriendsServices _friendsServices, IMapper _mapper)
        {
            this._friendsServices = _friendsServices;
            this._mapper = _mapper;
        }

        [HttpPost]
        [Route("AddUserToFrends")]
        public async Task<IActionResult> AddUserToFrends(int userId,int friendId)
        {
            return Ok(await _friendsServices.AddToFriendsAsync(userId, friendId));
        }

        [HttpDelete]
        [Route("RemoveUserFromFriends")]
        public async Task<IActionResult> RemoveUserFromFriends(int userId,int friendsId)
        {
            return Ok(await _friendsServices.DeleteFriendsAsync(userId, friendsId));
        }

        [HttpGet]
        [Route("GetFriendsUser")]
        public async Task<IActionResult> GetFriendsUser(int userId)
        {
            return Ok(await _userProfileService.GetFriendsByUserAsync(userId));
        }


    }
}