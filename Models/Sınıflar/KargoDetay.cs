using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC5ONLINETICARIOTAMASYON.Models.Sınıflar
{
    public class KargoDetay
    {
        [Key]
        public int KargoDetayID { get; set; }


        [Column(TypeName = "Varchar")]
        [StringLength(300)]
        public string Aciklama { get; set; }



        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string TakipKodu { get; set; }



       






        public DateTime Tarih { get; set; }

        public int PersonelID { get; set; }
        public virtual Personel Personel { get; set; } // Bir ürünün en fazla bir kategorisi olabilir

        public int CariID { get; set; }
        public virtual Cariler Cariler { get; set; } // Bir ürünün en fazla bir kategorisi olabilir
    }
}