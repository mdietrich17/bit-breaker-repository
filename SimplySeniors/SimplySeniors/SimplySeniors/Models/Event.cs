namespace SimplySeniors.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Event
    {
        public int ID { get; set; }

        [Required]
        [StringLength(128)]
        public string NAME { get; set; }

        [Required]
        [StringLength(2048)]
        public string DESCRIPTION { get; set; }

        [Required]
        [StringLength(128)]
        public string LOCATION { get; set; }

        public DateTime STARTTIME { get; set; }

        public DateTime ENDTIME { get; set; }
    }
}
