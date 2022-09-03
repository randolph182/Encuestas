namespace EncuestaProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DET_ENC
    {
        public int id { get; set; }

        public int id_usuario { get; set; }

        public int id_encuesta { get; set; }

        [Column(TypeName = "date")]
        public DateTime? fecha { get; set; }

        public virtual CUENTA CUENTA { get; set; }

        public virtual ENCUESTA ENCUESTA { get; set; }
    }
}
