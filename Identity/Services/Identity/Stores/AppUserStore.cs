using System;
using System.Threading;
using System.Threading.Tasks;

using Identity.Data;
using Identity.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Identity.Services.Identity.Stores
{
    public class AppUserStore : UserStore<User,Role,ApplicationDbContext,int,UserClaim,UserRole,UserLogin,UserToken,RoleClaim>
    {
        public AppUserStore(ApplicationDbContext context, IdentityErrorDescriber describer = null) : base(context, describer)
        {
        }
    }
}