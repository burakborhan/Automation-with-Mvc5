using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace McvOnlineTicariOtomasyon.Models.siniflar
{
    public class Mesajlar
    {
        [Key]
        public int MesajId { get; set; }
        [Column(TypeName = "nvarchar")]
        [StringLength(50)]
        public string Gönderici { get; set; }
        [Column(TypeName = "nvarchar")]
        [StringLength(50)]
        public string Alıcı { get; set; }
        [Column(TypeName = "nvarchar")]
        [StringLength(50)]
        public string Konu { get; set; }
        [Column(TypeName = "nvarchar")]
        [StringLength(2000)]
        public string İçerik { get; set; }
        [Column(TypeName = "Smalldatetime")]
        public DateTime Tarih { get; set; }
    }
}