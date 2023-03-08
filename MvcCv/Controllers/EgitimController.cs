using MvcCv.Repositories;
using MvcCv.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class EgitimController : Controller
    {
        // GET: Egitim
        EgitimRepository egitimRepository = new EgitimRepository();
        [Authorize]
        public ActionResult Index()
        {
            var egitimler = egitimRepository.List();
            return View(egitimler);
        }
        [HttpGet]
        public ActionResult EgitimEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EgitimEkle(Tbl_Egitim p)
        {
            if (!ModelState.IsValid)
            {
                return View("EgitimEkle");
            }
            egitimRepository.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult EgitimSil(int id)
        {
            var egitim = egitimRepository.Find(x => x.ID == id);
            egitimRepository.TDelete(egitim);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EgitimDuzenle(int id)
        {
            var egitim = egitimRepository.Find(x => x.ID == id);
            return View(egitim);
        }
        [HttpPost]
        public ActionResult EgitimDuzenle(Tbl_Egitim p)
        {
            if (!ModelState.IsValid)
            {
                return View("EgitimDuzenle");
            }
            var egitim = egitimRepository.Find(x => x.ID == p.ID);
            egitim.Baslik = p.Baslik;
            egitim.AltBaslik1 = p.AltBaslik1;
            egitim.AltBaslik2 = p.AltBaslik2;
            egitim.GNO = p.GNO;
            egitim.Tarih = p.Tarih;
            egitimRepository.TUpdate(egitim);
            return RedirectToAction("Index");
        }
    }
}