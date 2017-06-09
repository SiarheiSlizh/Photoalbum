using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PLMvc.Models
{
    public class LikeViewModel
    {
        public int Id { get; set; }
        public int PhotoId { get; set; }
        public int UserId { get; set; }
    }
}