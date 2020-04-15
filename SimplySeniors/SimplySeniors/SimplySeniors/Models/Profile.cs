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
        [Display(Name = "First Name")]
        public string FIRSTNAME { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LASTNAME { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Birthday")]
        public DateTime BIRTHDAY { get; set; }

        [StringLength(128)]
        [Display(Name = "City")]
        public string CITY { get; set; }

        [StringLength(128)]
        [Display(Name = "State")]
        public string STATE { get; set; }

        [Display(Name = "Veteran Status")]
        public bool? VETSTATUS { get; set; }

        public bool? PROFILECREATED { get; set; }

        [StringLength(128)]
        [Display(Name = "Job/Occupation")]
        public string OCCUPATION { get; set; }

        [StringLength(128)]
        [Display(Name = "Family Members")]
        public string FAMILY { get; set; }

        [StringLength(2048)]
        [Display(Name = "Biography")]
        public string BIO { get; set; }

    }
}
