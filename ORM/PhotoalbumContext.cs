using System;
using System.Data.Entity;
using System.Linq;
using ORM.Entities;
using ORM.Configutations;

namespace ORM
{   
    public class PhotoalbumContext : DbContext
    {
        public PhotoalbumContext()
            : base("name=PhotoalbumDb")
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<Photo> Photos { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Like> Likes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new RoleConfiguration());
            modelBuilder.Configurations.Add(new AlbumConfiguration());
            modelBuilder.Configurations.Add(new PhotoConfiguration());
            modelBuilder.Configurations.Add(new CommentConfiguration());
            modelBuilder.Configurations.Add(new LikeConfiguration());
        }
    }
}