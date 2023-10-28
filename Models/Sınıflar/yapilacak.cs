using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC5ONLINETICARIOTAMASYON.Models.Sınıflar
{
    public class yapilacak
    {
        [Key]
        public int yapilacakid { get; set; }
        
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string baslik { get; set; }

        [Column(TypeName = "bit")]
        public bool durum { get; set; }
        
    }
}