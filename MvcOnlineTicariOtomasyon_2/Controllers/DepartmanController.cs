using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon_2.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon_2.Controllers
{
    public class DepartmanController : Controller
    {
        // GET: Departman
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Departmans.Where(x => x.Durum == true).ToList();//Departmanları listeleme
            return View(degerler);
        }

        [HttpGet]
        public ActionResult DepartmanEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DepartmanEkle(Departman departman)
        {
            c.Departmans.Add(departman); //Context'e bulunan departmanın içine ekle
            c.SaveChanges(); //Değişiklikleri kaydet
            return RedirectToAction("Index"); //Bu işlem bittikten sonra beni bir aksiyona yönlendir
        }

        public ActionResult DepartmanSil(int id)
        {
            var departman = c.Departmans.Find(id); //id'ye göre departmanı bul
            departman.Durum = false; //Departmanın durumunu false yap
            c.SaveChanges(); //Değişiklikleri kaydet
            return RedirectToAction("Index"); //Bu işlem bittikten sonra beni bir aksiyona yönlendir
        }

        public ActionResult DepartmanGetir(int id)
        {
            var departman = c.Departmans.Find(id); //id'ye göre departmanı bul
            return View("DepartmanGetir", departman); //DepartmanGetir sayfasına departmanı gönder
        }

        public ActionResult DepartmanGuncelle(Departman departman) 
        {
            var dep = c.Departmans.Find(departman.DepartmanId); //DepartmanID'ye göre departmanı bul
            dep.DepartmanAd = departman.DepartmanAd; //DepartmanAd'ı güncelle
            c.SaveChanges(); //Değişiklikleri kaydet
            return RedirectToAction("Index"); //Bu işlem bittikten sonra beni bir aksiyona yönlendir
        }

        public ActionResult DepartmanDetay(int id)
        {
            var degerler = c.Personels.Where(x => x.DepartmanId == id).ToList(); //DepartmanID'ye göre personelleri listele
            var dpt = c.Departmans.Where(x => x.DepartmanId == id).Select(y => y.DepartmanAd).FirstOrDefault(); //DepartmanID'ye göre departman adını getir
            ViewBag.d = dpt; //Departman adını viewbag'e gönder
            return View(degerler);
        }

        public ActionResult DepartmanPersonelSatis(int id)
        {
            var degerler = c.SatisHarekets.Where(x => x.PersonelId == id).ToList(); //PersonelID'ye göre satış hareketlerini listele
            var per = c.Personels.Where(x => x.PersonelId == id).Select(y => y.PersonelAd + " " + y.PersonelSoyad).FirstOrDefault(); //PersonelID'ye göre personel adını getir
            ViewBag.dpers = per; //Personel adını viewbag'e gönder
            return View(degerler);
        }

    }
}