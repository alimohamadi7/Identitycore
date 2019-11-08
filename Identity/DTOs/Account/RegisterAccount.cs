using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace Identity.DTOs.Account
{
    public class RegisterAccount
    {
        public RegisterAccount()
        {
            RegisteredOn = DateTime.Now;
        }
        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Remote("ValidateUserName", ErrorMessage = "نام کاربری قبلا ثبت شده است.")]
        [RegularExpression(@"^[a-zA-Z0-9-']*$", ErrorMessage = "نام کاربری معتبر نمیباشد")]
        public string UserName { get; set; }
        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = " لطفا {0} را وارد کنید")]
        [Remote("ValidateEmail", ErrorMessage = "ایمیل وارد شده قبلا ثبت شده است.")]
        //[EmailAddress(ErrorMessage = "ایمیل وارد شده صحیح نمی باشد")]
        public string Email { get; set; }
        
        [DataType(DataType.Password)]
        [Display(Name = " کلمه عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]

        public string Password { get; set; }
        [Compare(nameof(Password),ErrorMessage ="کلمه عبور و تکرار کلمه عبور متفاوت است.")]
        [DataType(DataType.Password)]
        [Display(Name = "تکرار کلمه عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]

        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "نام را وارد کنید.")]
     
        public string FirstName { get; set; }
        [Required(ErrorMessage = "نام خانوادگی را وارد کنید.")]
        public string LastName { get; set; }
        [Display(Name = "شماره تماس")]
        [MaxLength(20, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        [RegularExpression(@"(\+98|0)?9\d{9}$", ErrorMessage = "شماره تلفن معتبر نمیباشد")]
        [Required(ErrorMessage = "لطفا شماره تلفن را وارد نمایید.")]
        public string PhoneNumberUser { get; set; }
        public DateTime RegisteredOn { get; set; }
        public String token { get; set; }
    }
}