using System.ComponentModel.DataAnnotations;

namespace Identity.DTOs.Manager.User
{
    public class AddUserClaim
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string ClaimType { get; set; }

        [Required]
        public string ClaimValue { get; set; }
    }
}