using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5ONLINETICARIOTAMASYON.Models.Sınıflar;

namespace MVC5ONLINETICARIOTAMASYON.Controllers
{
    public class İstatistikController : Controller
    {
        // GET: İstatistik
        Context c = new Context();
        public ActionResult Index()
        {
            var deger1 = c.Carilers.Where(x => x.durum == true).Count().ToString();
            ViewBag.d1 = deger1;
            var deger2 = c.Uruns.Where(x => x.Durum == true).Count().ToString();
            ViewBag.d2 = deger2;
            var deger3 = c.Personels.Count().ToString();
            ViewBag.d3 = deger3;
            var deger4 = c.Kategoris.Count().ToString();
            ViewBag.d4 = deger4;
            var deger5 = c.Uruns.Where(y => y.Durum == true).Sum(x => x.Stok).ToString();
            ViewBag.d5 = deger5;
            var deger6 = (from x in c.Uruns select x.Marka).Distinct().Count().ToString();
            ViewBag.d6 = deger6;
            var deger7 = c.Uruns.Where(y => y.Durum == true).Count(x => x.Stok <= 10).ToString();
            ViewBag.d7 = deger7;
            var deger8 = (from x in c.Uruns.Where(z => z.Durum == true) orderby x.SatisFiyat descending select x.UrunAd).FirstOrDefault();
            ViewBag.d8 = deger8;
            var deger9 = (from x in c.Uruns.Where(z => z.Durum == true) orderby x.SatisFiyat ascending select x.UrunAd).FirstOrDefault();
            ViewBag.d9 = deger9;
            var deger10 = c.Uruns.GroupBy(x => x.Marka).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault();
            ViewBag.d10 = deger10;
            var deger11 = c.Uruns.Where(z => z.Durum == true).Where(x => x.UrunAd == "Buzdolabı").Sum(y => y.Stok);
            ViewBag.d11 = deger11;
            var deger12 = c.Uruns.Where(z => z.Durum == true).Where(x => x.UrunAd == "LAPTOP").Sum(y => y.Stok);
            ViewBag.d12 = deger12;
            var deger13 = c.Uruns.Where(u => u.UrunID == c.SatısHareketleris.GroupBy(x => x.UrunID).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault())
                .Select(h => h.UrunAd).FirstOrDefault();
            ViewBag.d13 = deger13;
            var deger14 = c.SatısHareketleris.Sum(x => x.Toplam).ToString();
            ViewBag.d14 = deger14;
            DateTime bugün = DateTime.Today;
            var deger15 = c.SatısHareketleris.Count(x => x.Tarih == bugün).ToString();
            ViewBag.d15 = deger15;
            var deger16 = c.SatısHareketleris.Where(x => x.Tarih == bugün).Sum(y => (decimal?)y.Toplam).ToString();
            ViewBag.d16 = deger16;
            return View();
        }
        public ActionResult KolayTablolar()
        {
            var sorgu = from x in c.Carilers
                        group x by x.CariSehir into g
                        select new GroupSinif
                        {
                            sehir = g.Key,
                            sayi = g.Count()
                        };


            
            return View(sorgu.ToList());

        }
        public PartialViewResult Partial1()
        {
            var sorgu2 = from x in c.Personels
                         group x by x.Departman.DepartmanAdı into g
                         select new GroupSinif2
                         {
                             Departman = g.Key,
                             sayi = g.Count()
                         };


            return PartialView(sorgu2.ToList());
        }
        public PartialViewResult Partial2()
        {
            var sorgu = c.Carilers.ToList();


            return PartialView(sorgu);
        }
        public PartialViewResult Partial3()
        {
            var sorgu = c.Uruns.ToList();

            return PartialView(sorgu);

        }
        public PartialViewResult Partial4()
        {


            var sorgu2 = from x in c.Uruns
                         group x by x.Marka into g
                         select new GroupSinif3
                         {
                             marka = g.Key,
                             sayi = g.Count()
                         };
            return PartialView(sorgu2.ToList());
        }
    }
}