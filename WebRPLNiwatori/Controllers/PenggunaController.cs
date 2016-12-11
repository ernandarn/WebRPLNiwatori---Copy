using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using WebRPLNiwatori.DAL;
using WebRPLNiwatori.Models;

namespace WebRPLNiwatori.Controllers
{
    public class PenggunaController : Controller
    {
        // GET: Pengguna
        public ActionResult Index()
        {
            //cek apakah user sudah login
            //jika user belum login
            if (Session["Pengguna"] == null)
            {
                TempData["pesan"] =
                    "<div class='alert alert-info'>Anda harus melakukan Login terlebih dahulu</div>";
                return RedirectToAction("Login");
            }
            else
            {
                Pengguna objPengguna = (Pengguna)Session["Pengguna"];
                return View(objPengguna);
            }
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Pengguna pengguna)
        {
            PenggunaDAL penggunaDAL = new PenggunaDAL();
            var objPengguna = penggunaDAL.Login(pengguna);

            if (objPengguna != null)
            {
                //jika login berhasil bautkan session baru
                Session["Pengguna"] = objPengguna;
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Error = "<div class='alert alert-danger'>Login Gagal !</div>";
                return View();
            }
        }

        public ActionResult Logout()
        {
            Session["Pengguna"] = null;
            return RedirectToAction("Login");
        }


        public ActionResult Registrasi()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registrasi(Pengguna pengguna)
        {
            PenggunaDAL penggunaDAL = new PenggunaDAL();
            try
            {
                if (ModelState.IsValid)
                {
                    penggunaDAL.Registrasi(pengguna);
                    ViewBag.Pesan = "Data Pengguna berhasil ditambah !";
                }
                return View();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }
    }
}