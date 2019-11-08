using System.Threading.Tasks;

using Identity.Entity;
using Microsoft.AspNetCore.Identity;

namespace Identity.Services.Identity.Validators
{
    public class AppRoleValidator : RoleValidator<Role>
    {
        public AppRoleValidator(IdentityErrorDescriber errors) : base(errors)
        {
        }

        public override Task<IdentityResult> ValidateAsync(RoleManager<Role> manager, Role role)
        {
            return base.ValidateAsync(manager, role);
        }
    }   
}   