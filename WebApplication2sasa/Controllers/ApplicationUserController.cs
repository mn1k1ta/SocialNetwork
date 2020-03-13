using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using WebApi.ViewModels;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUserController : ControllerBase
    {
        
        private readonly IUnitOfWork _userManger;
        private readonly ApplicationSettings _appSettings;
        public ApplicationUserController( IUnitOfWork _userManger,IOptions<ApplicationSettings> options)
        {
            
            this._userManger = _userManger;
            _appSettings = options.Value;
        }

        [HttpPost]
        [Route("Register")]
    
        public async Task<Object> PostApplicationUser(ApplicationUserModel model)
        {
            model.Role = "User";
            var applicationUser = new ApplicationUser()
            {
                UserName = model.UserName,
                Email = model.Email,              
            };

            try
            {
                var result = await _userManger.applicationUser.CreateAsync(applicationUser, model.Password);
                await _userManger.applicationUser.AddToRoleAsync(applicationUser, model.Role);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost]
        [Route("Login")]
       
        public async Task<IActionResult> Login(LoginModel model)
        {
            var user = await _userManger.applicationUser.FindByNameAsync(model.UserName);
            if (user != null && await _userManger.applicationUser.CheckPasswordAsync(user, model.Password))
            {
                //Get role assigned to the user
                var role = await _userManger.applicationUser.GetRolesAsync(user);
                IdentityOptions _options = new IdentityOptions();

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("UserID",user.Id.ToString()),
                        new Claim(_options.ClaimsIdentity.RoleClaimType,role.FirstOrDefault())
                    }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.JWT_Secret)), SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);
                return Ok(new { token });
            }
            else
                return BadRequest(new { message = "Username or password is incorrect." });
        }

    }
}