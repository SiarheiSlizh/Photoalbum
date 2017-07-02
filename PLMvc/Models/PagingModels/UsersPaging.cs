using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PLMvc.Models.PagingModels
{
    public class UsersPaging
    {
        public IEnumerable<UserViewModel> Users { get; set; }
        public PageInfo PageInfo { get; set; }
        public string SearchText { get; set; }
    }
}