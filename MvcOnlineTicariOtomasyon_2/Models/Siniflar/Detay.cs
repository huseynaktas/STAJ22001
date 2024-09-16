using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon_2.Models.Siniflar
{
    public class Detay
    {
        [Key]
        public int DetayId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string UrunAd { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(5000)]
        public string UrunBilgi { get; set; }

    }
}