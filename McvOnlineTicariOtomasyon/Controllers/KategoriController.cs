using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using McvOnlineTicariOtomasyon.Models.siniflar;
using PagedList;
using PagedList.Mvc;

namespace McvOnlineTicariOtomasyon.Controllers
{
    
    public class KategoriController : Controller
    {
        // GET: Kategori
        Context c = new Context();
        public ActionResult Index( int sayfa = 1)
        {
            var degerler = c.Kategoris.ToList().ToPagedList(sayfa,10);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KategoriEkle(Kategori k)
        {
            c.Kategoris.Add(k);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriSil(int id)
        {
            var kate = c.Kategoris.Find(id);
            c.Kategoris.Remove(kate);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int id)
        {
            var kate = c.Kategoris.Find(id);
            return View("KategoriGetir", kate);
        }

        [HttpPost]
        public ActionResult KategoriGüncelle(Kategori k)
        {
            var ktgr = c.Kategoris.Find(k.KategoriId);
            ktgr.KategoriAd = k.KategoriAd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Deneme ()
        {
            Class3 cs = new Class3();
            cs.Kategoriler = new SelectList(c.Kategoris, "KategoriId", "KategoriAd");
            cs.Urunler = new SelectList(c.Uruns, "UrunId", "UrunAd");
            return View(cs);
        }
    }
}