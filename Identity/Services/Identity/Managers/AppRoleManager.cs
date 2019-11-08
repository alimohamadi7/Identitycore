using System.Collections.Generic;
using Identity.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Identity.Services.Identity.Managers
{
    public class AppRoleManager : RoleManager<Role>
    {
        public AppRoleManager(
            IRoleStore<Role> store,
            IEnumerable<IRoleValidator<Role>> roleValidators,
            ILookupNormalizer keyNormalizer,
            IdentityErrorDescriber errors,
            ILogger<RoleManager<Role>> logger
        ) : base(store, roleValidators, keyNormalizer, errors, logger)
        {
        }
    }
}