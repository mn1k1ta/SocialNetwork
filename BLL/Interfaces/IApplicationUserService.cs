using BLL.Helpers;
using BLL.ModelDTO;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IApplicationUserService
    {    
        Task<OperationDetails> DeleteUserAsync(string id);
        Task<ICollection<ApplicationUserDTO>> GetAllUsersAsync();      
        Task<ApplicationUserDTO> FindUserByUserName(string userName);
        Task<OperationDetails> UpdateUserAsync(ApplicationUserDTO userDTO);
        Task<ApplicationUserDTO> FindUserByIdAsync(string id);
    }
}
