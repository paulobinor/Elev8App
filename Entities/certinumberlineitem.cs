namespace Elev8App
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("certinumberlineitem")]
    public partial class certinumberlineitem
    {
        [Key]
        [StringLength(64)]
        public string certnumerlineitemid { get; set; }

        [StringLength(64)]
        public string certnumberid { get; set; }

        [StringLength(64)]
        public string studentid { get; set; }

        [StringLength(20)]
        public string certnumber { get; set; }
      
       // [StringLength(20)]
        public virtual certinumber certinumber { get; set; }
    }
}
