using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Entity
{
    public class Role:IdentityRole<int>
    {
        public ICollection<UserRole> Roles { get; set; }
        public ICollection<RoleClaim> Claims { get; set; }
    }
}
