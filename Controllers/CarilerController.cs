using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5ONLINETICARIOTAMASYON.Models.Sınıflar;
namespace MVC5ONLINETICARIOTAMASYON.Controllers
{
    public class CarilerController : Controller
    {
        // GET: Cariler
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Carilers.Where(x=>x.durum==true).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult CariEkle()
        {






            return View();

        }
        [HttpPost]
        public ActionResult CariEkle(Cariler p)
        {
            p.durum = true;
            c.Carilers.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");





        }
        public ActionResult CariSil(int id)
        {
            var cari = c.Carilers.Find(id);
            cari.durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");


        }
        public ActionResult CariGetir(int id)
        {
            var cari = c.Carilers.Find(id);
            return View("CariGetir", cari);



        }
        public ActionResult CariGuncelle (Cariler p)
        {
            if(!ModelState.IsValid)
            {
                return View("CariGetir");
            }
            var cari = c.Carilers.Find(p.CariID);
            cari.CariAd = p.CariAd;
            cari.CariSoyad = p.CariSoyad;
            cari.CariSehir = p.CariSehir;
            cari.CariMail = p.CariMail;
            c.SaveChanges();
            return RedirectToAction("Index");




        }
        public ActionResult CariDetay(int id)
        {
            var deger = c.SatısHareketleris.Where(x => x.CariID == id).ToList();
            var cmt = c.Carilers.Where(x =>x.CariID == id).Select(y => y.CariAd + " " + y.CariSoyad).FirstOrDefault();
            var deger2 = c.SatısHareketleris.Where(x => x.CariID == id).Select(y => y.CariID).FirstOrDefault();
            ViewBag.d1 = deger2;
            ViewBag.cm = cmt;
            return View(deger);


        }
        public ActionResult CariYazdir()
        {
            var degerler = c.Carilers.Where(x => x.durum == true).ToList();
            return View(degerler);



        }
        public ActionResult CariYazdir2(int id)
        {
            var deger = c.SatısHareketleris.Where(x => x.CariID == id).ToList();
            
            return View(deger);




        }
        public ActionResult CariYazdir3(int id)
        {
            var deger = c.SatısHareketleris.Where(x => x.HareketID == id).ToList();
            return View(deger);



        }
    }
}