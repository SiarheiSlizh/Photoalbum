using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PLMvc.Models
{
    public class AlbumViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }
        public DateTime DateOfCreation { get; set; }
    }
}