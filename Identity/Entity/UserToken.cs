using System;
using Microsoft.AspNetCore.Identity;

namespace Identity.Entity
{
    public class UserToken : IdentityUserToken<int>
    {
        public virtual User User { get; set; }

        public DateTime GeneratedOn { get; set; }   
    }
}