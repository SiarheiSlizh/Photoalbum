using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORM.Entities;

namespace ORM.Configutations
{
    public class LikeConfiguration : EntityTypeConfiguration<Like>
    {
        public LikeConfiguration()
        {
            this.Property(p => p.PhotoId)
                .IsRequired();

            this.Property(u => u.UserId)
                .IsRequired();
        }
    }
}
