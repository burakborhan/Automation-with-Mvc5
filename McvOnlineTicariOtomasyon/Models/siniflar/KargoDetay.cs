﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace McvOnlineTicariOtomasyon.Models.siniflar
{
    public class KargoDetay
    {
        [Key]
        public int KargoDetayid { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(500)]
        public string Aciklama { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(10)]
        public string TakipKodu { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(20)]
        public string Personel { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(20)]
        public string Alıcı { get; set; }
        public DateTime Tarih { get; set; }
    }
}