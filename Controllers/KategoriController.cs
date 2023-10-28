using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5ONLINETICARIOTAMASYON.Models.Sınıflar;
using PagedList;
using PagedList.Mvc;

namespace MVC5ONLINETICARIOTAMASYON.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori



        Context c = new Context();
        public ActionResult Index(int sayfa=1)

        {
            var degerler = c.Kategoris.ToList().ToPagedList(sayfa, 4);


            return View(degerler);
        }
        [HttpGet]
        public ActionResult KategoriEkle()
        {




            return View();
        }
        [HttpPost]
        public ActionResult KategoriEkle( Kategori k)
        {
            c.Kategoris.Add(k);
            c.SaveChanges();




            return RedirectToAction("Index");
        }
        public ActionResult KategoriSil(int id)
        {
            var kate = c.Kategoris.Find(id);
            c.Kategoris.Remove(kate);
            c.SaveChanges();
            return RedirectToAction("Index");



        }
        public ActionResult KategoriGetir(int id)
        {
            var kate = c.Kategoris.Find(id);
            return View("KategoriGetir", kate);



        }
        public ActionResult KategoriGuncelle(Kategori k)
        {
            var kate = c.Kategoris.Find(k.KategoriID);
            kate.KategoriAD = k.KategoriAD;
            c.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}