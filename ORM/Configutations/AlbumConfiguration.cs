using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORM.Entities;

namespace ORM.Configutations
{
    public class AlbumConfiguration : EntityTypeConfiguration<Album>
    {
        public AlbumConfiguration()
        {
            this.Property(n => n.Name)
                .IsRequired()
                .HasMaxLength(30);

            this.Property(d => d.DateOfCreation)
                .IsRequired();
        }
    }
}
