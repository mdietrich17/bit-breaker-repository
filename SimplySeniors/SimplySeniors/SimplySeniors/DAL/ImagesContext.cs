namespace SimplySeniors.DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ImagesContext : DbContext
    {
        public ImagesContext()
            : base("name=Images")
        {
        }

        public virtual DbSet<ImageBridge> ImageBridges { get; set; }
        public virtual DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
