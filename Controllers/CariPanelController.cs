using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5ONLINETICARIOTAMASYON.Models.Sınıflar;
using System.Web.Security;

namespace MVC5ONLINETICARIOTAMASYON.Controllers
{
    public class CariPanelController : Controller
    {
        Context c = new Context();

        public object FormsAuthenitication { get; private set; }

        // GET: CariPanel
        [Authorize]
        public ActionResult Index()
        {
            var mail = (string)Session["CariMail"];
            var degerler = c.Mesajlars.Where(x => x.Alici == mail).ToList();
            ViewBag.m = mail;
            var mailid = c.Carilers.Where(x => x.CariMail == mail).Select(y => y.CariID).FirstOrDefault();
            ViewBag.mid = mailid;
            var toplamsatis = c.SatısHareketleris.Where(x => x.CariID == mailid).Count();
            ViewBag.ts = toplamsatis;
            var toplamtutar = c.SatısHareketleris.Where(x => x.CariID == mailid).Sum(y => (decimal?)y.Toplam).ToString();
            ViewBag.tt = toplamtutar;
            var toplamurun = c.SatısHareketleris.Where(x => x.CariID == mailid).Sum(y => (decimal?)y.Toplam).ToString();
            ViewBag.tu = toplamurun;
            var adsoyad = c.Carilers.Where(x => x.CariMail == mail).Select(y => y.CariAd + " " + y.CariSoyad).FirstOrDefault();
            ViewBag.ads= adsoyad;
            var carisehir = c.Carilers.Where(x => x.CariMail == mail).Select(y => y.CariSehir).FirstOrDefault();
            ViewBag.cs = carisehir;
            
            return View(degerler);
        }
        public ActionResult Siparislerim()
        {
            var mail = (string)Session["CariMail"];
            var id = c.Carilers.Where(x => x.CariMail == mail.ToString()).Select(y => y.CariID).FirstOrDefault();
            var degerler = c.SatısHareketleris.Where(x => x.CariID == id).ToList();
            return View(degerler);


        }
        public ActionResult GelenMesajlar()
        {
            var mail = (string)Session["CariMail"];
            var mesajlar = c.Mesajlars.Where(x=>x.Alici==mail).OrderByDescending(y=>y.MesajID).ToList();
            var gelensayisi = c.Mesajlars.Count(x => x.Alici == mail);
            ViewBag.d1 = gelensayisi;
            var gidensayisi = c.Mesajlars.Count(x => x.Gönderici == mail);
            ViewBag.d2 = gidensayisi;
            return View(mesajlar);


            
        }

        public ActionResult GidenMesajlar()
        {
            var mail = (string)Session["CariMail"];
            var mesajlar = c.Mesajlars.Where(x => x.Gönderici == mail).OrderByDescending(z => z.MesajID).ToList();
            var gelensayisi = c.Mesajlars.Count(x => x.Alici == mail);
            ViewBag.d1 = gelensayisi;
            var gidensayisi = c.Mesajlars.Count(x => x.Gönderici == mail);
            ViewBag.d2 = gidensayisi;



            return View(mesajlar);



        }
        [HttpGet]
        public ActionResult YeniMesaj()
        {
            var mail = (string)Session["CariMail"];
            var gelensayisi = c.Mesajlars.Count(x => x.Alici == mail);
            ViewBag.d1 = gelensayisi;
            var gidensayisi = c.Mesajlars.Count(x => x.Gönderici == mail);
            ViewBag.d2 = gidensayisi;



            return View();
        }
        [HttpPost]
        public ActionResult YeniMesaj(Mesajlar m)
        {
            var mail = (string)Session["CariMail"];
            m.Tarih = DateTime.Parse(DateTime.Now.ToLongTimeString());
            m.Gönderici = mail;
            c.Mesajlars.Add(m);
            c.SaveChanges();
            var gelensayisi = c.Mesajlars.Count(x => x.Alici == mail);
            ViewBag.d1 = gelensayisi;
            var gidensayisi = c.Mesajlars.Count(x => x.Gönderici == mail);
            ViewBag.d2 = gidensayisi;
            return View();
        }
        public ActionResult MesajDetay(int id)
        {
            var degerler = c.Mesajlars.Where(x => x.MesajID == id).ToList();
            var mail = (string)Session["CariMail"];
            var gelensayisi = c.Mesajlars.Count(x => x.Alici == mail);
            ViewBag.d1 = gelensayisi;
            var gidensayisi = c.Mesajlars.Count(x => x.Gönderici == mail);
            ViewBag.d2 = gidensayisi;



            return View(degerler);
        }
        public ActionResult MesajDetay2(int id)
        {
            var degerler = c.Mesajlars.Where(x => x.MesajID == id).ToList();
            var mail = (string)Session["CariMail"];
            var gelensayisi = c.Mesajlars.Count(x => x.Alici == mail);
            ViewBag.d1 = gelensayisi;
            var gidensayisi = c.Mesajlars.Count(x => x.Gönderici == mail);
            ViewBag.d2 = gidensayisi;



            return View(degerler);
        }
        public ActionResult KargoTakip(string s)
        {
            var k = from x in c.kargoDetays select x;
           
                k = k.Where(y => y.TakipKodu.Contains(s));
            


            return View(k.ToList());
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");


        }
        public PartialViewResult Partial()
        {
            var mail = (string)Session["CariMail"];
            var id = c.Carilers.Where(x => x.CariMail == mail).Select(y => y.CariID).FirstOrDefault();
            var caribul = c.Carilers.Find(id);



            return PartialView("Partial",caribul);
        }
        public PartialViewResult Partial2()
        {
            var veriler = c.Mesajlars.Where(x => x.Gönderici == "admin").ToList();






            return PartialView(veriler);
        }
        public ActionResult CariBilgiGuncelle(Cariler cr)
        {
            var cari = c.Carilers.Find(cr.CariID);
            cari.CariSehir = cr.CariSehir;
            cari.CariSifre = cr.CariSifre;
            c.SaveChanges();




            return RedirectToAction("Index");
        }
        



    }

}