﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class islemController : Controller
    {
        private DBKÜTÜPHANEEntities db = new DBKÜTÜPHANEEntities();
        // GET: islem
        public ActionResult Index()
        {
            var deger = db.TBLHAREKET.Where(x => x.ISLEMDURUM == true).ToList();
            return View(deger);
        }
    }
}