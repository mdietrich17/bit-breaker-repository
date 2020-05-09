namespace SimplySeniors.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PostComment")]
    public partial class PostComment
    {
        public int ID { get; set; }

        [StringLength(256)]
        public string Text { get; set; }

        public DateTime CommentDate { get; set; }

        public int ProfileID { get; set; }

        public int PostID { get; set; }

        [ForeignKey("PostID")]
        public virtual Post CommentPost { get; set; }

        [ForeignKey("ProfileID")]
        public virtual Profile CommentProfile { get; set; }
    }
}
