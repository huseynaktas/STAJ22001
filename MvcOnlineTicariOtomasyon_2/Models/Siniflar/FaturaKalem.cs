using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon_2.Models.Siniflar
{
    public class FaturaKalem
    {
        [Key]
        public int FaturaKalemId { get; set; }


        //Fatura Kalem Açıklama Kısmı
        [Column(TypeName = "Varchar")] // Veritabanında oluşturulacak kolonun tipi ve uzunluğu belirlenir.
        [StringLength(100)] // Veritabanında oluşturulacak kolonun uzunluğu belirlenir.
        public string Aciklama { get; set; }
        public int Miktar { get; set; }
        public decimal BirimFiyat { get; set; }
        public decimal Tutar { get; set; }

        public int FaturaId { get; set; }

        //Faturalar tablosu ile ilişki
        public virtual Faturalar Faturalar { get; set; }
    }
}