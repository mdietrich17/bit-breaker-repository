using SimplySeniors.Models;

namespace SimplySeniors.DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PostContext : DbContext
    {
        public PostContext()
            : base("name=PostContext")
            //: base("name=AzureConnection")
        {
        }

        public virtual DbSet<PostBridge> PostBridges { get; set; }
        public virtual DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>()
                .HasMany(e => e.PostBridges)
                .WithRequired(e => e.Post)
                .WillCascadeOnDelete(false);
        }
    }
}
