﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon_2.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon_2.Controllers
{
    public class FaturaController : Controller
    {
        // GET: Fatura
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Faturalars.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult FaturaEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FaturaEkle(Faturalar f)
        {
            c.Faturalars.Add(f);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult FaturaGetir(int id)
        {
            var fatura = c.Faturalars.Find(id);
            return View("FaturaGetir", fatura);
        }

        public ActionResult FaturaGuncelle(Faturalar f)
        {
            var fatura = c.Faturalars.Find(f.FaturaID);
            fatura.FaturaSeriNo = f.FaturaSeriNo;
            fatura.FaturaSiraNo = f.FaturaSiraNo;
            fatura.VergiDairesi = f.VergiDairesi;
            fatura.Tarih = f.Tarih;
            fatura.Saat = f.Saat;
            fatura.TeslimEden = f.TeslimEden;
            fatura.TeslimAlan = f.TeslimAlan;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FaturaDetay(int id)
        {
            var degerler = c.FaturaKalems.Where(x => x.FaturaId == id).ToList();
            ViewBag.id = id;
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniKalemEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKalemEkle(FaturaKalem f)
        {
            c.FaturaKalems.Add(f);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}