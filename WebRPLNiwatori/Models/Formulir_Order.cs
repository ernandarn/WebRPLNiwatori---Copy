namespace WebRPLNiwatori.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Formulir_Order
    {
        [Key]
        public int Id_Formulir { get; set; }

        public int Id_Cart { get; set; }

        [Required]
        [StringLength(50)]
        public string Alamat { get; set; }

        [StringLength(30)]
        public string Nama_Pelanggan { get; set; }

        public int Id_Kec { get; set; }

        [Required]
        [StringLength(12)]
        public string No_Hp { get; set; }

        public virtual Master_Kecamatan Master_Kecamatan { get; set; }
    }
}
