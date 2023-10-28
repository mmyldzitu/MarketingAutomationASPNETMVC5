using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC5ONLINETICARIOTAMASYON.Models.Sınıflar
{
    public class Cariler
    {
        [Key]
        public int CariID { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30,ErrorMessage ="En fazla 30 karakter yazabilirsiniz!")]
        public string CariAd { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30,ErrorMessage ="En Fazla 30 karakter yazabilirisiniz!")]
        [Required(ErrorMessage ="Bu alan boş bırakılamaz!")]
        public string CariSoyad { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(13)]
        public string CariSehir { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        [Required(ErrorMessage ="Bu alan boş bırakılamaz!")]
        public string CariMail { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz!")]
        public string CariSifre { get; set; }
        public ICollection<SatısHareketleri> SatısHareketleris { get; set; }
        public ICollection<KargoDetay> KargoDetays { get; set; }
        public bool durum { get; set; }
    }
}