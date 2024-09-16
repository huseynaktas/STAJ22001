using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon_2.Models.Siniflar
{
    public class Personel
    {
        [Key]
        public int PersonelId { get; set; }

        // Personel Ad Kısmı
        [Display(Name = "Personel Adı")]
        [Column(TypeName = "Varchar")] // Veritabanında oluşturulacak kolonun tipi ve uzunluğu belirlenir.
        [StringLength(30)] // Veritabanında oluşturulacak kolonun uzunluğu belirlenir.
        public string PersonelAd { get; set; }


        // Personel Soyad Kısmı
        [Display(Name = "Personel Soyadı")]
        [Column(TypeName = "Varchar")] // Veritabanında oluşturulacak kolonun tipi ve uzunluğu belirlenir.
        [StringLength(30)] // Veritabanında oluşturulacak kolonun uzunluğu belirlenir.
        public string PersonelSoyad { get; set; }


        // Personel Görsel Kısmı
        [Display(Name = "Personel Görseli")]
        [Column(TypeName = "Varchar")] // Veritabanında oluşturulacak kolonun tipi ve uzunluğu belirlenir.
        [StringLength(250)] // Veritabanında oluşturulacak kolonun uzunluğu belirlenir.
        public string PersonelGorsel { get; set; }


        //Satış Hareket tablosu ile ilişki
        public ICollection<SatisHareket> SatisHarekets { get; set; }


        public int DepartmanId { get; set; }
        //Departman tablosu ile ilişki
        public virtual Departman Departman { get; set; }
    }
}