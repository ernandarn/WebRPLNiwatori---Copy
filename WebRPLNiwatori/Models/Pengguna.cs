namespace WebRPLNiwatori.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Pengguna")]
    public partial class Pengguna
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pengguna()
        {
            Nota_Pemesanan = new HashSet<Nota_Pemesanan>();
        }

        [Key]
        [StringLength(50)]
        public string Username { get; set; }

        [Required]
        [StringLength(30)]
        public string Nama_pengguna { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        [Required]
        [StringLength(15)]
        public string Role { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Nota_Pemesanan> Nota_Pemesanan { get; set; }
    }
}
