using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PLMvc.Models
{
    public class RegisterViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Username")]
        [Required(ErrorMessage = "Please, enter your username")]
        public string UserName { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please, enter your password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirm password")]
        [Required(ErrorMessage = "Confirm password!")]
        [Compare("Password", ErrorMessage = "Passwords are different!")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Please, enter your email")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Incorrect email!")]
        public string Email { get; set; }

        [Display(Name = "Surname")]
        [Required(ErrorMessage = "Please, enter your surname")]
        public string Surname { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Please, enter your name")]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Please, enter your name")]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Please, enter numbers from picture")]
        public string Captcha { get; set; }
    }
}