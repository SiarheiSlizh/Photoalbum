using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORM.Entities;
using System.Data.Entity.Infrastructure.Annotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORM.Configutations
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            this.Property(u => u.UserName)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName, 
                    new IndexAnnotation(
                        new IndexAttribute("IX_UserName") { IsUnique = true }
                        ));

            this.Property(p => p.Password)
                .IsRequired();

            this.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName, 
                    new IndexAnnotation(
                        new IndexAttribute("IX_Email") { IsUnique = true }
                        ));

            this.Property(s => s.Surname)
                .IsRequired()
                .HasMaxLength(30);

            this.Property(n => n.Name)
                .IsRequired()
                .HasMaxLength(30);

            this.Property(d => d.DateOfBirth)
                .IsRequired();

            this.HasMany(p => p.Photos)
                .WithRequired(u => u.User)
                .WillCascadeOnDelete(false);

            this.HasMany(a => a.Albums)
                .WithRequired(u => u.User)
                .WillCascadeOnDelete(false);

            this.HasMany(c => c.Comments)
                .WithRequired(u => u.User)
                .WillCascadeOnDelete(false);

            this.HasMany(l => l.Likes)
                .WithRequired(u => u.User)
                .WillCascadeOnDelete(false);
        }
    }
}
