using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5ONLINETICARIOTAMASYON.Models.Sınıflar;

namespace MVC5ONLINETICARIOTAMASYON.Controllers
{

    
    public class KargoController : Controller
    {
        Context c = new Context();
        // GET: Kargo
        public ActionResult Index(string p)
        {
            var kargolar = from x in c.kargoDetays select x;
            if (!string.IsNullOrEmpty(p))
            {
                kargolar = kargolar.Where(y => y.TakipKodu.Contains(p));
            }
            return View(kargolar.ToList());
        }
        [HttpGet]
        public ActionResult YeniKargo()
        {
            List<SelectListItem> deger1 = (from x in c.Personels.ToList()
                                           select new SelectListItem
                                           {

                                               Text = x.PersonelAd + " " +x.PersonelSoyad,
                                               Value = x.PersonelID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            List<SelectListItem> deger2 = (from x in c.Carilers.ToList()
                                           select new SelectListItem
                                           {

                                               Text = x.CariAd + " " + x.CariSoyad,
                                               Value = x.CariID.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;

            Random rnd = new Random();
            string[] karakterler = { "A", "B", "C","D" };
            int k1, k2, k3;
            k1 = rnd.Next(0, 4);
            k2 = rnd.Next(0, 4);
            k3 = rnd.Next(0, 4);
            int s1, s2, s3;
            s1 = rnd.Next(100, 1000);
            s2 = rnd.Next(10, 99);
            s3 = rnd.Next(10, 99);
            string kod = s1.ToString() + karakterler[k1] + s2.ToString() + karakterler[k2] + s3.ToString() + karakterler[k3];
            ViewBag.takipkodu = kod;

            return View();



        }
        [HttpPost]
        public ActionResult YeniKargo(KargoDetay d)
        {
            

            c.kargoDetays.Add(d);
            c.SaveChanges();
            return RedirectToAction("Index");





        }
        public ActionResult KargoDetay(string id)
        {
            var degerler = c.kargoTakips.Where(x => x.TakipKodu == id).ToList();
            
            


            return View(degerler);
        }
    }
}