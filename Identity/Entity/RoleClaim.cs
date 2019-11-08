using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Entity
{
    public class RoleClaim:IdentityRoleClaim<int>
    {
        public DateTime GivenOn { get; set; }
        public virtual Role Role { get; set; }
    }
}
