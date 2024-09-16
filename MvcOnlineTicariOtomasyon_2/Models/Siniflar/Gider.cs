using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon_2.Models.Siniflar
{
    public class Gider
    {
        [Key]
        public int GiderId { get; set; }


        //Gider Açıklama Kısmı
        [Column(TypeName = "Varchar")] // Veritabanında oluşturulacak kolonun tipi ve uzunluğu belirlenir.
        [StringLength(100)] // Veritabanında oluşturulacak kolonun uzunluğu belirlenir.
        public string Aciklama { get; set; }

        public DateTime Tarih { get; set; }

        public decimal Tutar { get; set; }
    }
}