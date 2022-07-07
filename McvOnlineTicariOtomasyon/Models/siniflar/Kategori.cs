using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace McvOnlineTicariOtomasyon.Models.siniflar
{
    public class Kategori
    {
        [Key]
        public int KategoriId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string KategoriAd { get; set; }
        public ICollection<urun> uruns { get; set; }


    }
}