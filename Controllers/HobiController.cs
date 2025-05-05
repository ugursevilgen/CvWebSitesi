using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class HobiController : Controller
    {
        GenericRepository<TblHobilerim> repo = new GenericRepository<TblHobilerim>();


        [HttpGet]
        public ActionResult Index()
        {
            var hobiler = repo.List();
            return View(hobiler);
        }

        [HttpPost]
        public ActionResult Index(int ID, string Aciklama1, string Aciklama2)
        {
            var hobiler = repo.Find(x => x.ID == ID);

            hobiler.Aciklama1 = Aciklama1;
            hobiler.Aciklama2 = Aciklama2;
            repo.TUpdate(hobiler);

            return RedirectToAction("Index", new { success = true });
        }
    }
}