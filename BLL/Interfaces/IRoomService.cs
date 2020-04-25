using BLL.Helpers;
using BLL.ModelDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IRoomService
    {
        Task<OperationDetails> CreateRoom(RoomDTO roomDTO);
        Task<RoomDTO> GetRoom(string firstUserId, string secondUserId);
    }
}
