using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebRPLNiwatori.ViewModels
{
    public class Formulir_OrderVM
    {
        [Key]
        public int Id_Formulir { get; set; }

        public int Id_Cart { get; set; }

      
        public string Nama_Pelanggan { get; set; }

        [Required]
        public string Alamat { get; set; }

        public int Id_Kec { get; set; }

        [Required]
        public string No_Hp { get; set; }

        [Required]
        [StringLength(30)]
        public string Nama_Kec { get; set; }

        [Required]
        [StringLength(20)]
        public string Nama_Kab { get; set; }


        [Key]
        public int IdMetode { get; set; }

    
        [StringLength(8)]
        public string Nama_Metode { get; set; }
        //[Required]
        //public string Username { get; set; }


        //[DisplayName("Kode Barang")]
        //public int Kode_Barang { get; set; }

        //public int Qty { get; set; }

        //public DateTime Tanggal { get; set; }
    }
}