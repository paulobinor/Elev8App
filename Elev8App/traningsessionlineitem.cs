namespace Elev8App
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class traningsessionlineitem
    {
        [Key]
        [StringLength(64)]
        public string linitemid { get; set; }

        [StringLength(64)]
        public string trainingsessionid { get; set; }

        [StringLength(64)]
        public string studentid { get; set; }

        [StringLength(100)]
        public string fullname { get; set; }

        [StringLength(100)]
        public string moc { get; set; }

        [StringLength(100)]
        public string lab { get; set; }

        [StringLength(100)]
        public string azpass { get; set; }

        [StringLength(100)]
        public string examvoucher { get; set; }

        [StringLength(100)]
        public string organization { get; set; }

        [StringLength(100)]
        public string email { get; set; }

        [StringLength(100)]
        public string phone { get; set; }

        public virtual trainingsession trainingsession { get; set; }
    }
}
