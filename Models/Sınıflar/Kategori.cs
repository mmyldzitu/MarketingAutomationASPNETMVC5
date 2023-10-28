using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC5ONLINETICARIOTAMASYON.Models.Sınıflar
{
    public class Kategori
    {
        [Key]
        public int KategoriID { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string KategoriAD { get; set; }
        // her bir kategoıride birden fazla ürün vardır
        public ICollection<Urun> Uruns  { get; set; }
    }
}