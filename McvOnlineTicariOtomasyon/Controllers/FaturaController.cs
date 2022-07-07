using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using McvOnlineTicariOtomasyon.Models.siniflar;

namespace McvOnlineTicariOtomasyon.Controllers
{
    
    public class FaturaController : Controller
    {
        // GET: Fatura
        Context c = new Context();
        public ActionResult Index()
        {
            var liste = c.Faturalars.ToList();
            return View(liste);
        }
        public ActionResult FaturaEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FaturaEkle(Faturalar f)
        {
            c.Faturalars.Add(f);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FaturaGetir(int id)
        {
            var fatura = c.Faturalars.Find(id);
            return View("FaturaGetir", fatura);
        }
        public ActionResult FaturaGüncelle(Faturalar f)
        {
            var fatura = c.Faturalars.Find(f.FaturaId);
            fatura.FaturaSeriNo = f.FaturaSeriNo;
            fatura.FaturaSıraNo = f.FaturaSıraNo;
            fatura.Saat = f.Saat;
            fatura.Tarih = f.Tarih;
            fatura.TeslimAlan = f.TeslimAlan;
            fatura.TeslimEden = f.TeslimEden;
            fatura.VergiDairesi = f.VergiDairesi;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FaturaDetay(int id)
        {
            var degerler = c.FaturaKalems.Where(x => x.Faturaid == id).ToList();
            return View(degerler);
        }
        public ActionResult FaturaKalemEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FaturaKalemEKle(FaturaKalem k)
        {
            c.FaturaKalems.Add(k);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Dinamik()
        {
            Class4 cs = new Class4();
            cs.deger1 = c.Faturalars.ToList();
            cs.deger2 = c.FaturaKalems.ToList();
            return View(cs);
        }
        [HttpPost]
        public ActionResult FaturaKaydet(string FaturaSeriNo, string FaturaSıraNo,DateTime Tarih,string VergiDairesi,string Saat,string TeslimEden, string TeslimAlan,string Toplam,FaturaKalem[] kalemler)
        {
            Faturalar f = new Faturalar();
            f.FaturaSıraNo = FaturaSıraNo;
            f.FaturaSeriNo = FaturaSeriNo;
            f.Tarih = Tarih;
            f.VergiDairesi = VergiDairesi;
            f.Saat = Saat;
            f.TeslimEden = TeslimEden;
            f.TeslimAlan = TeslimAlan;
            f.Toplam =decimal.Parse(Toplam);
            c.Faturalars.Add(f);
            foreach(var x in kalemler)
            {
                FaturaKalem fk = new FaturaKalem();
                fk.Acıklama = x.Acıklama;
                fk.BirimFiyat = x.BirimFiyat;
                fk.Faturaid = x.FaturaKalemId;
                fk.Miktar = x.Miktar;
                fk.Tutar = x.Tutar;
                c.FaturaKalems.Add(fk);

            }
            c.SaveChanges();
            return Json("İşlem Başarılı", JsonRequestBehavior.AllowGet);
        }
    }
}