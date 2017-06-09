using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM.Entities
{
    public class Like
    {
        public Like() { }

        public int LikeId { get; set; }
        public int PhotoId { get; set; }
        public int UserId { get; set; }

        public virtual Photo Photo { get; set; }
        public virtual User User { get; set; }
    }
}
