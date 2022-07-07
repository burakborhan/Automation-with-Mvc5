using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace McvOnlineTicariOtomasyon.Models.siniflar
{
    public class Personel
    {
        [Key]

        public int PersonelId { get; set; }
        [Display(Name = "Personel Adı")]
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string PersonelAd { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "En fazla 30 karakter yazabilirsiniz!")]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz!")]
        [Display(Name = "Personel Soyadı")]
        public string PersonelSoyad { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(250, ErrorMessage = "En fazla 250 karakter yazabilirsiniz!")]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz!")]

        [Display(Name = "Personel Görseli")]
        public string PersonelGorsel { get; set; }
        public ICollection<SatisHareket> SatisHarekets { get; set; }
        public int Departmanid { get; set; }
        public virtual Departman Departman { get; set; }
    }
}