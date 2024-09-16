using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon_2.Models.Siniflar
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }


        //Kullanıcı Adı Kısmı
        [Column(TypeName = "Varchar")] // Veritabanında oluşturulacak kolonun tipi ve uzunluğu belirlenir.
        [StringLength(10)] // Veritabanında oluşturulacak kolonun uzunluğu belirlenir.
        public string KullaniciAd { get; set; }


        //Şifre Kısmı
        [Column(TypeName = "Varchar")] // Veritabanında oluşturulacak kolonun tipi ve uzunluğu belirlenir.
        [StringLength(30)] // Veritabanında oluşturulacak kolonun uzunluğu belirlenir.
        public string Sifre { get; set; }


        //Yetki Kısmı
        [Column(TypeName = "Char")] // Veritabanında oluşturulacak kolonun tipi ve uzunluğu belirlenir.
        [StringLength(1)] // Veritabanında oluşturulacak kolonun uzunluğu belirlenir.
        public string Yetki { get; set; }
    }
}