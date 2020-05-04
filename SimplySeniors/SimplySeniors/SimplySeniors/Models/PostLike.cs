namespace SimplySeniors.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PostLike")]
    public partial class PostLike
    {
        public int ID { get; set; }

        public int ProfileID { get; set; }

        public bool Liked { get; set; }

        public int PostID { get; set; }
    }
}
