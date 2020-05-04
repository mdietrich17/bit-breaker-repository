namespace SimplySeniors.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class LikeList : DbContext
    {
        public LikeList()
            : base("name=LikeList")
        {
        }

        public virtual DbSet<PostLike> PostLikes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
