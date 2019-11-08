using System.ComponentModel.DataAnnotations;

namespace Identity.DTOs.Account
{
    public class ExternalLoginConfirm
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }    
    }
}