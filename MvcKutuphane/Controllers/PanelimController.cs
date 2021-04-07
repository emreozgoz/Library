using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class PanelimController : Controller
    {
        private DBKÜTÜPHANEEntities db = new DBKÜTÜPHANEEntities();
        // GET: Panelim
        [Authorize]
        [HttpGet]
        public ActionResult Index()
        {
            var uyemail = (string) Session["Mail"];
            var degerler = db.TBLUYELER.FirstOrDefault(z => z.MAIL == uyemail);
            return View(degerler);
        }
        [HttpPost]
        public ActionResult Index2(TBLUYELER p)
        {
            var kullanici = (string) Session["Mail"];
            var bilgiler = db.TBLUYELER.FirstOrDefault(x => x.MAIL == kullanici);
            bilgiler.AD = p.AD;
            bilgiler.FOTOGRAF = p.FOTOGRAF;
            bilgiler.OKUL = p.OKUL;
            bilgiler.KULLANICIADI = p.KULLANICIADI;
            bilgiler.SIFRE = p.SIFRE;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Kitaplarım()
        {
            var kullanici = (string)Session["Mail"];
            var id = db.TBLUYELER.Where(x => x.MAIL == kullanici.ToString()).Select(z=>z.ID).FirstOrDefault();
            var deger = db.TBLHAREKET.Where(x => x.UYE == id).ToList();
            return View(deger);
        }
        public ActionResult Duyurular()
        {
            var duyuru = db.TBLDUYURULAR.ToList();
            return View(duyuru);
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("GirisYap", "Login");
        }
    }
}