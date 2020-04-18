using BLL.Helpers;
using BLL.ModelDTO;
using BLL.Services.Filters;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
   public  interface IUserProfileService
    {
        Task<OperationDetails> CreateUserProfileAsync(UserProfileDTO userProfile);
        Task<ICollection<UserProfileDTO>> GellAllUserProfileAsync();
        Task<ICollection<UserProfileDTO>> FindUserProfileByNameAsync(string name);
        Task<UserProfileDTO> FindUserProfileByIdAsync(int id);
        Task<OperationDetails> UpdateUserProfileAsync(UserProfileDTO userProfile);
        Task<OperationDetails> DeleteUserProfileAsync(int id);
        Task<ICollection<UserProfileDTO>> FindUserProfileByCountryOrSityAsync(string country);
        Task<ICollection<UserProfileDTO>> FindUserProfileByCountryOrSityAsync(string country, string sity);
        Task<ICollection<UserProfileDTO>> FindUserProfileByGenderAsync(string gender);
        Task<ICollection<UserProfileDTO>> FindUserProfileByAgeAsync(int minAge, int maxAge);
        Task<ICollection<UserProfileDTO>> FilterManagerAsync(IFilter[] filters);
        Task<ICollection<UserProfileDTO>> GetFriendsByUserAsync(int userId);
        Task<UserProfileDTO> GetUserProfileByApplicationUserId(string userId);



    }
}
