namespace SimplySeniors.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HobbyBridge")]
    public partial class HobbyBridge
    {
        public int ID { get; set; }

        public int? HobbiesID { get; set; }

        public int? ProfileID { get; set; }

        public virtual Hobbies Hobby { get; set; }
    }
}
