using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5ONLINETICARIOTAMASYON.Models.Sınıflar;

namespace MVC5ONLINETICARIOTAMASYON.Controllers
{
    public class FaturalarController : Controller
    {
        // GET: Faturalar
        Context c = new Context();
        public ActionResult Index()
        {
            var liste = c.Faturalars.Where(X=>X.Durum==true).ToList();
            
            return View(liste);
        }
        [HttpGet]
        public ActionResult FaturaEkle()
        {

            return View();
        }
        [HttpPost]
        public ActionResult FaturaEkle(Faturalar F)
        {
            F.Durum = true;
            c.Faturalars.Add(F);
            c.SaveChanges();
             return RedirectToAction("Index");





        }
        public ActionResult FaturaGetir(int id)
        {
            var fatura = c.Faturalars.Find(id);
            return View("FaturaGetir", fatura);




        }
        public ActionResult FaturaGuncelle(Faturalar f)
        {

            var fatura = c.Faturalars.Find(f.FaturaID);
            fatura.FaturaSeriNO = f.FaturaSeriNO;
            fatura.FaturaSıraNO = f.FaturaSıraNO;
            fatura.Tarih = f.Tarih;
            fatura.VergiDairesi = f.VergiDairesi;
            fatura.saat = f.saat;
            fatura.TeslimEden = f.TeslimEden;
            fatura.TeslimAlan = f.TeslimAlan;
            c.SaveChanges();
            return RedirectToAction("Index");



        } public ActionResult FaturaDetay (int id)
        {
            var fatura = c.FaturaKlaems.Where(x => x.FaturaID == id).ToList();
            var deger = c.FaturaKlaems.Where(y => y.FaturaID == id).FirstOrDefault();
            ViewBag.d1 = deger;
            return View(fatura);
            

        }
        [HttpGet]
        public ActionResult KalemEkle()
        {
            return View();


        }
        [HttpPost]
        public ActionResult KalemEkle(FaturaKlaem f)
        {
            
            c.FaturaKlaems.Add(f);
            c.SaveChanges();
            return RedirectToAction("Index");


        }
        public ActionResult Dinamik()
        {
            Class2 cs = new Class2();
            cs.deger1 = c.Faturalars.ToList();
            cs.deger2 = c.FaturaKlaems.ToList();
            return View(cs);



        }
        public ActionResult FaturaKaydet(string FaturaSeriNO, string FaturaSıraNO, DateTime Tarih, string VergiDairesi, string saat, string TeslimEden, string TeslimAlan, string ToplamTutar,FaturaKlaem[]kalemler)
        {
            Faturalar f = new Faturalar();
            f.FaturaSeriNO = FaturaSeriNO;
            f.FaturaSıraNO = FaturaSıraNO;
            f.Tarih = Tarih;
            f.VergiDairesi = VergiDairesi;
            f.saat = saat;
            f.TeslimEden = TeslimEden;
            f.TeslimAlan = TeslimAlan;
            f.ToplamTutar = decimal.Parse(ToplamTutar);
            f.Durum = true;
            c.Faturalars.Add(f);
            foreach ( var x in kalemler)
            {
                FaturaKlaem fk = new FaturaKlaem();
                fk.Aciklama = x.Aciklama;
                fk.BrimFiyat = x.BrimFiyat;
                fk.FaturaID = x.FaturaKalemID;
                fk.Miktar = x.Miktar;
                fk.Tutar = x.Tutar;
                c.FaturaKlaems.Add(fk);

            }
            c.SaveChanges();
            return Json("İşlem Başarılı", JsonRequestBehavior.AllowGet);
            


        }
       
    }
}