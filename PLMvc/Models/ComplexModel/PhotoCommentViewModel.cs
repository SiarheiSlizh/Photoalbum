using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PLMvc.Models
{
    public class PhotoCommentViewModel
    {
        public PhotoViewModel Photo { get; set; }
        public CommentsPaging CommentPaging { get; set; }
        public UserViewModel User { get; set; }
    }
}