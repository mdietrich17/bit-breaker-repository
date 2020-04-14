namespace SimplySeniors.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FollowList")]
    public partial class FollowList
    {
        public int ID { get; set; }

        public int? UserID { get; set; }

        public int FollowedUserID { get; set; }

        public DateTime TimeFollowed { get; set; }

        [ForeignKey("FollowedUserID")]
        public virtual Profile FollowProfile { get; set; }
    }
}
