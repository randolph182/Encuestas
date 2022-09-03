namespace EncuestaProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Diagnostics;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Web.Services.Description;

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

        EncuestaModel db = new EncuestaModel();
        public bool Autenticar()
        {
            //Debug.WriteLine("My debug string here");
            var pass = EncMD5(this.password);
            Debug.WriteLine(pass);
            return db.CUENTA.Where(u => u.usuario == this.usuario && u.password == pass).FirstOrDefault() != null;
        }

        private static string EncMD5(string password)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            UTF8Encoding encoder = new UTF8Encoding();
            Byte[] originalBytes = encoder.GetBytes(password);
            Byte[] encodedBytes = md5.ComputeHash(originalBytes);
            return BitConverter.ToString(encodedBytes);
            //password = BitConverter.ToString(encodedBytes).Replace("-", "");
            //var result = password.ToLower();
            //return 
        }
    }
}
