using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Repositories;
using MvcCv.Models.Entity;

namespace MvcCv.Controllers
{
    public class YetenekController : Controller
    {
        // GET: Yetenek
        YetenekRepository yetenekRepository = new YetenekRepository();
        public ActionResult Index()
        {
            var yetenekler = yetenekRepository.List();
            return View(yetenekler);
        }
        [HttpGet]
        public ActionResult YeniYetenek()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniYetenek(Tbl_Yeteneklerim p)
        {
            yetenekRepository.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult YetenekSil(int id)
        {
            var yetenek = yetenekRepository.Find(y => y.ID == id);
            yetenekRepository.TDelete(yetenek);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult YetenekDuzenle(int id)
        {
            var yetenek = yetenekRepository.Find(y => y.ID == id);
            return View(yetenek);
        }
        [HttpPost]
        public ActionResult YetenekDuzenle(Tbl_Yeteneklerim p)
        {
            var t = yetenekRepository.Find(x => x.ID == p.ID);
            //t.ID = p.ID;
            t.Oran = p.Oran;
            t.Yetenek = p.Yetenek;
            yetenekRepository.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}