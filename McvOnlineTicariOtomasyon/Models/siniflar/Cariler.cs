using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace McvOnlineTicariOtomasyon.Models.siniflar
{
    public class Cariler
    {
        [Key]
        [Display(Name = "Cari ID'si")]
        public int CariId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30,ErrorMessage ="En fazla 30 karakter yazabilirsiniz!")]
        [Display(Name = "Cari Soyadı")]
        public string CariSoyad { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30,ErrorMessage ="En fazla 30 karakter yazabilirsiniz!")]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz!")]
        [Display(Name = "Cari Adı")]
        public string CariAd { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(50,ErrorMessage ="En fazla 50 karakter yazabilirsiniz!")]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz!")]
        [Display(Name = "Mail")]
        public string CariMail { get; set; } 
        [Column(TypeName = "Varchar")]
        [StringLength(50,ErrorMessage ="En fazla 50 karakter yazabilirsiniz!")]
        [Display(Name = "Şehir ")]
        public string CariSehir { get; set; }
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz!")]
        public bool Durum { get; set; }
        
        [Column(TypeName = "Varchar")]
        [StringLength(16, ErrorMessage = "En fazla 16 karakter yazabilirsiniz!")]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz!")]
        public string Sifre { get; set; }
        public ICollection<SatisHareket> SatisHarekets { get; set; }

    }
}