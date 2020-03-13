using DAL.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text;

namespace DAL.Identity
{
    public class ApplicationRoleManager:RoleManager<IdentityRole>
    {
        public ApplicationRoleManager(IRoleStore<IdentityRole> store, 
            IEnumerable<IRoleValidator<IdentityRole>> roleValidators, 
            ILookupNormalizer keyNormalizer, 
            IdentityErrorDescriber errors,
            ILogger<RoleManager<IdentityRole>> logger) 
            : base(store,
                roleValidators,
                keyNormalizer,
                errors,
                logger)
        {

        }
    }
}
