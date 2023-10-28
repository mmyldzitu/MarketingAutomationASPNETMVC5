using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using MVC5ONLINETICARIOTAMASYON.Models.Sınıflar;


namespace MVC5ONLINETICARIOTAMASYON.Controllers
{
    public class GrafikController : Controller
    {
        Context c = new Context();
        // GET: Grafik
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index2()
        {
            var grafikciz = new Chart(600, 600);
            grafikciz.AddTitle("Kategori-Ürün Stok Sayısı").AddLegend("Stok").AddSeries("Değerler", xValue: new[] { "Beyaz Eşya", "Bilgisayar", "Kozmetik", "Temizlik" }, yValues: new[] { 80, 1200, 142, 965 }).Write();

            return File(grafikciz.ToWebImage().GetBytes(), "image/jpeg");
        }


        /// //////////////////////////////////////////////////////////////////////////////////////////////////////////

        public ActionResult Index3()
        {
            ArrayList xvalues = new ArrayList();
            ArrayList yvalues = new ArrayList();
            var sonuclar = c.Uruns.ToList();
            sonuclar.Where(a => a.Durum == true).ToList().ForEach(x => xvalues.Add(x.UrunAd));
            sonuclar.Where(a => a.Durum == true).ToList().ForEach(y => yvalues.Add(y.Stok));
            var grafik = new Chart(width: 1000, height: 500).AddTitle("Kategorilere Göre Stoklar").AddSeries(chartType: "Column", name: "Stok", xValue: xvalues, yValues: yvalues);


            return File(grafik.ToWebImage().GetBytes(), "image/jpeg");
        }

        public ActionResult Index4()
        {



            return View();
        }
        public ActionResult VisualizeUrunResult()
        {



            return Json(urunlistesi(), JsonRequestBehavior.AllowGet);
        }
        public List<Sinif1> urunlistesi()
        {
            List<Sinif1> snf = new List<Sinif1>();
            snf.Add(new Sinif1()
            {
                urunad = "Bilgisayar",
                stok = 120



            });
            snf.Add(new Sinif1()
            {
                urunad = "Beyaz Eşya",
                stok = 150



            });
            snf.Add(new Sinif1()
            {
                urunad = "Mobilya",
                stok = 85



            });
            snf.Add(new Sinif1()
            {
                urunad = "Mobil Cihazlar",
                stok = 24



            });
            return snf;

        }
        //ÜRÜN-STOK GRAFİKLERİ
        public ActionResult Index5() {
            var cesit = new List<SelectListItem>();
            cesit.Add(new SelectListItem() { Text = "Grafik Türlerinden Birini Seçiniz..", Value = string.Empty });
            cesit.Add(new SelectListItem() { Text = "Sütun Grafiği", Value = "1" });
            cesit.Add(new SelectListItem() { Text = "Çizgi Grafiği", Value = "2" });
            cesit.Add(new SelectListItem() { Text = "Pasta Grafiği", Value = "3" });
            ViewBag.d1 = cesit;



            return View();
        }
        public ActionResult Index15()
        {
            return View();
        }
        public ActionResult Index16()
        {
            return View();
        }
        public ActionResult Index17()
        {
            return View();
        }
        public ActionResult Indexex3(int id)
        {
            if (id == 1)
            {

                return RedirectToAction("Index15");

            }
            if (id == 2)
            {

                return RedirectToAction("Index16");

            }
            if (id == 3)
            {

                return RedirectToAction("Index17");

            }
            return View();


        }

        //ÜRÜN-STOK GRAFİKLERİ
        public ActionResult VisualizeUrunResult2()
        {




            return Json(urunlistesi2(), JsonRequestBehavior.AllowGet);
        }
        public List<Sinif2> urunlistesi2()
        {
            List<Sinif2> snf = new List<Sinif2>();
            using (var c = new Context())
            {
                snf = c.Uruns.Select(x => new Sinif2
                {
                    urn = x.UrunAd,
                    stk = x.Stok
                }).ToList();

            }
            return snf;

        }
        /// Departman-personel grafikleri
        public ActionResult Index6() {
            var cesit = new List<SelectListItem>();
            cesit.Add(new SelectListItem() { Text = "Grafik Türlerinden Birini Seçiniz..", Value = string.Empty });
            cesit.Add(new SelectListItem() { Text = "Sütun Grafiği", Value = "1" });
            cesit.Add(new SelectListItem() { Text = "Çizgi Grafiği", Value = "2" });
            cesit.Add(new SelectListItem() { Text = "Pasta Grafiği", Value = "3" });
            ViewBag.d1 = cesit;



            return View();
        }
        public ActionResult Index12()
        {
            return View();
        }

        public ActionResult Index13()
        {
            return View();
        }
        public ActionResult Index14()
        {
            return View();
        }
        public ActionResult Indexex2(int id)
        {
            if (id == 1)
            {

                return RedirectToAction("Index12");

            }
            if (id == 2)
            {

                return RedirectToAction("Index13");

            }
            if (id == 3)
            {

                return RedirectToAction("Index14");

            }
            return View();


        }
        /// Departman-Personel Grafikleri

        public ActionResult VisualizeUrunResult3()
        {




            return Json(urunlistesi3(), JsonRequestBehavior.AllowGet);
        }
        public List<Sinif3> urunlistesi3()
        {
            
            List<Sinif3> snf = new List<Sinif3>();
            using (var c = new Context())
            {

                snf = (List<Sinif3>)(from x in c.Personels
                                     group x by x.Departman.DepartmanAdı into g
                                     select new Sinif3
                                     {
                                         dep = g.Key,
                                         sayi = g.Count()
                                     }).ToList();

            }
            return snf;


          
        }

        //ÜRÜN-KATEGORİ GRAFİKLERİ
        public ActionResult Index7() {
            var cesit = new List<SelectListItem>();
            cesit.Add(new SelectListItem() { Text = "Grafik Türlerinden Birini Seçiniz..", Value = string.Empty });
            cesit.Add(new SelectListItem() { Text = "Sütun Grafiği", Value = "1" });
            cesit.Add(new SelectListItem() { Text = "Çizgi Grafiği", Value = "2" });
            cesit.Add(new SelectListItem() { Text = "Pasta Grafiği", Value = "3" });
            ViewBag.d1 = cesit;



            return View();
        }
        public ActionResult Index18()
        {

            return View();
        }
        public ActionResult Index19()
        {

            return View();
        }
        public ActionResult Index20()
        {

            return View();
        }
        public ActionResult Indexex4(int id)
        {
            if (id == 1)
            {

                return RedirectToAction("Index18");

            }
            if (id == 2)
            {

                return RedirectToAction("Index19");

            }
            if (id == 3)
            {

                return RedirectToAction("Index20");

            }
            return View();


        }
        //ÜRÜN KATEGORİ GRAFİKLERİ
        public ActionResult VisualizeUrunResult4()
        {




            return Json(urunlistesi4(), JsonRequestBehavior.AllowGet);
        }
        public List<Sinif4> urunlistesi4()
        {

            List<Sinif4> snf = new List<Sinif4>();
            using (var c = new Context())
            {

                snf = (List<Sinif4>)(from x in c.Uruns
                                     group x by x.Kategori.KategoriAD into g
                                     select new Sinif4
                                     {
                                         kat = g.Key,
                                         sayi = g.Count()
                                     }).ToList();

            }
            return snf;



        }
        [HttpGet]

        ///MÜŞTERİ-ŞEHİR GRAFİKLERİ
        public ActionResult Index8() {

            var cesit = new List<SelectListItem>();
            cesit.Add(new SelectListItem() { Text = "Grafik Türlerinden Birini Seçiniz..", Value = string.Empty });
            cesit.Add(new SelectListItem() { Text = "Sütun Grafiği", Value = "1" });
            cesit.Add(new SelectListItem() { Text = "Çizgi Grafiği", Value = "2" });
            cesit.Add(new SelectListItem() { Text = "Pasta Grafiği", Value = "3" });
            ViewBag.d1 = cesit;



            return View(); }
        public ActionResult VisualizeUrunResult5()
        {




            return Json(urunlistesi5(), JsonRequestBehavior.AllowGet);
        }
        public List<Sinif5> urunlistesi5()
        {

            List<Sinif5> snf = new List<Sinif5>();
            using (var c = new Context())
            {

                snf = (List<Sinif5>)(from x in c.Carilers
                                     group x by x.CariSehir into g
                                     select new Sinif5
                                     {
                                         seh = g.Key,
                                         sayi = g.Count()
                                     }).ToList();

            }
            return snf;



        }
        
        public ActionResult Indexex(int id)
        {
            if (id == 1)
            {

                return RedirectToAction("Index9");

            }
            if (id == 2)
            {

                return RedirectToAction("Index10");

            }
            if (id == 3)
            {

                return RedirectToAction("Index11");

            }
            return View();

            
        }

        public ActionResult Index9()
        {


            return View();
        }

        public ActionResult Index10()
        {


            return View();
        }
        public ActionResult Index11()
        {


            return View();
        }
        /// MÜŞTERİ-ŞEHİR GRAFİKLERİ
    }
}