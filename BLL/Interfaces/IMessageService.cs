using BLL.Helpers;
using BLL.ModelDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IMessageService
    {
        string CodeName(string userId, string friendId);
        Task<OperationDetails> CreateMessage(MessageDTO message);
        Task<ICollection<MessageDTO>> GetAllMessageByDialog(string userId, string friendId);
    }
}
