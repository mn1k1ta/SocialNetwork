using AutoMapper;
using BLL.Helpers;
using BLL.Interfaces;
using BLL.ModelDTO;
using BLL.Services.Filters;
using DAL.Interfaces;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserProfileService : IUserProfileService
    {
        private readonly IUnitOfWork _database;
        private readonly IMapper _mapper;

        public UserProfileService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _database = unitOfWork;
            _mapper = mapper;
        }

        public async Task<OperationDetails> CreateUserProfileAsync(UserProfileDTO userProfile)
        {
            if (userProfile == null)
                throw new UserException(false, "UserProfile is null", "Create");
            _database.userProfileRepository.Create(_mapper.Map<UserProfile>(userProfile));
            await _database.SaveAsync();
            return new OperationDetails(true, "UserProfile is Created", "Create");
        }

        public async Task<OperationDetails> DeleteUserProfileAsync(int id)
        {
            var user = await FindUserProfileByIdAsync(id);
            _database.userProfileRepository.Delete(_mapper.Map<UserProfile>(user));
            await _database.SaveAsync();
            return new OperationDetails(true, "User Profile Is Deleted", "Delete");
        }

        public async Task<ICollection<UserProfileDTO>> FindUserProfileByAgeAsync(int minAge, int maxAge)
        {
            DateTime now = DateTime.Today;
            if ((minAge < 0 | maxAge < 0) | (minAge >= maxAge))
                throw new UserException(false, "Incorect type of age!", "age");
            var users = await _database.userProfileRepository.GetWhereAsync(u => ((now.Year - u.Birthday.Year) <= maxAge) && ((now.Year - u.Birthday.Year) >= minAge));
            if (users.Count == 0)
                throw new UserException(false, "User with thi age not found!", "Age");
            return _mapper.Map<ICollection<UserProfileDTO>>(users);

        }

        public async Task<ICollection<UserProfileDTO>> FindUserProfileByCountryOrSityAsync(string country)
        {
            if (string.IsNullOrEmpty(country))
                throw new UserException(false, "Country is null", "country");
            var users = await _database.userProfileRepository.GetWhereAsync(u => u.Country == country);
            if (users.Count == 0)
                throw new UserException(false, "User with this country is not found", "country");
            return _mapper.Map<ICollection<UserProfileDTO>>(users);
        }

        public async Task<ICollection<UserProfileDTO>> FindUserProfileByCountryOrSityAsync(string country, string sity)
        {
            if (string.IsNullOrEmpty(country) | string.IsNullOrEmpty(sity))
                throw new UserException(false, "Country or sity is null", "country");
            var users = await _database.userProfileRepository.GetWhereAsync(u => u.Country == country & u.Sity == sity);
            if (users.Count == 0)
                throw new UserException(false, "User with this country and sity is not found", "country");
            return _mapper.Map<ICollection<UserProfileDTO>>(users);
        }

        public async Task<ICollection<UserProfileDTO>> FindUserProfileByGenderAsync(string gender)
        {
            if (string.IsNullOrEmpty(gender))
                throw new UserException(false, "Gender is null", "country");
            var users = await _database.userProfileRepository.GetWhereAsync(u => u.Gender == gender);
            if (users.Count == 0)
                throw new UserException(false, "User with this Gender is not found", "Gender");
            return _mapper.Map<ICollection<UserProfileDTO>>(users);
        }

        public async Task<UserProfileDTO> FindUserProfileByIdAsync(int id)
        {
            var userProfile = await _database.userProfileRepository.GetByIdAsync(id);
            if (userProfile == null)
                throw new UserException(false, "User with this id is not found!", "FindUser");
            return _mapper.Map<UserProfileDTO>(userProfile);
        }

        public async Task<ICollection<UserProfileDTO>> FindUserProfileByNameAsync(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new UserException(false, "Name is NULL!", "FindUser");
            var user = await _database.userProfileRepository.GetWhereAsync(n => n.Name.Contains(name));
            if (user.Count == 0)
                throw new UserException(false, "User with this name is not found!", "FindUser");
            return _mapper.Map<ICollection<UserProfileDTO>>(user);
        }

        public async Task<OperationDetails> UpdateUserProfileAsync(UserProfileDTO userProfile)
        {
            if (userProfile == null)
                throw new UserException(false, "UserProfile is null", "UserProfile");
            var user = await _database.userProfileRepository.GetByIdAsync(userProfile.UserProfileId);
            if (user == null)
                throw new UserException(false, "User with this id is not found", "Update");
            _database.userProfileRepository.Update(_mapper.Map<UserProfile>(userProfile));
            await _database.SaveAsync();
            return new OperationDetails(true, "User is Updated", "Update");
        }

        public async Task<ICollection<UserProfileDTO>> GellAllUserProfileAsync()
        {
            var users = await _database.userProfileRepository.GetAllAsync();
            if (users.Count == 0)
                throw new UserException(false, "Users is null", "GetAllUsers");
            return _mapper.Map<ICollection<UserProfileDTO>>(users);

        }

        public async Task<ICollection<UserProfileDTO>> GetFriendsByUserAsync(int userId)
        {
            var user = await _database.userProfileRepository.GetByIdAsync(userId);
            if (user == null)
                throw new UserException(false, "User with this id is not found ", "Get");
            var friendsByUser = await _database.friendsRepository.GetWhereAsync(u => u.UserId == userId);
            List<UserProfile> friends = new List<UserProfile>(); 
            foreach (var item in friendsByUser)
            {
                friends.Add(await _database.userProfileRepository.GetByIdAsync(item.FriendId));
            }
            return _mapper.Map<ICollection<UserProfileDTO>>(friends);           
        }

        public async Task<ICollection<UserProfileDTO>> FilterManagerAsync(IFilter[] filters)
        {
            var users = await _database.userProfileRepository.GetWhereWithFiltersAsync(filters.Where(x => x.Filter != null).Select(x => x.Filter).ToArray());
            return _mapper.Map<ICollection<UserProfileDTO>>(users);
        }

    }
}
