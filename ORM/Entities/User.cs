using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.Entities
{
    public class User
    {
        public User()
        {
            Roles = new HashSet<Role>();
            Albums = new HashSet<Album>();
            Photos = new HashSet<Photo>();
            Likes = new HashSet<Like>();
            Comments = new HashSet<Comment>();
        }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public byte[] Avatar { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
        public virtual ICollection<Album> Albums { get; set; }
        public virtual ICollection<Photo> Photos { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
