using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5ONLINETICARIOTAMASYON.Models.Sınıflar;
namespace MVC5ONLINETICARIOTAMASYON.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        Context c = new Context();
        public ActionResult Index(string p)


        {
            var urunler = (from x in c.Uruns.Where(t=>t.Durum==true) select x);
            if (!string.IsNullOrEmpty(p))
            {
                urunler = urunler.Where(y => y.UrunAd.Contains(p));
            }
            return View(urunler.ToList());
        }
        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> deger1 = (from x in c.Kategoris.ToList()
                                           select new SelectListItem
                                           {

                                               Text = x.KategoriAD,
                                               Value = x.KategoriID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            return View();
        }
        [HttpPost]
        public ActionResult YeniUrun(Urun p)
        {
            p.Durum = true;
            c.Uruns.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");



        }
        public ActionResult UrunSil(int id)
        {
            var urun = c.Uruns.Find(id);
            urun.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");




        }
        public ActionResult UrunGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Kategoris.ToList()
                                           select new SelectListItem
                                           {

                                               Text = x.KategoriAD,
                                               Value = x.KategoriID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            var urun = c.Uruns.Find(id);
            return View("UrunGetir", urun);

        }
        public ActionResult UrunGuncelle(Urun p)
        {
            var urn = c.Uruns.Find(p.UrunID);
            urn.AlisFiyat = p.AlisFiyat;
            urn.Durum = p.Durum;
            urn.SatisFiyat = p.SatisFiyat;
            urn.KategoriID = p.KategoriID;
            urn.Marka = p.Marka;
            urn.Stok = p.Stok;
            urn.UrunAd = p.UrunAd;
            urn.UrunGorsel = p.UrunGorsel;
            c.SaveChanges();
            return RedirectToAction("Index");



        }
        public ActionResult UrunYazdir()
        {
            var deger = c.Uruns.ToList();
            return View(deger);

        }
        [HttpGet]
        public ActionResult SatisYap(int id) {
            List<SelectListItem> deger = (from x in c.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelAd + " " + x.PersonelSoyad,
                                               Value = x.PersonelID.ToString()


                                           }
                                           ).ToList();
            ViewBag.dg = deger;
            var deger1 = c.Uruns.Find(id);
            
            ViewBag.dg1 = deger1.UrunID;
            ViewBag.dg2 = deger1.SatisFiyat;
            ViewBag.dg3 = deger1.Stok;
            return View();
        }
        [HttpPost]
        public ActionResult SatisYap(SatısHareketleri s)
        {
            s.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.SatısHareketleris.Add(s);
            c.SaveChanges();
            return RedirectToAction("Index","Satis");
            
        }


    }
}