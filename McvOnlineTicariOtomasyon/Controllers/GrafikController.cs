using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using McvOnlineTicariOtomasyon.Models.siniflar;


public class GrafikController : Controller
{
    // GET: Grafik
    Context c = new Context();
    public ActionResult Index3()
    {
        ArrayList xvalue = new ArrayList();
        ArrayList yvalue = new ArrayList();
        var sonuclar = c.Uruns.ToList();
        sonuclar.ToList().ForEach(x => xvalue.Add(x.UrunAd));
        sonuclar.ToList().ForEach(y => yvalue.Add(y.Stok));
        var grafik = new Chart(width: 500, height: 500).AddTitle("Stoklar").AddSeries(chartType: "Pie", name: "Stok", xValue: xvalue, yValues: yvalue);
        return File(grafik.ToWebImage().GetBytes(), "image/jpg");
    }
    public ActionResult Index4()
    {
        return View();
    }
    [HttpPost]
    public ActionResult VisualizeUrunResult()
    {
        return Json(UrunListesi(), JsonRequestBehavior.AllowGet);
    }
    public List<sınıf1> UrunListesi()
    {
        List<sınıf1> snf = new List<sınıf1>();
        snf.Add(new sınıf1()
        {
            urunad = "Bilgisayar",
            Stok = 120
        });
        snf.Add(new sınıf1()
        {
            urunad = "Beyaz Eşya",
            Stok = 150
        });
        snf.Add(new sınıf1()
        {
            urunad = "Küçük Ev Aletleri",
            Stok = 170
        });
        snf.Add(new sınıf1()
        {
            urunad = "Mobil Cihazlar",
            Stok = 70
        });
        snf.Add(new sınıf1()
        {
            urunad = "Mobilya",
            Stok = 0
        });
        return snf;

    }
    public ActionResult Index5()
    {
        return View();
    }
    public ActionResult VisualizeUrunResult2()
    {
        return Json(UrunListesi2(), JsonRequestBehavior.AllowGet);
    }
    public List<sınıf2>UrunListesi2()
    {
        List<sınıf2> snf = new List<sınıf2>();
        using(var c = new Context())
        {
            snf = c.Uruns.Select(x => new sınıf2
            {
                urn = x.UrunAd,
                Stk = x.Stok
            }).ToList();
        }
        return snf;
    }
}
