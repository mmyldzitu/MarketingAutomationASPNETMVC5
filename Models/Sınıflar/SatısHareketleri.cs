using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5ONLINETICARIOTAMASYON.Models.Sınıflar
{
    public class SatısHareketleri
    { [Key]
        public int HareketID { get; set; }
        //ürün  
        //cari
        //personel
        public DateTime Tarih { get; set; }
        public int Adet { get; set; }
        public decimal Fiyat { get; set; }
        public decimal Toplam { get; set; }
        public int UrunID { get; set; }
        public int PersonelID { get; set; }
        
        public int CariID { get; set; }
        public virtual Urun Urun { get; set; }
        public  virtual Personel Personel { get; set; }
        public virtual Cariler Cariler { get; set; }
        

    }
}