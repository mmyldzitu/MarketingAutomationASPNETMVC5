using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC5ONLINETICARIOTAMASYON.Models.Sınıflar
{
    public class Personel
    {
        [Key]
        public int PersonelID { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30,ErrorMessage = "En fazla 30 karakter yazabilirsiniz!")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz!")]
        public string PersonelAd { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "En Fazla 30 karakter yazabilirisiniz!")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz!")]
        public string PersonelSoyad { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(500)]
        public string PersonelGorsel { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(200)]
        public string hakkinda { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string adres { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(13)]
        public string telefon { get; set; }
        public ICollection<SatısHareketleri> SatısHareketleris { get; set; }
        public int DepartmanID { get; set; }
        public virtual Departman Departman { get; set; }
        public ICollection<KargoDetay> KargoDetays { get; set; }

    }
}