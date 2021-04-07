using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class YazarController : Controller
    {
        DBKÜTÜPHANEEntities db = new DBKÜTÜPHANEEntities();
        // GET: Yazar
        public ActionResult Index()
        {

            var degerler = db.TBLYAZAR.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YazarEkle()
        {

            return View();
        }
        public ActionResult YazarEkle(TBLYAZAR yazar)
        {
            if (!ModelState.IsValid)
            {
                return View("YazarEkle");
            }
            db.TBLYAZAR.Add(yazar);
            db.SaveChanges();
            return View();
        }
        public ActionResult YazarSil(int id)
        {
          
            var yazar = db.TBLYAZAR.Find(id);
            db.TBLYAZAR.Remove(yazar);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult YazarGetir(int id)
        {
            var yazarlar = db.TBLYAZAR.Find(id);
            return View("YazarGetir", yazarlar);
        }

        public ActionResult YazarGuncelle(TBLYAZAR tbl)
        {
            var yazar = db.TBLYAZAR.Find(tbl.ID);
           // yazar.ID = tbl.ID;
            yazar.AD = tbl.AD;
            yazar.SOYAD = tbl.SOYAD;
            yazar.DETAY = tbl.DETAY;
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult YazarKitaplar(int id)
        {
            var kitaplar = db.TBLKİTAP.Where(x => x.YAZAR == id).ToList();
            var yzrad = db.TBLYAZAR.Where(y => y.ID == id).Select(z => z.AD + " " + z.SOYAD).FirstOrDefault();
            ViewBag.y1 = yzrad;
            return View(kitaplar);
        }
    }
}