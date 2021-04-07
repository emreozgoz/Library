using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;
namespace MvcKutuphane.Controllers
{
    public class CategoryController : Controller
    {
        DBKÜTÜPHANEEntities db = new DBKÜTÜPHANEEntities();


        // GET: Category
        public ActionResult Index()
        {
            var degerler = db.TBLKATEGORİ.Where(x=>x.DURUM ==true).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KategoriEkle(TBLKATEGORİ p)
        {
            db.TBLKATEGORİ.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult KategoriSil(int id)
        {
            var kategori = db.TBLKATEGORİ.Find(id);
          //  db.TBLKATEGORİ.Remove(kategori);
          kategori.DURUM = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int id)
        {
            var kategori = db.TBLKATEGORİ.Find(id);
            return View("KategoriGetir", kategori);
        }
        public ActionResult KategoriGuncelle(TBLKATEGORİ p)
        {
            var kategori = db.TBLKATEGORİ.Find(p.ID);
            kategori.AD = p.AD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}