using PLMvc.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PLMvc.Models
{
    public class ProfileViewModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        [EditPassword]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Passwords don't match")]
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        public byte[] Avatar { get; set; }
        public string Description { get; set; }
    }
}