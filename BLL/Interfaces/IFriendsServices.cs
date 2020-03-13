using BLL.Helpers;
using BLL.ModelDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IFriendsServices
    {
        Task<OperationDetails> AddToFriendsAsync(int userId, int friendsId);
        Task<OperationDetails> DeleteFriendsAsync(int useriId, int friendsId);        
    }
}
