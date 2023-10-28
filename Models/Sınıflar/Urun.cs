using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC5ONLINETICARIOTAMASYON.Models.Sınıflar
{
    public class Urun
    {
        [Key]
        public int UrunID { get; set; }
        [Column(TypeName="Varchar")]
        [StringLength(30)]
        public string UrunAd { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Marka { get; set; }
        public short Stok { get; set; }
        public decimal AlisFiyat { get; set; } 
        public decimal SatisFiyat { get; set; }
        public bool Durum { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(500)]
        public string UrunGorsel { get; set; }
        public int KategoriID { get; set; }
        public virtual Kategori Kategori { get; set; } // Bir ürünün en fazla bir kategorisi olabilir
        public ICollection<SatısHareketleri> SatısHareketleris { get; set; }

    }
}