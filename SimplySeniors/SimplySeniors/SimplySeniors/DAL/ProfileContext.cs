using SimplySeniors.Models;

namespace SimplySeniors.DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ProfileContext : DbContext
    {
        public ProfileContext()
           // : base("name=AzureConnection")
            : base("name=ProfileContext")
        {
        }

        public virtual DbSet<Profile> Profiles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
