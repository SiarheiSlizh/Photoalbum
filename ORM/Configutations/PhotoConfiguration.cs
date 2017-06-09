using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORM.Entities;

namespace ORM.Configutations
{
    public class PhotoConfiguration : EntityTypeConfiguration<Photo>
    {
        public PhotoConfiguration()
        {
            this.Property(i => i.Image)
                .IsRequired();

            this.Property(n => n.NumberOfLikes)
                .IsRequired();

            this.Property(n => n.NumberOfComments)
                .IsRequired();

            this.Property(d => d.DateOfLoading)
                .IsRequired();

            this.Property(u => u.UserId)
                .IsRequired();
        }
    }
}
