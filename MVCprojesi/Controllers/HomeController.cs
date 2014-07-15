using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCprojesi.Data;

namespace MVCprojesi.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        //son 5 makalenin anasayfaya yükleneceği action
        public ActionResult SonBesMakale()
        {
            //veri tabanından yeni bir nesne oluşturduk
            MVCprojesiContext db = new MVCprojesiContext();
            //son makaleleri orderbydescending ile çekip sayısını take ile belirledik
            List<Makale> makaleListe = db.Makales.OrderByDescending(i => i.Tarih).Take(5).ToList();
            return PartialView(makaleListe);
        }

        public ActionResult SonBesYorum()
        {
            MVCprojesiContext db = new MVCprojesiContext();
            List<Yorum> yorumliste = db.Yorums.OrderByDescending(i => i.Tarih).Take(5).ToList();
            return PartialView(yorumliste);

        }
       
    }
}