using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Entity
{
    public class User:IdentityUser<int>
    {
        [StringLength(450)]
        public string FirstName { get; set; }
        [StringLength(450)]
        public string LastName { get; set; }

        public int Age { get; set; }

        public Gender Gender { get; set; }

        public DateTime RegisteredOn { get; set; }
        [StringLength(450)]
        public string PhotoFileName { get; set; }
        public string GeneratedKey { get; set; }
        public ICollection<UserRole> Roles { get; set; }

        public ICollection<UserLogin> Logins { get; set; }

        public ICollection<UserClaim> Claims { get; set; }

        public ICollection<UserToken> Tokens { get; set; }
    }
}
