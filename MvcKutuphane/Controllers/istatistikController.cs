using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;
namespace MvcKutuphane.Controllers
{
    public class istatistikController : Controller
    {
        private DBKÜTÜPHANEEntities db = new DBKÜTÜPHANEEntities();
        // GET: istatistik
        public ActionResult Index()
        {
            var deger1 = db.TBLUYELER.Count();
            var deger2 = db.TBLKİTAP.Count();
            var deger3 = db.TBLKİTAP.Where(x => x.DURUM == false).Count();
            var Tutar = db.TBLCEZALAR.Sum(x => x.PARA);
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            ViewBag.Tutar = Tutar;

            return View();
        }
        public ActionResult Hava()
        {
            return View();
        }
        public ActionResult HavaKart()
        {
            return View();
        }

        public ActionResult Galeri()
        {
            return View();
        }
        [HttpPost]
        public ActionResult resimyukle(HttpPostedFileBase dosya)
        {
            if (dosya.ContentLength > 0)
            {
                string dosyayol = Path.Combine(Server.MapPath("~/web2/resimler/"), Path.GetFileName(dosya.FileName));
                dosya.SaveAs(dosyayol);
            }

            return RedirectToAction("Galeri");
        }
        public ActionResult LinqKart()
        {
            var deger1 = db.TBLKİTAP.Count();
            ViewBag.dgr1 = deger1;
            var deger2 = db.TBLUYELER.Count();
            ViewBag.dgr2 = deger2;
            var deger3 = db.TBLCEZALAR.Sum(x => x.PARA);
            ViewBag.dgr3 = deger3;
            var deger4 = db.TBLKİTAP.Where(x => x.DURUM == false).Count();
            ViewBag.dgr4 = deger4;
            var deger5 = db.TBLKATEGORİ.Count();
            ViewBag.dgr5 = deger5;
            var deger8 = db.EnFazlaKitapYazar().FirstOrDefault();
            ViewBag.dgr8 = deger8;
            var deger9 = db.TBLKİTAP.GroupBy(x => x.YAYINEVİ).OrderByDescending(z => z.Count()).Select(y =>new {y.Key}).FirstOrDefault();
            ViewBag.dgr9 = deger9;
            var deger11 = db.TBLILETISIM.Count();
            ViewBag.dgr11 = deger11;
            return View();
        }
    }
}