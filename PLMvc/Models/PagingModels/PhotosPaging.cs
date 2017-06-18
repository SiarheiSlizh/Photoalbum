using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PLMvc.Models
{
    public class PhotosPaging
    {
        public IEnumerable<PhotoViewModel> Photos { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}