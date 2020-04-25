using AutoMapper;
using BLL.Helpers;
using DAL.Interfaces;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using BLL.Interfaces;
using BLL.ModelDTO;

namespace BLL.Services.MessageServices
{
    public class MessageService: IMessageService
    {
        private readonly IUnitOfWork _database;
        private readonly IMapper _mapper;
        public MessageService(IUnitOfWork _database , IMapper _mapper)
        {
            this._database = _database;
            this._mapper = _mapper;
        }

        public async Task<ICollection<string>> CreateGroupForDialogAsync(string userId)
        {
            var user = await _database.applicationUser.FindByIdAsync(userId);
            if (user == null)
            {
                throw new UserException(false, "Id is Null", "UserId");
            }
            var friendsByUser = await _database.friendsRepository.GetWhereAsync(u => u.UserId == user.UserProfile.UserProfileId);
            if (friendsByUser.Count == 0)
                throw new UserException(true, "Friends is not founded", "Friends");
            List<UserProfile> friends = new List<UserProfile>();
            foreach (var item in friendsByUser)
            {
                friends.Add(await _database.userProfileRepository.GetByIdAsync(item.FriendId));
            }
            List<string> securityNamesGroup = new List<string>();
            foreach (var item in friends)
            {
                securityNamesGroup.Add(CodeName(userId, item.AplicationUserId));             
            }
            return securityNamesGroup;         
        }

        public string CodeName(string userId,string friendId)
        {
            string value1;
            string value2;
            ulong value3;
            ulong value4;
            string securityNameGroup = string.Empty;
            value1 = string.Join("", userId.Where(c => char.IsDigit(c))).Substring(0, string.Join("", userId.Where(c => char.IsDigit(c))).Length / 2);
            value2 = string.Join("", friendId.Where(c => char.IsDigit(c))).Substring(0, string.Join("", friendId.Where(c => char.IsDigit(c))).Length/2);
            value3=ulong.Parse(value1);
            value4= ulong.Parse(value2);
            if (value3 > value4)
            {
                securityNameGroup = userId + friendId;
            }
            else
            {
                securityNameGroup = friendId + userId;
            }
            return securityNameGroup;
        }

        public async Task<OperationDetails> CreateMessage(MessageDTO message)
        {
            if (message == null)
            {
                return new OperationDetails(false, "Message is NULL!", "Message");
            }
            var messageModel = _mapper.Map<Message>(message);
            _database.messageRepository.Create(messageModel);
            await _database.SaveAsync();
            return new OperationDetails(true, "Message is sended!", "Message");
        }

        public async Task<ICollection<MessageDTO>> GetAllMessageByDialog(string userId , string friendId)
        {
            var messages = await _database.messageRepository
               .GetWhereAsync(u =>
           (u.SenderId == userId && u.ReapientId == friendId) ||
           (u.SenderId == friendId && u.ReapientId == userId));
            return _mapper.Map<ICollection<MessageDTO>>(messages);
        }
    }
}
