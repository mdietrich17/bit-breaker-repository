using ThrowawayProject.Models;

namespace ThrowawayProject.DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
   

    public partial class AthleteContext : DbContext
    {
        public AthleteContext()
            : base("name=AzureConnection")
        {
        }

        public virtual DbSet<Athlete> Athletes { get; set; }
        public virtual DbSet<Coach> Coaches { get; set; }
        public virtual DbSet<Meet> Meets { get; set; }
        public virtual DbSet<RaceResult> RaceResults { get; set; }
        public virtual DbSet<Team> Teams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
