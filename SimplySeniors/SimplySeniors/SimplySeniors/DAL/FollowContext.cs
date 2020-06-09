using SimplySeniors.Models;

namespace SimplySeniors.DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Data.Entity.ModelConfiguration;

    public partial class FollowContext : DbContext
    {
        public FollowContext()

            : base("name=FollowContext")
          //: base("name=AzureConnection")

        {
        }

        public virtual DbSet<FollowList> FollowLists { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FollowList>()
                .HasRequired(x => x.FollowProfile)
                .WithMany()
                .HasForeignKey(x => x.FollowedUserID);
        }
        //public class FollowConfiguration : EntityTypeConfiguration<FollowList>
        //{
        //    public FollowConfiguration()
        //    {
        //        HasRequired(x => x.FollowProfile)
        //            .WithMany()  // Or, just .WithMany()
        //            .HasForeignKey(x => x.FollowedUserID);
        //        HasRequired(x => x.UserProfile)
        //            .WithMany()
        //            .HasForeignKey(x => x.UserID);
        //    }
        //}
    }
}
