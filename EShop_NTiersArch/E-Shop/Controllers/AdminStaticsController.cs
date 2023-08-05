using DataAccessLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Shop.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminStaticsController : Controller
    {
        DataContext db = new DataContext();

        // GET: AdminStatics
        public ActionResult Index()
        {
            var satis = db.Sales.Count();
            ViewBag.satis = satis;

            var urun = db.Products.Count();
            ViewBag.urun = urun;

            var kategori = db.Categories.Count();
            ViewBag.kategori = kategori;

            var sepet = db.Carts.Count();
            ViewBag.sepet = sepet;

            var kullanici = db.Users.Count();
            ViewBag.kullanici = kullanici;

            return View();
        }
    }
}