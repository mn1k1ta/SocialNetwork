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
    public class ApplicationRoleManager:RoleManager<ApplicationRole>
    {
        public ApplicationRoleManager(IRoleStore<ApplicationRole> store, 
            IEnumerable<IRoleValidator<ApplicationRole>> roleValidators, 
            ILookupNormalizer keyNormalizer, 
            IdentityErrorDescriber errors,
            ILogger<RoleManager<ApplicationRole>> logger) 
            : base(store,
                roleValidators,
                keyNormalizer,
                errors,
                logger)
        {

        }
    }
}
