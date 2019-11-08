
using Identity.Data;
using Identity.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Identity.Services.Identity.Stores
{
    public class AppRoleStore : RoleStore<Role,ApplicationDbContext,int,UserRole,RoleClaim>
    {
        public AppRoleStore(ApplicationDbContext context, IdentityErrorDescriber describer = null) : base(context, describer)
        {
        }
    }
}