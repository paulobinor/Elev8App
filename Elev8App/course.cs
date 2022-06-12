namespace Elev8App
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("course")]
    public partial class course
    {
        [StringLength(64)]
        public string courseid { get; set; }

        [StringLength(500)]
        public string coursename { get; set; }

        [StringLength(10)]
        public string coursecode { get; set; }

        public int? duration { get; set; }

        public string coursedescription { get; set; }
    }
}
