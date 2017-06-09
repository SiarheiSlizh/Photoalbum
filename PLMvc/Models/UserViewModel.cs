using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PLMvc.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public byte[] Avatar { get; set; }
        public string Description { get; set; }
    }
}