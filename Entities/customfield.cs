using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Elev8App
{
    [Table("customfield")]
    public partial class customfield
    {
        [StringLength(64)]
        public string customfieldid { get; set; }
        
        [StringLength(64)]
        public string linitemid { get; set; }
       
        [StringLength(100)]
        public string name1 { get; set; }

        [StringLength(500)]
        public string value1 { get; set; }

        [StringLength(100)]
        public string name2 { get; set; }

        [StringLength(500)]
        public string value2 { get; set; }

        [StringLength(100)]
        public string name3 { get; set; }

        [StringLength(500)]
        public string value3 { get; set; }

        [StringLength(100)]
        public string name4 { get; set; }

        [StringLength(500)]
        public string value4 { get; set; }

        [StringLength(100)]
        public string name5 { get; set; }

        [StringLength(500)]
        public string value5 { get; set; }

        [StringLength(100)]
        public string name6 { get; set; }

        [StringLength(500)]
        public string value6 { get; set; }

        [StringLength(100)]
        public string name7 { get; set; }

        [StringLength(500)]
        public string value7 { get; set; }
    }
}
