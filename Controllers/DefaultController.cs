using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;

namespace MvcCv.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default

        DbCvEntities db = new DbCvEntities();

        public ActionResult Index()
        {
            var degerler = db.TblHakkinda.ToList();

            return View(degerler);
        }

        public PartialViewResult Deneyim()

        {
            var deneyimler = db.TblDeneyimlerim.ToList();
            return PartialView(deneyimler);

        }

        public PartialViewResult SosyalMedya()

        {
            var sosyalmedya = db.TblSosyalMedya.ToList();
            return PartialView(sosyalmedya);

        }

        public PartialViewResult Egitimlerim()

        {
            var egitimler = db.TblEgitimlerim.ToList();
            return PartialView(egitimler);

        }

        public PartialViewResult Yeteneklerim()

        {
            var yetenekler = db.TblYeteneklerim.ToList();
            return PartialView(yetenekler);

        }

        public PartialViewResult Hobilerim()

        {
            var hobiler = db.TblHobilerim.ToList();
            return PartialView(hobiler);

        }

        public PartialViewResult Sertifikalar()

        {
            var sertifikalar = db.TblSertifikalarim.ToList();
            return PartialView(sertifikalar);

        }
        [HttpGet]
        public PartialViewResult iletisim()

        {
            return PartialView();

        }

        [HttpPost]
        public PartialViewResult iletisim(TblIetisim t)

        {
            t.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.TblIetisim.Add(t);
            db.SaveChanges();
            return PartialView();

        }




    }
}