using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORM.Entities;

namespace ORM.Configutations
{
    public class CommentConfiguration : EntityTypeConfiguration<Comment>
    {
        public CommentConfiguration()
        {
            this.Property(d => d.Description)
                .IsRequired();

            this.Property(d => d.DateOfSending)
                .IsRequired();

            this.Property(u => u.UserId)
                .IsRequired();

            this.Property(p => p.PhotoId)
                .IsRequired();
        }
    }
}
