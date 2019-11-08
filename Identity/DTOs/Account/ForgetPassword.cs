using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Identity.DTOs.Account
{
    public class ForgetPassword
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}