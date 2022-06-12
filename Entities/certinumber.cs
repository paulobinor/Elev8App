namespace Elev8App
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("certinumber")]
    public partial class certinumber
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public certinumber()
        {
            certinumberlineitems = new HashSet<certinumberlineitem>();
        }

        [Key]
        [StringLength(64)]
        public string certnumberid { get; set; }

        [StringLength(64)]
        public string trainingsessionid { get; set; }

        public int? certstartnumber { get; set; }

        public int? certendnumber { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<certinumberlineitem> certinumberlineitems { get; set; }
    }
}
