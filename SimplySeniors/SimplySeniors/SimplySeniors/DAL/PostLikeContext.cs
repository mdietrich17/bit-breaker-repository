using SimplySeniors.Models;

namespace SimplySeniors.DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PostLikeContext : DbContext
    {
        public PostLikeContext()
            : base("name=PostLikeContext")
        //   : base("name=AzureConnection")
        {
        }

        public virtual DbSet<PostLike> PostLikes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
