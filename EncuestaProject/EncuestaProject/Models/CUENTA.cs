namespace EncuestaProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CUENTA")]
    public partial class CUENTA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CUENTA()
        {
            DET_ENC = new HashSet<DET_ENC>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(80)]
        public string usuario { get; set; }

        [Required]
        [StringLength(90)]
        public string password { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DET_ENC> DET_ENC { get; set; }
    }
}
