using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.ModelDTO
{
    public class ApplicationUserDTO
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }

    }
}
