using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using MVC5ONLINETICARIOTAMASYON.Models.Sınıflar;

namespace MVC5ONLINETICARIOTAMASYON.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Personels.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult PersonelEkle()
        {
           
            List<SelectListItem> deger1 = (from x in c.Departmen.Where(x => x.durum == true).ToList()
                                           select new SelectListItem
                                           {

                                               Text = x.DepartmanAdı,
                                               Value = x.DepartmanID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;



            return View();
        }
        [HttpPost]
        public ActionResult PersonelEkle(Personel p)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/image/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.PersonelGorsel = "/image/" + dosyaadi + uzanti;
            }


            c.Personels.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelGetir(int id)
        {
            
            List<SelectListItem> deger1 = (from x in c.Departmen.Where(x => x.durum == true).ToList()
                                           select new SelectListItem
                                           {

                                               Text = x.DepartmanAdı,
                                               Value = x.DepartmanID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            var per = c.Personels.Find(id);
            return View("PersonelGetir",per);






        }
        public ActionResult PersonelGuncelle(Personel p)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/image/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.PersonelGorsel = "/image/" + dosyaadi + uzanti;
            }
            if (!ModelState.IsValid)
            {

                List<SelectListItem> deger1 = (from x in c.Departmen.Where(x => x.durum == true).ToList()
                                               select new SelectListItem
                                               {

                                                   Text = x.DepartmanAdı,
                                                   Value = x.DepartmanID.ToString()
                                               }).ToList();
                ViewBag.dgr1 = deger1;
                return View("PersonelGetir");
            }
            var pers = c.Personels.Find(p.PersonelID);
            pers.PersonelAd = p.PersonelAd;
            pers.PersonelSoyad = p.PersonelSoyad;
            pers.PersonelGorsel = p.PersonelGorsel;
            pers.hakkinda = p.hakkinda;
            pers.adres = p.adres;
            pers.telefon = p.telefon;
            pers.DepartmanID = p.DepartmanID;

            
            c.SaveChanges();
            return RedirectToAction("Index");
        }



        public ActionResult PersonelYazdir()
        {
            var degerler = c.Personels.ToList();
            return View(degerler);

        }
        public ActionResult PersonelYazdir2(int id)
        {

            var deger = c.SatısHareketleris.Where(x=>x.PersonelID==id).ToList();
            return View(deger);




        }
        public ActionResult PersonelYazdir3 (int id)
        {
            var deger = c.SatısHareketleris.Where(x => x.HareketID == id).ToList();
            return View(deger);



        }
        public ActionResult PersonelListe()
        {
            var sorgu = c.Personels.ToList();
            

            return View(sorgu);
        }
            

    }
}