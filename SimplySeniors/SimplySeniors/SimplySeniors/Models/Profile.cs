namespace SimplySeniors.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Profile")]
    public partial class Profile
    {
        public int ID { get; set; }

        [Required]
        [StringLength(128)]
        public string USERID { get; set; }

        [Required]
        [StringLength(50)]
        public string FIRSTNAME { get; set; }

        [Required]
        [StringLength(50)]
        public string LASTNAME { get; set; }

        [Column(TypeName = "date")]
        public DateTime BIRTHDAY { get; set; }

        [StringLength(128)]
        public string LOCATION { get; set; }

        public bool? VETSTATUS { get; set; }

        [StringLength(128)]
        public string OCCUPATION { get; set; }

        [StringLength(128)]
        public string FAMILY { get; set; }

        [StringLength(2048)]
        public string BIO { get; set; }
    }
}
