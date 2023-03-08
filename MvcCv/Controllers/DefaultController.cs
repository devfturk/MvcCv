using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;

namespace MvcCv.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default
        DbdevfturkcvEntities db = new DbdevfturkcvEntities();
        public ActionResult Index()
        {
            var degerler = db.Tbl_Hakkimda.ToList();
            return View(degerler);
        }
        public PartialViewResult SosyalMedya()
        {
            var sosyalMedya = db.Tbl_SosyalMedya.Where(x=>x.Durum == true).ToList();
            return PartialView(sosyalMedya);
        }
        public PartialViewResult Deneyim()
        {
            var deneyimler = db.Tbl_Deneyimlerim.ToList();
            return PartialView(deneyimler);
        }
        public PartialViewResult Egitimlerim()
        {
            var egitimler = db.Tbl_Egitim.ToList();
            return PartialView(egitimler);
        }
        public PartialViewResult Yeteneklerim()
        {
            var yeteneklerim = db.Tbl_Yeteneklerim.ToList();
            return PartialView(yeteneklerim);
        }
        public PartialViewResult Hobilerim()
        {
            var hobilerim = db.Tbl_Hobilerim.ToList();
            return PartialView(hobilerim);
        }
        public PartialViewResult Sertifikalarim()
        {
            var sertifikalarim = db.Tbl_Sertifikalarim.ToList();
            return PartialView(sertifikalarim);
        }
        [HttpGet]
        public PartialViewResult Iletisim()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Iletisim(Tbl_Iletisim t)
        {
            t.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.Tbl_Iletisim.Add(t);
            db.SaveChanges();
            return PartialView();
        }


    }
}