using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Entity
{
    public class UserClaim:IdentityUserClaim<int>
    {
        public virtual User User { get; set; }
    }
}
