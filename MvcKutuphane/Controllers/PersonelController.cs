using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class PersonelController : Controller
    {
        private DBKÜTÜPHANEEntities db = new DBKÜTÜPHANEEntities();
        // GET: Personel
        public ActionResult Index()
        {
            var personel = db.TBLPERSONEL.ToList();
            return View(personel);
        }
        [HttpGet]
        public ActionResult PersonelEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PersonelEkle(TBLPERSONEL prs)
        {
            if (!ModelState.IsValid)
            {
                return View("PersonelEkle");
            }
            db.TBLPERSONEL.Add(prs);
            db.SaveChanges();
            return View();
        }

        public ActionResult PersonelSil(int id)
        {
            var personel = db.TBLPERSONEL.Find(id);
            db.TBLPERSONEL.Remove(personel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelGetir(int id)
        {
            var personel = db.TBLPERSONEL.Find(id);
            return View("PersonelGetir", personel);
        }

        public ActionResult PersonelGuncelle(TBLPERSONEL prs)
        {
            var personel = db.TBLPERSONEL.Find(prs.ID);
            personel.PERSONEL = prs.PERSONEL;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}