namespace SimplySeniors.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Post
    {
        public int ID { get; set; }

        [Required]
        [StringLength(64)]
        public string Title { get; set; }

        [StringLength(256)]
        public string Body { get; set; }

        public int ProfileID { get; set; }
    }
}
