using AutoMapper;
using BLL.Helpers;
using BLL.Interfaces;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class FriendsService : IFriendsServices
    {
        private readonly IUnitOfWork _database;
        private readonly IMapper _mapper;
        public FriendsService(IUnitOfWork _database, IMapper _mapper)
        {
            this._database = _database;
            this._mapper = _mapper;
        }

        public async Task<OperationDetails> AddToFriendsAsync(int userId, int friendsId)
        {
            var user = await _database.userProfileRepository.GetByIdAsync(userId);
            if (user == null)
                new OperationDetails(false, "User is not found!","AddToFriends");
            var friends = await _database.userProfileRepository.GetByIdAsync(friendsId);
            if (friends == null)
                new OperationDetails(false, "User is not found!", "AddToFriends");
            var userWithThisFriends = await _database.friendsRepository.GetWhereAsync(u => u.UserId == userId && u.FriendId == friendsId);
            if (userWithThisFriends == null)
            {
                _database.friendsRepository.Create(new DAL.Model.Friends() { FriendId = friendsId, UserId = userId });
                await _database.SaveAsync();
            }
            return new OperationDetails(true, "Frinds with add", "Friends");

        }

        public async Task<OperationDetails> DeleteFriendsAsync(int userId, int friendId)
        {
            var user = await _database.userProfileRepository.GetByIdAsync(userId);
            if (user == null)
                return new OperationDetails(false, "User with this id is not found!", "UserId");
            var friend = await _database.userProfileRepository.GetByIdAsync(friendId);
            if (friend == null)
                return new OperationDetails(false, "User with this id is not found!", "UserId");
            var deletedFriend = await _database.friendsRepository.GetWhereAsync(f => f.UserId == userId && f.FriendId == friendId);
            if (deletedFriend == null)
                return new OperationDetails(false, "This user is not your friend.", "Friends");
            _database.friendsRepository.Delete(deletedFriend.First());
            await _database.SaveAsync();
            return new OperationDetails(true, "Friend is deleted", "Deleted");
        }
    }
}
