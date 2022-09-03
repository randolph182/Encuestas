namespace EncuestaProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CAMPO")]
    public partial class CAMPO
    {
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string nombre { get; set; }

        [Required]
        [StringLength(50)]
        public string titulo { get; set; }

        public bool es_requerido { get; set; }

        [Required]
        [StringLength(7)]
        public string tipo_campo { get; set; }

        public int id_encuesta { get; set; }

        public virtual ENCUESTA ENCUESTA { get; set; }
    }
}
