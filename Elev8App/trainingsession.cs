namespace Elev8App
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("trainingsession")]
    public partial class trainingsession
    {
        

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public trainingsession()
        {
            traningsessionlineitems = new HashSet<traningsessionlineitem>();
        }

        [StringLength(64)]
        public string trainingsessionid { get; set; }

        [StringLength(100000)]
        public string coursewaremail { get; set; }
        
        [StringLength(10)]
        public string Col { get; set; }

        [StringLength(100)]
        public string coursename { get; set; }

        [StringLength(10)]
        public string coursecode { get; set; }

        [StringLength(100)]
        public string trainer { get; set; }

        [StringLength(50)]
        public string duration { get; set; }

        [StringLength(100)]
        public string expm { get; set; }

        public DateTime? startdate { get; set; }

        public DateTime? endate { get; set; }

        public DateTime? teastart { get; set; }

        public DateTime? teaend { get; set; }

        public DateTime? lunchstart { get; set; }

        public DateTime? lunchend { get; set; }

        public string courselink { get; set; }

        public DateTime? startime { get; set; }

        public DateTime? endtime { get; set; }

        [StringLength(64)]
        public string trainerid { get; set; }

        public virtual trainer trainer1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<traningsessionlineitem> traningsessionlineitems { get; set; }
    }
}
