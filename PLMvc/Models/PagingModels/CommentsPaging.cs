using PLMvc.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PLMvc.Models
{
    public class CommentsPaging
    {
        public IEnumerable<CommentViewModel> Comments { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}