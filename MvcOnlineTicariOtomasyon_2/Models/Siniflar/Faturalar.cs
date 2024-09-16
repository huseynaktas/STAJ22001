using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon_2.Models.Siniflar
{
    public class Faturalar
    {
        [Key]
        public int FaturaID { get; set; }

        //Fatura Seri No Kısmı
        [Column(TypeName = "Char")] // Veritabanında oluşturulacak kolonun tipi ve uzunluğu belirlenir.
        [StringLength(1)] // Veritabanında oluşturulacak kolonun uzunluğu belirlenir.
        public string FaturaSeriNo { get; set; }


        //Fatura Sıra No Kısmı
        [Column(TypeName = "Varchar")] // Veritabanında oluşturulacak kolonun tipi ve uzunluğu belirlenir.
        [StringLength(6)] // Veritabanında oluşturulacak kolonun uzunluğu belirlenir.
        public string FaturaSiraNo { get; set; }

        public DateTime Tarih { get; set; }


        //Vergi Dairesi Kısmı
        [Column(TypeName = "Varchar")] // Veritabanında oluşturulacak kolonun tipi ve uzunluğu belirlenir.
        [StringLength(60)] // Veritabanında oluşturulacak kolonun uzunluğu belirlenir.
        public string VergiDairesi { get; set; }

        [Column(TypeName = "char")]
        [StringLength(6)]
        public string Saat { get; set; }


        //Teslim Eden Kısmı
        [Column(TypeName = "Varchar")] // Veritabanında oluşturulacak kolonun tipi ve uzunluğu belirlenir.
        [StringLength(30)] // Veritabanında oluşturulacak kolonun uzunluğu belirlenir.
        public string TeslimEden { get; set; }


        //Teslim Alan Kısmı
        [Column(TypeName = "Varchar")] // Veritabanında oluşturulacak kolonun tipi ve uzunluğu belirlenir.
        [StringLength(30)] // Veritabanında oluşturulacak kolonun uzunluğu belirlenir.
        public string TeslimAlan { get; set; }

        public decimal Toplam { get; set; }


        //Fatura Kalem tablosu ile ilişki
        public ICollection<FaturaKalem> FaturaKalems { get; set; }
    }
}