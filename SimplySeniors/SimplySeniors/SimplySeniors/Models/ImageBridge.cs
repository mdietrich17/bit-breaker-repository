namespace SimplySeniors
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ImageBridge")]
    public partial class ImageBridge
    {
        public int ID { get; set; }

        public int? ProfileID { get; set; }

        public int? ImageID { get; set; }

        public virtual Image Image { get; set; }
    }
}
