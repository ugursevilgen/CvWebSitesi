using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class HakkimdaController : Controller
    {
        GenericRepository<TblHakkinda> repo = new GenericRepository<TblHakkinda>();


        [HttpGet]
        public ActionResult Index()
        {
            var hakkimda = repo.List();
            return View(hakkimda);
        }

        [HttpPost]
        public ActionResult Index(int ID, string Ad, string Soyad,string Adres,string Telefon, string Mail, string Aciklama, string Resim)
        {
            var h = repo.Find(x => x.ID == ID);

            h.Ad = Ad;
            h.Soyad = Soyad;
            h.Adres = Adres;
            h.Telefon = Telefon;
            h.Mail = Mail;
            h.Aciklama = Aciklama;
            h.Resim = Resim;
            repo.TUpdate(h);

            return RedirectToAction("Index", new { success = true });
        }
    }
}