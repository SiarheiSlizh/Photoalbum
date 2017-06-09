using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.Entities
{
    public class Comment
    {
        public Comment() { }

        public int CommentId { get; set; }
        public string Description { get; set; }
        public DateTime DateOfSending { get; set; }
        public int UserId { get; set; }
        public int PhotoId { get; set; }

        public User User { get; set; }
        public Photo Photo { get; set; }
    }
}
