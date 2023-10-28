using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC5ONLINETICARIOTAMASYON.Models.Sınıflar
{
    public class Faturalar
    {
        [Key]

        public int FaturaID { get; set; }
        [Column(TypeName = "Char")]
        [StringLength(1)]
        public string FaturaSeriNO { set; get; }
        [Column(TypeName = "Varchar")]
        [StringLength(6)]
        public string FaturaSıraNO { set; get; }
        public DateTime Tarih { set; get; }
        [Column(TypeName = "Varchar")]
        [StringLength(60)]
        public string VergiDairesi { set; get; }
        [Column(TypeName = "Char")]
        [StringLength(5)]
        public string saat { get; set; }
        public decimal ToplamTutar { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string TeslimEden { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string TeslimAlan { get; set; }
        public bool Durum { get; set; }
        public ICollection<FaturaKlaem> FaturaKlaems { get; set; }
    }
}