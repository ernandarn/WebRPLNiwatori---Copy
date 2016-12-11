using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebRPLNiwatori.Models;
using WebRPLNiwatori.DAL;

namespace WebRPLNiwatori.Controllers
{
    public class Formulir_OrderController : Controller
    {
        // GET: Formulir_Order
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            //data kecamatan
            var lstKec = new List<SelectListItem>();
            using (Master_KecamatanDAL dataKec = new Master_KecamatanDAL())
            {
                foreach (var kec in dataKec.GetDataKec())
                {
                    lstKec.Add(new SelectListItem
                    {
                        Value = kec.Id_Kec.ToString(),
                        Text = kec.Nama_Kec
                    });
                }
                ViewBag.Master_Kecamatan = lstKec;
            }

            //data metode bayar
            var lstMet = new List<SelectListItem>();
            using (Metode_BayarDAL data = new Metode_BayarDAL())
            {
                foreach (var byr in data.GetData())
                {
                    lstMet.Add(new SelectListItem
                    {
                        Value = byr.IdMetode.ToString(),
                        Text = byr.Nama_Metode
                    });
                }
                ViewBag.Metode_Bayar = lstMet;
            }

            return View();
           
        }



        [HttpPost]
        public ActionResult Create(Formulir_Order form)
        { 
            using (Formulir_PemesananDAL baru = new Formulir_PemesananDAL())
            {
                try
                {
                    baru.Tambah(form);
                    TempData["Pesan"] = Helpers.Pesan.getPesan("Success!", "success", "Data Book " + form.Id_Formulir + " successfully added");
                }
                catch (Exception ex)
                {
                    TempData["Pesan"] = Helpers.Pesan.getPesan("Error !", "danger", ex.Message);
                }
            }
            return RedirectToAction("OrderNew", "Nota_Pemesanan");
        }
    }
}