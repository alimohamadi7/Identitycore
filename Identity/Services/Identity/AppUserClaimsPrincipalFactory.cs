﻿using Identity.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Identity.Services.Identity
{
    public class AppUserClaimsPrincipalFactory: UserClaimsPrincipalFactory<User, Role>
    {
        public AppUserClaimsPrincipalFactory(
          UserManager<User> userManager,
            RoleManager<Role> roleManager,
            IOptions<IdentityOptions> options):
            base(userManager, roleManager, options)
        {

        }
        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(User user)
        {
            var claimsIdentity = await base.GenerateClaimsAsync(user);

            claimsIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString(), ClaimValueTypes.Integer));

            claimsIdentity.AddClaim(new Claim(ClaimTypes.GivenName, user.FirstName));

            claimsIdentity.AddClaim(new Claim(ClaimTypes.Surname, user.LastName));

            claimsIdentity.AddClaim(new Claim(ClaimTypes.Email, user.Email));

            claimsIdentity.AddClaim(new Claim("ImageName", user.PhotoFileName));
            return claimsIdentity;
        }

    }
}
