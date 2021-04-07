using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class DuyuruController : Controller
    {
        // GET: Duyuru
        private DBKÜTÜPHANEEntities db = new DBKÜTÜPHANEEntities();
        public ActionResult Index()
        {
            var degerler = db.TBLDUYURULAR.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniDuyuru()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniDuyuru(TBLDUYURULAR p)
        {
            db.TBLDUYURULAR.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DuyuruSil(int  id)
        {
            var deger = db.TBLDUYURULAR.Find(id);
            db.TBLDUYURULAR.Remove(deger);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DuyuruDetay(TBLDUYURULAR p)
        {
            var deger = db.TBLDUYURULAR.Find(p.ID);
            return View("DuyuruDetay",deger);
        }
        public ActionResult DuyuruGuncelle(TBLDUYURULAR p)
        {
            var deger = db.TBLDUYURULAR.Find(p.ID);
            deger.ICERIK = p.ICERIK;
            deger.KATEGORI = p.KATEGORI;
            deger.TARIH = p.TARIH;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}