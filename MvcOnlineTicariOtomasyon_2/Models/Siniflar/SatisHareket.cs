using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon_2.Models.Siniflar
{
    public class SatisHareket
    {
        [Key]
        public int SatisId { get; set; }
        public DateTime Tarih { get; set; }
        public int Adet { get; set; }
        public decimal Fiyat { get; set; }
        public decimal ToplamTutar { get; set; }


        public int UrunId { get; set; }
        public int CariId { get; set; }
        public int PersonelId { get; set; }
        //Ürün
        //Ürün tablosu ile ilişki
        public virtual Urun Urun { get; set; }

        //Cari
        //Cari tablosu ile ilişki
        public virtual Cariler Cariler { get; set; }

        //Personel
        //Personel tablosu ile ilişki
        public virtual Personel Personel { get; set; }
    }
}