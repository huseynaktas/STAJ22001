using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon_2.Models.Siniflar;
using PagedList;
using PagedList.Mvc;

namespace MvcOnlineTicariOtomasyon_2.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        Context c = new Context();
        public ActionResult Index(int sayfa=1)
        {
            var degerler = c.Kategoris.ToList().ToPagedList(sayfa, 5);
            return View(degerler);
        }

        [HttpGet]
        public ActionResult KategoriEkle()
        {
            //View yüklenirken çalışacak kodlar 
            return View();
        }

        [HttpPost]
        public ActionResult KategoriEkle(Kategori kategori)
        {
            //View'den veri alırken çalışacak kodlar
            c.Kategoris.Add(kategori); //Context'e bulunan kategorinin içine ekle
            c.SaveChanges(); //Değişiklikleri kaydet
            return RedirectToAction("Index"); //Bu işlem bittikten sonra beni bir aksiyona yönlendir
        }

        public ActionResult KategoriSil(int id)
        {
            var kategori = c.Kategoris.Find(id); //id'ye göre kategoriyi bul
            c.Kategoris.Remove(kategori); //Kategoriyi sil
            c.SaveChanges(); //Değişiklikleri kaydet
            return RedirectToAction("Index"); //Bu işlem bittikten sonra beni bir aksiyona yönlendir
        }

        public ActionResult KategoriGetir(int id)
        {
            var kategori = c.Kategoris.Find(id); //id'ye göre kategoriyi bul
            return View("KategoriGetir", kategori); //KategoriGetir sayfasına kategoriyi gönder
        }

        public ActionResult KategoriGuncelle(Kategori k)
        {
            var kategori = c.Kategoris.Find(k.KategoriID); //id'ye göre kategoriyi bul
            kategori.KateroriAd = k.KateroriAd; //Kategorinin adını güncelle
            //Sol taraf atanacak değer, sağ taraf da yeni değer
            c.SaveChanges(); //Değişiklikleri kaydet
            return RedirectToAction("Index"); //Bu işlem bittikten sonra beni bir aksiyona yönlendir
        }
    }
}