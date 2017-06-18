using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PLMvc.Models
{
    public class UserPhotoViewModel
    {
        public UserViewModel User { get; set; }
        public PhotosPaging Photos { get; set; }
    }
}