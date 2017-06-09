using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.Entities
{
    public class Photo
    {
        public Photo()
        {
            Comments = new HashSet<Comment>();
            Likes = new HashSet<Like>();
        }

        public int PhotoId { get; set; }
        public byte[] Image { get; set; }
        public string Description { get; set; }
        public int NumberOfLikes { get; set; }
        public int NumberOfComments { get; set; }
        public DateTime DateOfLoading { get; set; }
        public int UserId { get; set; }
        public int? AlbumId { get; set; }

        public virtual User User { get; set; }
        public virtual Album Album { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
    }
}
