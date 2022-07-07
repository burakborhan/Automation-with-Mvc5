using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace McvOnlineTicariOtomasyon.Models.siniflar
{
    public class urun
    {
        [Key]
        [Display(Name = "Ürün ID'si")]
        public int UrunId { get; set; }
        [Column(TypeName ="Varchar")]
        [StringLength(30)]
        [Display(Name = "Ürün Adı")]
        public string UrunAd { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Marka { get; set; }
        public short Stok { get; set; }
        [Display(Name = "Alış Fiyatı")]
        public decimal AlısFiyat { get; set; }
        [Display(Name = "Satış Fiyatı")]
        public decimal SatisFiyat { get; set; }
        public bool Durum { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        [Display(Name = "Ürün Görseli")]
        public string UrunGorsel { set; get; }
        [Display(Name = "Kategori")]
        public int KategoriID { get; set; }
        public virtual Kategori Kategori { get; set; }
        public ICollection<SatisHareket> SatisHarekets { get; set; }

    }
}