namespace SimplySeniors.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PostBridge")]
    public partial class PostBridge
    {
        public int ID { get; set; }

        public int PostID { get; set; }

        public int ProfileID { get; set; }

        public virtual Post Post { get; set; }
    }
}
