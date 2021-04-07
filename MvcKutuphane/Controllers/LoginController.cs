using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;
using System.Web.Security;

namespace MvcKutuphane.Controllers
{
    public class LoginController : Controller
    {
        private DBKÜTÜPHANEEntities db = new DBKÜTÜPHANEEntities();
        // GET: Login
        [HttpGet]
        public ActionResult GirisYap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GirisYap(TBLUYELER p)
        {
            var bilgi = db.TBLUYELER.FirstOrDefault(x => x.MAIL == p.MAIL && x.SIFRE == p.SIFRE);
            if (bilgi !=null)
            {
                FormsAuthentication.SetAuthCookie(bilgi.MAIL,false);
                Session["Mail"] = bilgi.MAIL.ToString();
                //TempData["ID"] = bilgi.ID.ToString();
                //TempData["Ad"] = bilgi.AD.ToString();
                //TempData["Soyad"] = bilgi.SOYAD.ToString();
                //TempData["KulaniciAdi"] = bilgi.KULLANICIADI.ToString();
                //TempData["Sifre"] = bilgi.SIFRE.ToString();
                //TempData["Okul"] = bilgi.OKUL.ToString();
                return RedirectToAction("Index", "Panelim");
            }
            else
            {
                return View();
            }
        }
    }
}