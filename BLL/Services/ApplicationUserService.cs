using AutoMapper;
using BLL.Helpers;
using BLL.Interfaces;
using BLL.ModelDTO;
using DAL.Interfaces;
using DAL.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ApplicationUserService : IApplicationUserService
    {
        private readonly IUnitOfWork _database;
        private readonly IMapper _mapper;       
            
        public ApplicationUserService(IUnitOfWork unitOfWork,IMapper mapper)
        {            
            _mapper = mapper;
            _database = unitOfWork;
        }

        public async Task<OperationDetails> DeleteUserAsync(string id)
        {
            var user = await _database.applicationUser.FindByIdAsync(id);
            if (user == null)
            {
                throw new UserException(false, "User with this id is not found!", "FindUserByIdAsync");
            }
            var userProfile = await _database.userProfileRepository.GetWhereAsync(n => n.AplicationUserId == id);            
             _database.userProfileRepository.Delete(userProfile.FirstOrDefault());
            await _database.applicationUser.DeleteAsync(user);
            await _database.SaveAsync();           
            return new OperationDetails(true, "User is DELETE!","Delete");
        }

        public async Task<ApplicationUserDTO> FindUserByIdAsync(string id)
        {
            var user = await _database.applicationUser.FindByIdAsync(id.ToString());
            if (user==null)
            {
                throw new UserException(false, "User with this id is not found!", "FindUserByIdAsync");
            }
            return _mapper.Map<ApplicationUserDTO>(user);
        }

        public async Task<ApplicationUserDTO> FindUserByUserName(string userName)
        {
            var user = await _database.applicationUser.FindByNameAsync(userName);
            if (user == null)
            {
                throw new UserException(false, "User with this NAME is not found!", "FindUserByIdAsync");
            }
            return _mapper.Map<ApplicationUserDTO>(user);

        }
      
        public ICollection<ApplicationUserDTO> GetAllUsersAsync()
        {
            return _mapper.Map<ICollection<ApplicationUserDTO>>(_database.applicationUser.Users.ToListAsync());
        }
        
        //НЕ РАБОТАЕТ!!!!!!!!!!
        public async Task<OperationDetails> UpdateUserAsync(ApplicationUserDTO userDTO)
        {
            var user = await  _database.applicationUser.FindByNameAsync(userDTO.UserName);
            if (user == null)
            {
                throw new UserException(false, "User with this UserName is not found","UpdateUser");
            }
            var token = _database.applicationUser.GenerateChangeEmailTokenAsync(user, userDTO.Email);
            
            await _database.applicationUser.ChangeEmailAsync(user, userDTO.Email,token.ToString());
            return new OperationDetails(false, "User is UPDATED","Update");
        }     
    }
}
