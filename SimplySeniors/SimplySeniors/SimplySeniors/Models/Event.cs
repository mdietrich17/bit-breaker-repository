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

        [Required(ErrorMessage = "Enter Name"), Display(Name = "Name")]
        [StringLength(128)]
        public string NAME { get; set; }

        [Required(ErrorMessage = "Enter Description"), Display(Name = "Description")]
        [StringLength(2048)]
        public string DESCRIPTION { get; set; }

        [Required(ErrorMessage = "Enter Location"), Display(Name = "Location")]
        [StringLength(128)]
        public string LOCATION { get; set; }

        [Required(ErrorMessage = "Enter Start Date"), Display(Name = "Start Date")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime STARTDATE { get; set; }

        [Required(ErrorMessage = "Enter Start Time in the form of HOUR:MINUTES AM/PM, ie: 05:30 PM"), Display(Name = "Start Time")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:hh\\:mm tt}")]
        public DateTime STARTTIME { get; set; }

        [Required(ErrorMessage = "Enter End Date"), Display(Name = "End Date")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime ENDDATE { get; set; }

        [Required(ErrorMessage = "Enter End Time in the form of HOUR:MINUTES AM/PM, ie: 05:30 PM"), Display(Name = "End Time")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:hh\\:mm tt}")]
        public DateTime ENDTIME { get; set; }
    }
}
