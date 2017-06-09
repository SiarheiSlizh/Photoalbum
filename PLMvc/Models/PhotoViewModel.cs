using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PLMvc.Models
{
    public class PhotoViewModel
    {
        public int Id { get; set; }
        public byte[] Image { get; set; }
        public string Description { get; set; }
        public int NumberOfComments { get; set; }
        public int NumberOfLikes { get; set; }
        public DateTime DateOfLoading { get; set; }
        public int UserId { get; set; }
    }
}