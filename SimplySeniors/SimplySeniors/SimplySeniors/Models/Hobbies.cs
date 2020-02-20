namespace SimplySeniors.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Hobbies
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Hobbies()
        {
            HobbyBridges = new HashSet<HobbyBridge>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(30)]
        public string NAME { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string DESCRIPTION { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HobbyBridge> HobbyBridges { get; set; }
    }
}
