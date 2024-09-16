using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon_2.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon_2.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Personels.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult PersonelEkle()
        {
            List<SelectListItem> degerler = (from x in c.Departmans.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.DepartmanAd,
                                                 Value = x.DepartmanId.ToString()
                                             }).ToList();
            
            ViewBag.dgr1 = degerler;
            return View();
        }

        [HttpPost]
        public ActionResult PersonelEkle(Personel p)
        {
            if (Request.Files.Count > 0 )
            {
                string dosyaAdi = Path.GetFileName(Request.Files[0].FileName); // Dosya adını alıyoruz.
                string uzanti = Path.GetExtension(Request.Files[0].FileName); // Dosya uzantısını alıyoruz.
                string yol = "~/Image/" + dosyaAdi + uzanti; // Dosyanın yolu.
                Request.Files[0].SaveAs(Server.MapPath(yol)); // Dosyayı kaydediyoruz.
                p.PersonelGorsel = "/Image/" + dosyaAdi + uzanti; // Dosyanın yolu veritabanına kaydedilecek.
            }
            c.Personels.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelGetir(int id)
        {
            List<SelectListItem> degerler = (from x in c.Departmans.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.DepartmanAd,
                                                 Value = x.DepartmanId.ToString()
                                             }).ToList();

            ViewBag.dgr1 = degerler;
            var prs = c.Personels.Find(id);
            return View("PersonelGetir",prs);
        }

        public ActionResult PersonelGuncelle(Personel p)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaAdi = Path.GetFileName(Request.Files[0].FileName); // Dosya adını alıyoruz.
                string uzanti = Path.GetExtension(Request.Files[0].FileName); // Dosya uzantısını alıyoruz.
                string yol = "~/Image/" + dosyaAdi + uzanti; // Dosyanın yolu.
                Request.Files[0].SaveAs(Server.MapPath(yol)); // Dosyayı kaydediyoruz.
                p.PersonelGorsel = "/Image/" + dosyaAdi + uzanti; // Dosyanın yolu veritabanına kaydedilecek.
            }
            var prsnl = c.Personels.Find(p.PersonelId);
            prsnl.PersonelAd = p.PersonelAd;
            prsnl.PersonelSoyad = p.PersonelSoyad;
            prsnl.PersonelGorsel = p.PersonelGorsel;
            prsnl.DepartmanId = p.DepartmanId;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelYeniList()
        {
            var degerler = c.Personels.ToList();
            return View(degerler);
        }
    }
}