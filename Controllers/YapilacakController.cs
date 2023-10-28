using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5ONLINETICARIOTAMASYON.Models.Sınıflar;

namespace MVC5ONLINETICARIOTAMASYON.Controllers
{
    public class YapilacakController : Controller
    {
        // GET: Yapilacak
        Context c = new Context();
        public ActionResult Index()
        {
            var deger1 = c.Carilers.Where(x => x.durum == true).Count().ToString();
            ViewBag.d1 = deger1;
            var deger2 = c.Uruns.Where(x => x.Durum == true).Count().ToString();
            ViewBag.d2 = deger2;
            var deger3 = c.Kategoris.Count().ToString();
            ViewBag.d3 = deger3;
            var deger4 = (from x in c.Carilers select x.CariSehir).Distinct().Count().ToString();
            ViewBag.d4 = deger4;
            var yapilacak = c.Yapilacaks.ToList();
            return View(yapilacak);
        }
    }
}