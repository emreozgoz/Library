using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class KitapController : Controller
    {
        private DBKÜTÜPHANEEntities db = new DBKÜTÜPHANEEntities();
        // GET: Kitap
        public ActionResult Index(string p)
        {
            var kitaplar = from k in db.TBLKİTAP select k;
            if (!string.IsNullOrEmpty(p))
            {
                kitaplar = kitaplar.Where(m => m.AD.Contains(p));
            }
           // var kitaplar = db.TBLKİTAP.ToList();
            return View(kitaplar.ToList());
        }
        [HttpGet]
        public ActionResult KitapEkle()
        {
            List<SelectListItem> deger1 = (from i in db.TBLKATEGORİ.ToList() 
                select new SelectListItem
            {
                Text = i.AD,
                Value = i.ID.ToString()
            }).ToList();
            List<SelectListItem> deger2 = (from i in db.TBLYAZAR.ToList()
                select new SelectListItem
                {
                    Text = i.AD+" "+i.SOYAD,
                    Value = i.ID.ToString()
                }).ToList();
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            return View();
        }
        [HttpPost]
        public ActionResult KitapEkle(TBLKİTAP ktp)
        {
            var kategori = db.TBLKATEGORİ.Where(k => k.ID==ktp.TBLKATEGORİ.ID).FirstOrDefault();
            var yazar = db.TBLYAZAR.Where(y => y.ID==ktp.TBLYAZAR.ID).FirstOrDefault();
            ktp.TBLKATEGORİ = kategori;
            ktp.TBLYAZAR = yazar;
            db.TBLKİTAP.Add(ktp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KitapSil(int id)
        {
            var kitaplar = db.TBLKİTAP.Find(id);
            db.TBLKİTAP.Remove(kitaplar);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KitapGetir(int id)
        {
            var kitap = db.TBLKİTAP.Find(id);
            List<SelectListItem> deger1 = (from i in db.TBLKATEGORİ.ToList()
                select new SelectListItem
                {
                    Text = i.AD,
                    Value = i.ID.ToString()
                }).ToList();
            List<SelectListItem> deger2 = (from i in db.TBLYAZAR.ToList()
                select new SelectListItem
                {
                    Text = i.AD + " " + i.SOYAD,
                    Value = i.ID.ToString()
                }).ToList();
            ViewBag.dgr2 = deger2;
            ViewBag.dgr1 = deger1;
            return View("KitapGetir", kitap);
        }

        public ActionResult KitapGuncelle(TBLKİTAP ktp)
        {
            var kitap = db.TBLKİTAP.Find(ktp.ID);
            kitap.AD = ktp.AD;
            kitap.BASIMYIL = ktp.BASIMYIL;
            kitap.SAYFA = ktp.SAYFA;
            kitap.YAYINEVİ = ktp.YAYINEVİ;
            kitap.DURUM = true;
            var kategori = db.TBLKATEGORİ.Where(k => k.ID == ktp.TBLKATEGORİ.ID).FirstOrDefault();
            var yazar = db.TBLYAZAR.Where(y => y.ID == ktp.TBLYAZAR.ID).FirstOrDefault();
            kitap.KATEGORİ = kategori.ID;
            kitap.YAZAR = yazar.ID;
            db.SaveChanges();
            return RedirectToAction("Index"); 
        }
    }
}