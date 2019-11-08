using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Identity.Services.Identity.Managers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Identity.Controllers
{
    public class UserValidatorController : Controller
    {
        private readonly AppUserManager _userManager;

        public UserValidatorController(AppUserManager userManager)
        {
            _userManager = userManager;
        }


        [HttpGet("validate-userName", Name = "ValidateUserName")]
        //[Route("ValidateUserName")]
        public async Task<IActionResult> ValidateUserName(string userName)
        {
            var result = await _userManager.Users.AnyAsync(user => user.UserName == userName);

            return Json(!result);
        }

        //[Route("ValidateEmail")]
        [HttpGet("validate-email", Name = "ValidateEmail")]
        public async Task<IActionResult> ValidateEmail(string email)
        {       
            var result = await _userManager.Users.AnyAsync(user => user.Email == email);
            
            return Json(!result);

        }

    }
}