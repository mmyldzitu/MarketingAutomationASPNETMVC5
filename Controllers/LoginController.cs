using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MVC5ONLINETICARIOTAMASYON.Models.Sınıflar;

namespace MVC5ONLINETICARIOTAMASYON.Controllers
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
        [HttpGet]
        public PartialViewResult Partial1()
        {


            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Partial1(Cariler p)
        {
            var deger = p.CariMail;
            var deger2 = c.Carilers.Count(x => x.CariMail == deger);

            if (deger2!=0)
            {
                return PartialView();
            }
            
            p.durum = true;
            c.Carilers.Add(p);

            c.SaveChanges();

            return PartialView();


        }

        [HttpGet]
        public ActionResult CariLogin1()
        {



            return View();
        }
        [HttpPost]
        public ActionResult CariLogin1(Cariler p)
        {
            var bilgiler = c.Carilers.FirstOrDefault(x => x.CariMail == p.CariMail && x.CariSifre == p.CariSifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.CariMail, false);
                Session["CariMail"] = bilgiler.CariMail.ToString();
                return RedirectToAction("Index", "CariPanel");
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
        [HttpPost]
        public ActionResult AdminLogin(Admin p)
        {
            var bilgiler = c.Admins.FirstOrDefault(x => x.KullaniciAdı == p.KullaniciAdı && x.Sifre == p.Sifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.KullaniciAdı, false);
                Session["KullaniciAdı"] = bilgiler.KullaniciAdı.ToString();
                return RedirectToAction("Index", "Kategori");

            }
            else
            {
                return RedirectToAction("Index", "Login");
            }


        }

    }
}