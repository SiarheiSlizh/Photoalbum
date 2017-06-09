using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.Entities
{
    public class Album
    {
        public Album()
        {
            Photos = new HashSet<Photo>();
        }

        public int AlbumId { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }
        public DateTime DateOfCreation { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Photo> Photos { get; set; }
    }
}