using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5ONLINETICARIOTAMASYON.Models.Sınıflar;
namespace MVC5ONLINETICARIOTAMASYON.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.SatısHareketleris.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniSatis()
        {
            List<SelectListItem> deger1 = (from x in c.Uruns.Where(x => x.Durum == true).ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.UrunAd,
                                               Value = x.UrunID.ToString()


                                           }
                                           ).ToList();
            ViewBag.dg1 = deger1;
            List<SelectListItem> deger2 = (from x in c.Carilers.Where(x => x.durum == true).ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CariAd + " " + x.CariSoyad,
                                               Value = x.CariID.ToString()


                                           }
                                          ).ToList();
            ViewBag.dg2 = deger2;
            List<SelectListItem> deger3 = (from x in c.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelAd + " " + x.PersonelSoyad,
                                               Value = x.PersonelID.ToString()


                                           }
                                           ).ToList();


            ViewBag.dg3 = deger3;


            return View();
        }

        [HttpPost]
        public ActionResult YeniSatis(SatısHareketleri s)
        {
            s.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.SatısHareketleris.Add(s);
            c.SaveChanges();
            return RedirectToAction("Index");




        }
        public ActionResult SatisGetir(int id)
        {

            var degers = c.SatısHareketleris.Find(id);

            List<SelectListItem> deger1 = (from x in c.Uruns.Where(x => x.Durum == true).ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.UrunAd,
                                               Value = x.UrunID.ToString()


                                           }
                                          ).ToList();
            ViewBag.dg1 = deger1;
            List<SelectListItem> deger2 = (from x in c.Carilers.Where(x => x.durum == true).ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CariAd + " " + x.CariSoyad,
                                               Value = x.CariID.ToString()


                                           }
                                          ).ToList();
            ViewBag.dg2 = deger2;
            List<SelectListItem> deger3 = (from x in c.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelAd + " " + x.PersonelSoyad,
                                               Value = x.PersonelID.ToString()


                                           }
                                           ).ToList();
            ViewBag.dg3 = deger3;
            var deger4 = c.SatısHareketleris.Find(id);
            ViewBag.dt = deger4.Adet;
            ViewBag.dt1 = deger4.Urun.SatisFiyat;
            ViewBag.dt2 = deger4.Urun.Stok;
            ViewBag.dt3 = Convert.ToInt32( deger4.Toplam);




            return View("SatisGetir", degers);


        }
        public ActionResult SatisGuncelle(SatısHareketleri s)
        {
            var hareket = c.SatısHareketleris.Find(s.HareketID);
            hareket.CariID = s.CariID;
            hareket.Adet = s.Adet;
            hareket.Fiyat = s.Fiyat;
            hareket.Toplam = s.Toplam;
            hareket.PersonelID = s.PersonelID;
            hareket.UrunID = s.UrunID;
            hareket.Tarih = s.Tarih;
            c.SaveChanges();
            return RedirectToAction("Index");







        }

        public ActionResult SatisDetay(int id)
        {
            var degerler = c.SatısHareketleris.Where(x => x.HareketID == id).ToList();
            return View(degerler);






        }
        public ActionResult SatisYazdir(int id)

        {
             var deger = c.SatısHareketleris.Where(x => x.HareketID == id).ToList();
            return View(deger);

        }
        public ActionResult SatisYazdir2()
        {
            var degerler = c.SatısHareketleris.ToList();
            return View(degerler);


        }
    }
}