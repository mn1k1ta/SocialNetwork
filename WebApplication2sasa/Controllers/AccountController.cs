using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Helpers;
using BLL.Interfaces;
using BLL.ModelDTO;
using BLL.Services.Filters;
using DAL.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.ViewModels;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AccountController : ControllerBase
    {
        private readonly ILoginService _loginService;
        private readonly IMapper _mapper;
        private readonly IApplicationUserService applicationUserService;
        private readonly IUserProfileService userProfileService;
        private readonly IPostService postService;
    
    

        public AccountController( IMapper mapper, IApplicationUserService applicationUserService,IUserProfileService userProfileService, IPostService postService)
        {
            this.userProfileService = userProfileService;
            this.applicationUserService = applicationUserService;
           
            _mapper = mapper;
            this.postService = postService;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Create(ApplicationUserDTO user)
        {
            var serviceActionResult = await _loginService.RegisterUserAsync(user);
            return serviceActionResult.Succedeed
                       ? (IActionResult)Ok(serviceActionResult)
                       : BadRequest(serviceActionResult);
        }

        //[HttpPost]
        //[Route("Login")]       
        //public async Task<IActionResult> Login(string userName, string pass)
        //{
        //    var serviceActionResult = await _loginService.Login(userName,pass);
        //    return serviceActionResult.Succedeed
        //               ? (IActionResult)Ok(serviceActionResult)
        //               : BadRequest(serviceActionResult);
        //}

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(ApplicationUserDTO userDTO)
        {           
                var serviceActionResult = await _loginService.AuthenticateAsync(userDTO);
                return serviceActionResult.Succedeed
                           ? (IActionResult)Ok(serviceActionResult)
                           : BadRequest(serviceActionResult);
        }

        [HttpPost]
        [Route("LogOut")]
        
        public async Task<IActionResult> LogOut()
        {
            var serviceActionResult = await _loginService.LogOutUserAsync();
            return serviceActionResult.Succedeed
                       ? (IActionResult)Ok(serviceActionResult)
                       : BadRequest(serviceActionResult);
        }
        
        [HttpGet]
        [Route("id/{id}")]        
        public async Task<IActionResult> FindUser(string id)
        {
            return Ok(await applicationUserService.FindUserByIdAsync(id));
        }
        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> GetAll()
        {
            return Ok( applicationUserService.GetAllUsersAsync());
        }

        [HttpDelete]
        [Route("id/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var serviceActionResult = await applicationUserService.DeleteUserAsync(id);
            return serviceActionResult.Succedeed
                       ? (IActionResult)Ok(serviceActionResult)
                       : BadRequest(serviceActionResult);
        }

        [HttpPut]
        [Route("Update")]

        public async Task<IActionResult> Update(ApplicationUserDTO user)
        {
            var serviceActionResult = await applicationUserService.UpdateUserAsync(user);
            return serviceActionResult.Succedeed
                       ? (IActionResult)Ok(serviceActionResult)
                       : BadRequest(serviceActionResult);
        }



        //[HttpPost]
        //public IActionResult Login(string username, string pass)
        //{
        //    return Ok(_loginService.Login(username, pass));
        //}



        //[Authorize]
        //[HttpPost("Post")]
        //public string Post()
        //{
        //    var identiy = HttpContext.User.Identity as ClaimsIdentity;
        //    IList<Claim> claim = identiy.Claims.ToList();
        //    var userName = claim[0].Value;
        //    return "Welcom To:" + userName;
        //}

        


        [HttpPost]
        [Route("Profile")]
        public async Task<IActionResult> CreateProfile(UserProfileDTO user)
        {
            var serviceActionResult = await userProfileService.CreateUserProfileAsync(user) ;
            return serviceActionResult.Succedeed
                       ? (IActionResult)Ok(serviceActionResult)
                       : BadRequest(serviceActionResult);
        }

        [HttpGet]
        [Route("name/{name}")]
        public async Task<IActionResult> FindName(string name)
        {
            return Ok(await userProfileService.FindUserProfileByNameAsync(name));
        }

        [HttpGet]
        [Route("country/{name}")]
        public async Task<IActionResult> FindSity(string name)
        {
            return Ok(await userProfileService.FindUserProfileByCountryOrSityAsync(name));
        }

        [HttpGet]
        [Route("siti")]
        public async Task<IActionResult> FindCountry(string name,string name2)
        {
            return Ok(await userProfileService.FindUserProfileByCountryOrSityAsync(name,name2));
        }

        [HttpGet]
        [Route("age")]
        public async Task<IActionResult> FindAge(int ag1,int age2)
        {
            return Ok(await userProfileService.FindUserProfileByAgeAsync(ag1,age2));
        }
        

        [HttpPost]
        [Route("CreatePost")]
        public async Task<IActionResult> CreatePost(PostDTO postDTO,int userProfileDTOId)
        {
            var serviceActionResult = await postService.CreatePostAsync(postDTO, userProfileDTOId);
            return serviceActionResult.Succedeed
                       ? (IActionResult)Ok(serviceActionResult)
                       : BadRequest(serviceActionResult);
        }

        [HttpPut]
        [Route("UpdatePost")]
        public async Task<IActionResult> UpdatePost(PostDTO post)
        {
            var serviceActionResult = await postService.UpdatePostAsync(post);
            return serviceActionResult.Succedeed
                       ? (IActionResult)Ok(serviceActionResult)
                       : BadRequest(serviceActionResult);
        }

        [HttpDelete]
        [Route("DeletePost")]
        public async Task<IActionResult> DeletePost(int id)
        {
            var serviceActionResult = await postService.DeletePostAsync(id);
            return serviceActionResult.Succedeed
                       ? (IActionResult)Ok(serviceActionResult)
                       : BadRequest(serviceActionResult);
        }

        [HttpGet]
        [Route("GetAllPost")]
        public async Task<IActionResult> GetAllPost()
        {
            return Ok(await postService.GetAllPost());
        }

        [HttpGet]
        [Route("GetPostById")]
        public async Task<IActionResult> GetPostById(int id)
        {
            return Ok(await postService.GetPostById(id));
        }

        [HttpGet]
        [Route("GetPostByUser")]
        public async Task<IActionResult> GetPostbyUser(int id)
        {
            return Ok(await postService.GetAllPostByUser(id));
        }

        [HttpGet]
        [Route("Find")]
        public async Task<IActionResult> FindUsers([FromQuery] FilterModel filterModel)
        {
            var filters = new List<IFilter>();
            filters.Add(new NameFilter(filterModel.Name));
            filters.Add(new GenderFilter(filterModel.Gender));
            filters.Add(new CountryFilter(filterModel.Country));
            filters.Add(new CityFilter(filterModel.City));
            filters.Add(new AgeFilter(filterModel.MinAge, filterModel.MaxAge));

            return Ok(await userProfileService.FilterManagerAsync(filters.ToArray()));

        }


    }
}