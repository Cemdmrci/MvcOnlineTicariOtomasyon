using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Sınıflar
{
    public class Mesaj
    {
        [Key]
        public int MesajId { get; set; }

        [Display(Name = "Gönderici")]
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Gonderici { get; set; }

        [Display(Name = "Alıcı")]
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Alici { get; set; }

        [Display(Name = "Konu")]
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Konu { get; set; }

        [Display(Name = "İçerik")]
        [Column(TypeName = "Varchar")]
        [StringLength(2000)]
        public string Icerik { get; set; }

        [Display(Name = "Tarih")]
        [Column(TypeName = "Smalldatetime")]
        public DateTime Tarih { get; set; }
    }
}