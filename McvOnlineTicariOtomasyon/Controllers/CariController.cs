using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using McvOnlineTicariOtomasyon.Models.siniflar;

namespace McvOnlineTicariOtomasyon.Controllers
{
    
    public class CariController : Controller
    {
        // GET: Cari
        Context c = new Context();
        public ActionResult Index()
        {
            var değerler = c.Carilers.Where(x=>x.Durum == true).ToList();
            return View(değerler);
        }
        public ActionResult YeniCari()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniCari(Cariler p)
        {
            p.Durum = true;
            c.Carilers.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariSil(int id)
        {
            var car = c.Carilers.Find(id);
            car.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariGetir(int id )
        {
            var cari = c.Carilers.Find(id);
            return View("CariGetir",cari);
        }
        [HttpPost]
        public ActionResult CariGüncelle(Cariler p)
        {
            if(!ModelState.IsValid)
            {
                return View("CariGetir");
            }
            var cari = c.Carilers.Find(p.CariId);
            cari.CariAd = p.CariAd;
            cari.CariSoyad = p.CariSoyad;
            cari.CariSehir = p.CariSehir;
            cari.CariMail = p.CariMail;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MüsteriSatis(int id)
        {
            var degerler = c.SatisHarekets.Where(x => x.Cariid == id).ToList();
            var mus = c.Carilers.Where(x => x.CariId == id).Select(y => y.CariAd + " " + y.CariSoyad).FirstOrDefault();
            ViewBag.must = mus;
            return View(degerler);

        }
    }
}