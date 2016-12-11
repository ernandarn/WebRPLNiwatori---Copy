using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebRPLNiwatori.Models;
using WebRPLNiwatori.ViewModels;

namespace WebRPLNiwatori.DAL
{
    public class Formulir_PemesananDAL :IDisposable
    {
        private NiwatoriModelsss db = new NiwatoriModelsss();

        public IQueryable<Formulir_OrderVM> GetFormWithKec()
        {
            var result = from b in db.Formulir_Order.Include("Master_Kecamatan")
                         orderby b.Id_Formulir
                         select new Formulir_OrderVM
                         {
                             Id_Formulir = b.Id_Formulir,
                             Id_Kec = b.Id_Kec,
                             Id_Cart = b.Id_Cart,
                             Nama_Pelanggan = b.Nama_Pelanggan,
                             Alamat = b.Alamat,
                             No_Hp = b.No_Hp,
                             Nama_Kec = b.Master_Kecamatan.Nama_Kec,
                             Nama_Kab = b.Master_Kecamatan.Nama_Kab,
                         };
            return result;
        }

        public void Tambah(Formulir_Order form)
        {
            db.Formulir_Order.Add(form);
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}