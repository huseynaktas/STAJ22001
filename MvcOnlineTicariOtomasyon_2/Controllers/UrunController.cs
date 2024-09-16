using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Antlr.Runtime;
using MvcOnlineTicariOtomasyon_2.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon_2.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        Context c = new Context(); //Veritabanı bağlantılarını yönetmek ve sorgular yapmak için.
        public ActionResult Index(string p)
        {
            //Ürün durumu true olanları göstermek için yazılan kod.
            var urunler = from x in c.Uruns
                          where x.Durum == true
                          select x;




            if (!string.IsNullOrEmpty(p))
            {
                urunler = urunler.Where(y => y.UrunAd.Contains(p));
            }
            return View(urunler.ToList());
        }

        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> degerler = (from x in c.Kategoris.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.KateroriAd,
                                                 Value = x.KategoriID.ToString()
                                             }).ToList();
            //1.List<SelectListItem> degerler: Bu ifade, SelectListItem türünden bir liste tanımlar. SelectListItem, dropdown listelerde kullanılmak üzere tasarlanmış bir sınıftır ve her bir öğenin metin (Text) ve değer (Value) alanlarını içerir.
            //2.from x in c.Kategoris.ToList(): Bu ifade, c.Kategoris koleksiyonundan(veritabanındaki Kategoris tablosundan) tüm kayıtları çeker ve bir liste haline getirir. Burada x, her bir kategori kaydını temsil eder.
            //3.select new SelectListItem: Bu ifade, çekilen her bir kategori kaydı(x) için yeni bir SelectListItem nesnesi oluşturur.
            //4. { Text = x.KateroriAd, Value = x.KategoriID.ToString() }: Bu kısımda, oluşturulan her SelectListItem nesnesinin Text ve Value alanları doldurulur. Text alanına kategorinin adı(KateroriAd), Value alanına ise kategorinin ID'si (KategoriID) atanır. KategoriID, bir sayısal değer olduğu için ToString() metodu ile metinsel bir değere dönüştürülür.
            ViewBag.dgr1 = degerler;
            return View();
        }

        [HttpPost]
        public ActionResult YeniUrun(Urun urun)
        {
            c.Uruns.Add(urun);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunSil(int id)
        {
            var urun = c.Uruns.Find(id);
            urun.Durum = false; // Silme işlemi yerine durumunu false yaparak pasif hale getirir.
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunGetir(int id)
        {
            List<SelectListItem> degerler = (from x in c.Kategoris.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.KateroriAd,
                                                 Value = x.KategoriID.ToString()
                                             }).ToList();
            ViewBag.dgr1 = degerler;
            var urunDeger = c.Uruns.Find(id);
            return View("UrunGetir", urunDeger);
        }

        public ActionResult UrunGuncelle(Urun p)
        {
            var urn = c.Uruns.Find(p.UrunId);
            urn.UrunAd = p.UrunAd;
            urn.Marka = p.Marka;
            urn.AlisFiyat = p.AlisFiyat;
            urn.SatisFiyat = p.SatisFiyat;
            urn.Stok = p.Stok;
            urn.Durum = p.Durum;
            urn.UrunGorsel = p.UrunGorsel;
            urn.KategoriId = p.KategoriId;
            c.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult UrunListesi()
        {
            var degerler = c.Uruns.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult SatisYap(int id)
        {
            List<SelectListItem> deger = (from x in c.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelAd + " " + x.PersonelSoyad,
                                               Value = x.PersonelId.ToString()
                                           }).ToList();
            ViewBag.dgr = deger;
            var deger1 = c.Uruns.Find(id);
            ViewBag.dgr1 = deger1.UrunId;
            ViewBag.dgr2 = deger1.SatisFiyat;
            return View();
        }
        [HttpPost]
        public ActionResult SatisYap(SatisHareket p)
        {
            p.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.SatisHarekets.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index","Satis");
        }
    }
}