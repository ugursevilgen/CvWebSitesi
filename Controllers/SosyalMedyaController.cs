using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class SosyalMedyaController : Controller
    {

        GenericRepository<TblSosyalMedya> repo = new GenericRepository<TblSosyalMedya>();


        public ActionResult Index()
        {
            var veriler = repo.List();

            return View(veriler);
        }

        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(TblSosyalMedya p)
        {
            p.Durum = true;
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Duzenle(int id)
        {
            var hesap = repo.Find(x => x.ID == id);
            return View(hesap);
        }

        [HttpPost]
        public ActionResult Duzenle(TblSosyalMedya p)
        {
            var hesap = repo.Find(x => x.ID == p.ID);

            hesap.Ad = p.Ad;
            hesap.Link = p.Link;
            hesap.ikon = p.ikon;
            repo.TUpdate(hesap);

            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var hesap = repo.Find(x => x.ID == id);
            repo.TDelete(hesap);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult DurumDegistir(int id)
        {
            var sosyalMedya = repo.Find(x => x.ID == id);
            if (sosyalMedya != null)
            {
                // Durumu tersine çevir (toggle)
                sosyalMedya.Durum = !sosyalMedya.Durum;
                repo.TUpdate(sosyalMedya);
            }
            return RedirectToAction("Index");
        }
    }
}
