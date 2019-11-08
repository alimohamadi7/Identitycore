using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Identity.Entity;
using Microsoft.AspNetCore.Identity;

namespace Identity.Services.Identity.Validators
{
    public class AppUserValidator : UserValidator<User>
    {
        public AppUserValidator(IdentityErrorDescriber errors) : base(errors)
        {
        }

        public override async Task<IdentityResult> ValidateAsync(UserManager<User> manager, User user)
        {
            IdentityResult result = await base.ValidateAsync(manager, user);
            List<IdentityError> errors = result.Succeeded ? new List<IdentityError>() : result.Errors.ToList();
            if (user.UserName.ToLower().Contains("admin"))
            {
                errors.Add(new IdentityError
                {
                    Code = "InvalidUser",
                    Description = "نام کاربری نمیتواند شامل Admin  باشد. "
                });
            }
            return errors.Count == 0 ? IdentityResult.Success : IdentityResult.Failed(errors.ToArray());

        }
    }
}