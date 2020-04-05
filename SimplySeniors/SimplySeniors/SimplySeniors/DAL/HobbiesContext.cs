using SimplySeniors.Models;

namespace SimplySeniors.DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class HobbiesContext : DbContext
    {
        public HobbiesContext()
            : base("name=HobbyContext")
          //  : base("name=AzureConnection")
        {
        }

        public virtual DbSet<Hobbies> Hobbies { get; set; }
        public virtual DbSet<HobbyBridge> HobbyBridges { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hobbies>()
                .Property(e => e.DESCRIPTION)
                .IsUnicode(false);

            modelBuilder.Entity<Hobbies>()
                .HasMany(e => e.HobbyBridges)
                .WithOptional(e => e.Hobby)
                .HasForeignKey(e => e.HobbiesID);
        }
    }
}
