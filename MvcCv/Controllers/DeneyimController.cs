using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class DeneyimController : Controller
    {
        // GET: Deneyim
        DeneyimRepository deneyimRepository = new DeneyimRepository();
        public ActionResult Index()
        {
            var degerler = deneyimRepository.List();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult DeneyimEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DeneyimEkle(Tbl_Deneyimlerim p)//?? parametreyi nasıl okuyor
        {
            deneyimRepository.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeneyimSil(int id)
        {
            Tbl_Deneyimlerim t = deneyimRepository.Find(d => d.ID == id);
            deneyimRepository.TDelete(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult DeneyimGetir(int id)
        {
            Tbl_Deneyimlerim t = deneyimRepository.Find(d => d.ID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult DeneyimGetir(Tbl_Deneyimlerim p)
        {
            Tbl_Deneyimlerim t = deneyimRepository.Find(d => d.ID == p.ID);
            t.Baslik = p.Baslik;
            t.AltBaslik = p.AltBaslik;
            t.Tarih = p.Tarih;
            t.Aciklama = p.Aciklama;
            deneyimRepository.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}