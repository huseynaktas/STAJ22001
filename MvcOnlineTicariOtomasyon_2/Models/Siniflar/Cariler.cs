using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon_2.Models.Siniflar
{
    public class Cariler
    {
        [Key]
        public int CariId { get; set; }


        //Cari Ad Kısmı
        [Column(TypeName = "Varchar")] // Veritabanında oluşturulacak kolonun tipi ve uzunluğu belirlenir.
        [StringLength(30, ErrorMessage = "En fazla 30 karakter yazabilirsiniz!")] // Veritabanında oluşturulacak kolonun uzunluğu belirlenir.
        public string CariAd { get; set; }


        //Cari Soyad Kısmı
        [Column(TypeName = "Varchar")] // Veritabanında oluşturulacak kolonun tipi ve uzunluğu belirlenir.
        [StringLength(30)] // Veritabanında oluşturulacak kolonun uzunluğu belirlenir.
        [Required(ErrorMessage ="Bu alanı boş geçemezsiniz!")]
        public string CariSoyad { get; set; }


        //Cari Şehir Kısmı
        [Column(TypeName = "Varchar")] // Veritabanında oluşturulacak kolonun tipi ve uzunluğu belirlenir.
        [StringLength(15)] // Veritabanında oluşturulacak kolonun uzunluğu belirlenir.
        public string CariSehir { get; set; }


        //Cari Mail Kısmı
        [Column(TypeName = "Varchar")] // Veritabanında oluşturulacak kolonun tipi ve uzunluğu belirlenir.
        [StringLength(50)] // Veritabanında oluşturulacak kolonun uzunluğu belirlenir.
        public string CariMail { get; set; }

        //Cari Mail Kısmı
        [Column(TypeName = "Varchar")] // Veritabanında oluşturulacak kolonun tipi ve uzunluğu belirlenir.
        [StringLength(100)] // Veritabanında oluşturulacak kolonun uzunluğu belirlenir.
        public string CariSifre { get; set; }

        public bool Durum { get; set; }


        //Satış Hareket tablosu ile ilişki
        public ICollection<SatisHareket> SatisHarekets { get; set; }
    }
}