using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon_2.Models.Siniflar
{
    public class Departman
    {
        [Key]
        public int DepartmanId { get; set; }


        //Departman Ad Kısmı
        [Column(TypeName = "Varchar")] // Veritabanında oluşturulacak kolonun tipi ve uzunluğu belirlenir.
        [StringLength(30)] // Veritabanında oluşturulacak kolonun uzunluğu belirlenir.
        public string DepartmanAd { get; set; }
        public bool Durum { get; set; }


        //Personel tablosu ile ilişki
        public ICollection<Personel> Personels { get; set; }
    }
}