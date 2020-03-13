using BLL.Helpers;
using BLL.ModelDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ILoginService
    {
        Task<OperationDetails> AuthenticateAsync(ApplicationUserDTO userDTO);
        Task<OperationDetails> RegisterUserAsync(ApplicationUserDTO userDTO);
        Task<OperationDetails> LogOutUserAsync();
         Task<OperationDetails> Login(string username, string pass);
    }
}
