namespace SimplySeniors
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Image
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Image()
        {
            ImageBridges = new HashSet<ImageBridge>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(30)]
        public string NAME { get; set; }

        public int SIZE { get; set; }

        [Required]
        public byte[] ImageData { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ImageBridge> ImageBridges { get; set; }
    }
}
