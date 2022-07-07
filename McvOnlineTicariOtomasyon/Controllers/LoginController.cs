using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using McvOnlineTicariOtomasyon.Models.siniflar;

namespace McvOnlineTicariOtomasyon.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult Partial1()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Partial1(Cariler p)
        {
            c.Carilers.Add(p);
            c.SaveChanges();
            return PartialView();
        }
        public ActionResult CariLogin1()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CariLogin1(Cariler ca)
        {
            var bilgiler = c.Carilers.FirstOrDefault(x => x.CariMail == ca.CariMail && x.Sifre == ca.Sifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.CariMail, false);
                Session["CariMail"] = bilgiler.CariMail.ToString();
                return RedirectToAction("Index", "CariPanelim");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }
        
        public ActionResult AdminLogin(Admin p)
        {
            var bilgiler = c.Admins.FirstOrDefault(x => x.KullanıcıAd == p.KullanıcıAd && x.Sifre == p.Sifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.KullanıcıAd, false);
                Session["KullanıcıAd"] = bilgiler.KullanıcıAd.ToString();
                return RedirectToAction("Index", "Kategori");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
    }
}