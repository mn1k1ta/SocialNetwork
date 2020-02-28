using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Model
{
    public class ApplicationUser:IdentityUser
    {
        public  UserProfile UserProfile { get; set; }
        
    }
}
