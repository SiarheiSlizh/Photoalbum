using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PLMvc.Models
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime DateOfSending { get; set; }
        public int UserId { get; set; }
        public int PhotoId { get; set; }
    }
}