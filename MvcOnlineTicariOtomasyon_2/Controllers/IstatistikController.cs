using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon_2.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon_2.Controllers
{
    public class IstatistikController : Controller
    {
        // GET: Istatistik
        Context c = new Context();
        public ActionResult Index()
        {
            var deger1 = c.Carilers.Count().ToString();//Cari sayısını Count ile alıyoruz ve stringe çeviriyoruz.
            ViewBag.d1 = deger1;
            var deger2 = c.Uruns.Count().ToString();//Ürün sayısını Count ile alıyoruz ve stringe çeviriyoruz.
            ViewBag.d2 = deger2;
            var deger3 = c.Personels.Count().ToString();//Personel sayısını Count ile alıyoruz ve stringe çeviriyoruz.
            ViewBag.d3 = deger3;
            var deger4 = c.Kategoris.Count().ToString();//Kategori sayısını Count ile alıyoruz ve stringe çeviriyoruz.
            ViewBag.d4 = deger4;

            var deger5 = c.Uruns.Sum(x => x.Stok).ToString();//Ürün stoklarını Sum() topluyoruz ve stringe çeviriyoruz.
            ViewBag.d5 = deger5;
            var deger6 = (from x in c.Uruns select x.Marka).Distinct().Count().ToString();//Ürün markalarını Distinct ile alıp Count ile sayıyoruz ve stringe çeviriyoruz. Distinct() metodu aynı olanları bir kez alır. Count() ile de sayısını alırız. Count() metodu ile kaç tane olduğunu sayarız. 
            ViewBag.d6 = deger6;
            var deger7 = c.Uruns.Count(x => x.Stok <= 20).ToString();//Stok sayısı 20 den küçük olanları sayar.
            ViewBag.d7 = deger7;
            var deger8 = (from x in c.Uruns orderby x.SatisFiyat descending select x.UrunAd).FirstOrDefault(); //Ürünlerin satış fiyatlarına göre sıralar ve en yüksek fiyatlı ürünü alır. FirstOrDefault() metodu ile de ilk ürünü alır. 
            ViewBag.d8 = deger8;

            var deger9 = (from x in c.Uruns orderby x.SatisFiyat ascending select x.UrunAd).FirstOrDefault();//Ürünlerin satış fiyatlarına göre sıralar ve en düşük fiyatlı ürünü alır. FirstOrDefault() metodu ile de ilk ürünü alır. orderby x.SatisFiyat ascending ile küçükten büyüğe sıralarız. 
            ViewBag.d9 = deger9;
            var deger10 = c.Uruns.Count(x => x.UrunAd == "Buzdolabı").ToString();//Ürün adı Buzdolabı olanları alır ve sayar. 
            ViewBag.d10 = deger10;
            var deger11 = c.Uruns.Count(x => x.UrunAd == "Laptop").ToString();//Ürün adı Laptop olanları alır ve sayar.
            ViewBag.d11 = deger11;
            var deger12 = c.Uruns.GroupBy(x => x.Marka).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault();//Ürünlerin markalarını gruplar ve gruplara göre sayar. En çok olan markayı alır. OrderByDescending(z => z.Count()) ile gruplara göre sayarız. Select(y => y.Key) ile de Key olan yani markaları alırız. FirstOrDefault() ile de ilk markayı alırız.
            ViewBag.d12 = deger12;

            var deger13 = c.Uruns.Where(u => u.UrunId == (c.SatisHarekets.GroupBy(x => x.UrunId).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault())).Select(k => k.UrunAd).FirstOrDefault();//Ürünlerin Id'lerini gruplar ve gruplara göre sayar. En çok satılan ürünün Id'sini alır. Where(u => u.UrunId == (c.SatisHarekets.GroupBy(x => x.UrunId).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault())) ile de bu Id'yi alırız. Select(k => k.UrunAd) ile de bu Id'ye ait olan ürün adını alırız. FirstOrDefault() ile de ilk ürün adını alırız.
            ViewBag.d13 = deger13;
            var deger14 = c.SatisHarekets.Sum(x => x.ToplamTutar).ToString();//Satış hareketlerinin toplam tutarlarını toplar ve stringe çeviririz.
            ViewBag.d14 = deger14;
            DateTime bugun = DateTime.Today;
            var deger15 = c.SatisHarekets.Count(x => x.Tarih == bugun).ToString();//Bugünün tarihine eşit olan satış hareketlerini sayar.
            ViewBag.d15 = deger15;
            var deger16 = c.SatisHarekets.Where(x => x.Tarih == bugun).Sum(y => (decimal?)y.ToplamTutar).ToString();//Bugünün tarihine eşit olan satış hareketlerinin toplam tutarlarını toplar. (decimal?) ile de decimal türünde olduğunu belirtiriz. 
            ViewBag.d16 = deger16;
            return View();
        }

        public ActionResult KolayTablolar()
        {
            var sorgu = from x in c.Carilers
                        group x by x.CariSehir into g
                        select new SinifGrup
                        {
                            Sehir = g.Key,
                            Sayi = g.Count()
                        };
            return View(sorgu.ToList());
        }

        public PartialViewResult Partial1()
        {
            var sorgu2 = from x in c.Personels
                         group x by x.Departman.DepartmanAd into g
                         select new SinifGrup2
                         {
                             Departman = g.Key,
                             Sayi = g.Count()
                         };
            return PartialView(sorgu2.ToList());
        }
        
        public PartialViewResult Partial2()
        {
            var sorgu = c.Carilers.ToList();
            return PartialView(sorgu);
        }

        public PartialViewResult Partial3()
        {
            var sorgu = c.Uruns.ToList();
            return PartialView(sorgu);
        }

        public PartialViewResult Partial4()
        {
            var sorgu = from x in c.Uruns
                         group x by x.Marka into g
                         select new SinifGrup3
                         {
                             Marka = g.Key,
                             Sayi = g.Count()
                         };
            return PartialView(sorgu.ToList());
        }
    }
}