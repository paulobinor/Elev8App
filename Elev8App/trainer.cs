namespace Elev8App
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("trainer")]
    public partial class trainer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public trainer()
        {
            trainingsessions = new HashSet<trainingsession>();
        }

        [StringLength(64)]
        public string trainerid { get; set; }

        [StringLength(100)]
        public string fullname { get; set; }

       
        public byte[] signature { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<trainingsession> trainingsessions { get; set; }
    }
}
