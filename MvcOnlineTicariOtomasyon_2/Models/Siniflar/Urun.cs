using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon_2.Models.Siniflar
{
    public class Urun
    {
        [Key]
        public int UrunId { get; set; }

        [Column(TypeName = "Varchar")] //Veritabanında oluşturulacak kolonun tipi
        [StringLength(30)] //Veritabanında oluşturulacak kolonun uzunluğu
        public string UrunAd { get; set; }

        [Column(TypeName = "Varchar")] //Veritabanında oluşturulacak kolonun tipi
        [StringLength(30)]//Veritabanında oluşturulacak kolonun uzunluğu
        public string Marka { get; set; }
        public short Stok { get; set; }
        public decimal AlisFiyat { get; set; }
        public decimal SatisFiyat { get; set; }
        public bool Durum { get; set; }

        [Column(TypeName = "Varchar")] // Veritabanında oluşturulacak kolonun tipi ve uzunluğu belirlenir.
        [StringLength(250)] // Veritabanında oluşturulacak kolonun uzunluğu belirlenir.
        public string UrunGorsel { get; set; }

        public int KategoriId { get; set; }

        //Kategori tablosu ile ilişki
        public virtual Kategori Kategori { get; set; }

        //SatisHareket tablosu ile ilişki
        public ICollection<SatisHareket> SatisHarekets { get; set; }
    }
}