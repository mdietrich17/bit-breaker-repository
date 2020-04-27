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
         //   : base("name=PostContext")
           : base("name=AzureConnection")
        {
        }

        public virtual DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

        public System.Data.Entity.DbSet<SimplySeniors.Models.Profile> Profiles { get; set; }
    }
}
