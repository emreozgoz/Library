﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;
using MvcKutuphane.Models.Sınıflarım;

namespace MvcKutuphane.Controllers
{
    public class VitrinController : Controller
    {
        DBKÜTÜPHANEEntities db = new DBKÜTÜPHANEEntities();
        // GET: Vitrin
        [HttpGet]
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.Deger1 = db.TBLKİTAP.ToList();
            cs.Deger2 = db.TBLHAKKIMIZDA.ToList();
            //var degerler = db.TBLKİTAP.ToList();
            return View(cs);
        }
        [HttpPost]
        public ActionResult Index(TBLILETISIM t)
        {
            db.TBLILETISIM.Add(t);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}