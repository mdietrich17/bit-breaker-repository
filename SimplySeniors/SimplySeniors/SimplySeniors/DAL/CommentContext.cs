using SimplySeniors.Models;

namespace SimplySeniors.DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CommentContext : DbContext
    {
        public CommentContext()
            : base("name=CommentContext")
         // : base("name=AzureConnection")

        {
        }

        public virtual DbSet<PostComment> PostComments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
