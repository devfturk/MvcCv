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
        // GET: Hakkimda
        HakkimdaRepository repo = new HakkimdaRepository();
        [HttpGet]
        public ActionResult Index()
        {
            var hakkimda = repo.List();
            return View(hakkimda);
        }
        [HttpPost]
        public ActionResult Index(Tbl_Hakkimda p)
        {
            var hakkimda = repo.Find(x => x.ID == 1);
            hakkimda.Ad = p.Ad;
            hakkimda.Soyad = p.Soyad;
            hakkimda.Adres = p.Adres;
            hakkimda.Mail = p.Mail;
            hakkimda.Telefon = p.Telefon;
            hakkimda.Aciklama = p.Aciklama;
            hakkimda.Resim = p.Resim;
            repo.TUpdate(hakkimda);
            return RedirectToAction("Index");
        }
    }
}
