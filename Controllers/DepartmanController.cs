using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5ONLINETICARIOTAMASYON.Models.Sınıflar;

namespace MVC5ONLINETICARIOTAMASYON.Controllers
{
    
    public class DepartmanController : Controller
    {
        // GET: Departman
        Context c = new Context();
        
        public ActionResult Index()
        {
            var degerler = c.Departmen.Where(x=>x.durum==true).ToList();
            return View(degerler);
        }

        [Authorize(Roles = "A")]
        [HttpGet]
        
        public ActionResult DepartmanEkle()
        {

            return View();



        }
        [HttpPost]
        
        public ActionResult DepartmanEkle(Departman d)
        {
            d.durum = true;
            c.Departmen.Add(d);
            c.SaveChanges();
            return RedirectToAction("Index");





        }
        public ActionResult DepartmanSil(int id)
        {
            var depart = c.Departmen.Find(id);
            depart.durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");


        }
        public ActionResult DepartmanGetir(int id)
        {
            var dpt = c.Departmen.Find(id);
            return View("DepartmanGetir", dpt);



        }
        public ActionResult DepartmanGuncelle ( Departman d)
        {
            var dept = c.Departmen.Find(d.DepartmanID);
            dept.DepartmanAdı = d.DepartmanAdı;
            c.SaveChanges();
            return RedirectToAction("Index");






        }
        public ActionResult DepartmanDetay (int id)
        {
            var degerler = c.Personels.Where(x => x.DepartmanID == id).ToList();
            var dpt = c.Departmen.Where(x => x.DepartmanID == id).Select(y => y.DepartmanAdı).FirstOrDefault();

            ViewBag.d = dpt;
            return View(degerler);

        }
        public ActionResult DepartmanPersonelSatis(int id)
        {

            var degerler = c.SatısHareketleris.Where(x => x.PersonelID == id).ToList();
            var per = c.Personels.Where(x => x.PersonelID == id).Select(y => y.PersonelAd + " " + y.PersonelSoyad).FirstOrDefault();
            var per2 = c.Personels.Where(x => x.PersonelID == id).Select(y => y.PersonelID).FirstOrDefault();
            
            ViewBag.dp = per;
            ViewBag.dp2 = per2;




            return View(degerler);
        }
        public ActionResult Index9()
        {
            return View();
        }
       
    }
}