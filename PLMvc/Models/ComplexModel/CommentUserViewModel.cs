using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PLMvc.Models
{
    public class CommentUserViewModel
    {
        public UserViewModel User { get; set; }
        public CommentViewModel Comment { get; set; }
        public int Page { get; set; }
    }
}