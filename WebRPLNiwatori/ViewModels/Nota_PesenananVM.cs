using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebRPLNiwatori.ViewModels
{
    public class Nota_PesenananVM
    {
        [Key]
        public int No_Nota { get; set; }

        [StringLength(10)]
        public string Username { get; set; }

        public DateTime Tanggal_Nota { get; set; }

        public DateTime Tanggal_Kirim { get; set; }

        [Key]
        public int Kode_Barang { get; set; }

        [Required]
        [StringLength(20)]
        public string Nama_Barang { get; set; }

        [Required]
        [StringLength(6)]
        public string Satuan { get; set; }

        [Column(TypeName = "money")]
        public decimal Harga { get; set; }

        public int Qty { get; set; }
    }
}