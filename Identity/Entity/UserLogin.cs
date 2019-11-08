using System;
using Microsoft.AspNetCore.Identity;

namespace Identity.Entity
{
    public class UserLogin : IdentityUserLogin<int>
    {
        public virtual User User { get; set; }

        public DateTime LoggedOn { get; set; }  
    }
}