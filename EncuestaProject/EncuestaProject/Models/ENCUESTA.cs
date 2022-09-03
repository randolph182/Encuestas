namespace EncuestaProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ENCUESTA")]
    public partial class ENCUESTA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ENCUESTA()
        {
            CAMPO = new HashSet<CAMPO>();
            DET_ENC = new HashSet<DET_ENC>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string nombre { get; set; }

        [StringLength(200)]
        public string descripcion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CAMPO> CAMPO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DET_ENC> DET_ENC { get; set; }
    }
}
