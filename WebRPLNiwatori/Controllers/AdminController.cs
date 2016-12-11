using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using WebRPLNiwatori.Models;
using WebRPLNiwatori.DAL;

namespace WebRPLNiwatori.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            if (Session["Pengguna"] == null)
            {
                return RedirectToAction("Login", "Pengguna");
            }
            else
            {
                var objPengguna = (Pengguna)Session["Pengguna"];
                if (objPengguna.Role != "Admin")
                {
                    TempData["pesan"] =
                    @"<div class='alert alert-info'>Anda harus melakukan Login 
                      sebagai admin terlebih dahulu</div>";
                    return RedirectToAction("Login", "Pengguna");
                }
                else
                {
                    return View(objPengguna);
                }
            }
        }
    }
}