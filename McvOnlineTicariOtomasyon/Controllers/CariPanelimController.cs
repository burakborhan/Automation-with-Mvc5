using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using McvOnlineTicariOtomasyon.Models.siniflar;
namespace McvOnlineTicariOtomasyon.Controllers
{
    public class CariPanelimController : Controller
    {
        Context c = new Context();
        // GET: CariPanelim
        [Authorize]
        public ActionResult Index()
        {
            var mail = (string)Session["CariMail"];
            var degerler = c.Mesajlars.Where(x => x.Alıcı == mail).ToList();
            ViewBag.m = mail;
            var mailid = c.Carilers.Where(x => x.CariMail == mail).Select(y => y.CariId).FirstOrDefault();
            ViewBag.mid = mailid;
            var toplamsatis = c.SatisHarekets.Where(x => x.Cariid == mailid).Count();
            ViewBag.ts = toplamsatis;
            var toplamTutar = c.SatisHarekets.Where(x => x.Cariid == mailid).Sum(y => y.ToplamTutar);
            ViewBag.tp = toplamTutar;
            var toplamurunsayısı = c.SatisHarekets.Where(x => x.Cariid == mailid).Sum(y => y.Adet);
            ViewBag.tpu = toplamurunsayısı;
            var adsoyad = c.Carilers.Where(x => x.CariMail == mail).Select(y => y.CariAd + " " + y.CariSoyad).FirstOrDefault();
            ViewBag.adsoyad = adsoyad;
            return View(degerler);
        }
        [Authorize]
        public ActionResult Siparislerim()
        {
            var mail = (string)Session["CariMail"];
            var id = c.Carilers.Where(x => x.CariMail == mail.ToString()).Select(y => y.CariId).FirstOrDefault();
            var degerler = c.SatisHarekets.Where(x => x.Cariid == id).ToList();
            return View(degerler);
        }
        [Authorize]
        public ActionResult GelenMesajlar()
        {
            var mail = (string)Session["CariMail"];
            var mesajlar = c.Mesajlars.Where(x=>x.Alıcı == mail).OrderByDescending(x=> x.MesajId).ToList();
            var gidensayisi = c.Mesajlars.Count(x => x.Gönderici == mail).ToString();
            ViewBag.d2 = gidensayisi;
            var gelensayisi = c.Mesajlars.Count(x => x.Alıcı == mail).ToString();
            ViewBag.d1 = gelensayisi;
            return View(mesajlar);
        }
        [Authorize]
        public ActionResult GidenMesajlar()
        {
            var mail = (string)Session["CariMail"];
            var mesajlar = c.Mesajlars.Where(x => x.Gönderici == mail).OrderByDescending(x=>x.MesajId).ToList();
            var gelensayisi = c.Mesajlars.Count(x => x.Alıcı == mail).ToString();
            ViewBag.d1 = gelensayisi;
            var gidensayisi = c.Mesajlars.Count(x => x.Gönderici == mail).ToString();
            ViewBag.d2 = gidensayisi;
            return View(mesajlar);
        }
        [Authorize]
        public ActionResult MesajDetay(int id)
        {
            var degerler = c.Mesajlars.Where(x => x.MesajId == id).ToList();
            var mail = (string)Session["CariMail"];
            var gidensayisi = c.Mesajlars.Count(x => x.Gönderici == mail).ToString();
            ViewBag.d2 = gidensayisi;
            var gelensayisi = c.Mesajlars.Count(x => x.Alıcı == mail).ToString();
            ViewBag.d1 = gelensayisi;
            return View(degerler);
        }
        [Authorize]
        public ActionResult YeniMesaj()
        { 
            var mail = (string)Session["CariMail"];
            var gidensayisi = c.Mesajlars.Count(x => x.Gönderici == mail).ToString();
            ViewBag.d2 = gidensayisi;
            var gelensayisi = c.Mesajlars.Count(x => x.Alıcı == mail).ToString();
            ViewBag.d1 = gelensayisi;
            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult YeniMesaj(Mesajlar m)
        {
            var mail = (string)Session["CariMail"];
            m.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            m.Gönderici = mail;
            c.Mesajlars.Add(m);
            c.SaveChanges();
            return View();
        }
        [Authorize]
        public ActionResult KargoTakip(string p)
        {
            var k = from x in c.kargoDetays select x;            
            k = k.Where(y => y.TakipKodu.Contains(p));            
            return View(k.ToList());
        }
        [Authorize]
        public ActionResult CariKargoTakip(string id)
        {
            var degerler = c.kargoTakips.Where(x => x.TakipKodu == id).ToList();
            return View(degerler);
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
        public PartialViewResult Partial1()
        {
            var mail = (string)Session["CariMail"];
            var id = c.Carilers.Where(x => x.CariMail == mail).Select(y => y.CariId).FirstOrDefault();
            var caribul = c.Carilers.Find(id);
            return PartialView("Partial1",caribul);
        }
        public PartialViewResult Partial2()
        {
            var veriler = c.Mesajlars.Where(x => x.Gönderici == "admin").ToList();
            return PartialView(veriler);
        }
        public ActionResult CariBilgiGüncelle(Cariler cr)
        {
            var cari = c.Carilers.Find(cr.CariId);
            cari.CariAd = cr.CariAd;
            cari.CariSoyad = cr.CariSoyad;
            cari.Sifre = cr.Sifre;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}