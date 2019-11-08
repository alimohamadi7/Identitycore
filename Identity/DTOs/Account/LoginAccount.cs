using System.ComponentModel.DataAnnotations;

namespace Identity.DTOs.Account
{
    public class LoginAccount
    {
        [Required(ErrorMessage ="نام کاربری یا ایمیل نباید خالی باشد")]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Required (ErrorMessage ="پسورد نباید خالی باشد")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}