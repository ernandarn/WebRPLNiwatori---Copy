namespace WebRPLNiwatori.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Keranjang_Belanja
    {
        [Key]
        public int Id_Cart { get; set; }

        [Required]
        [StringLength(50)]
        public string Username { get; set; }


        [DisplayName("Kode Barang")]
        public int Kode_Barang { get; set; }

        public int Qty { get; set; }

        public DateTime Tanggal { get; set; }

        public virtual Barang Barang { get; set; }
    }
}
