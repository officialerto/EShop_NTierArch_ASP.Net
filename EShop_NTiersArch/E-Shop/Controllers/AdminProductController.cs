using BusinessLayer.Concrete;
using DataAccessLayer.Context;
using EntityLayer.Entities;
using PagedList;
using PagedList.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Shop.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminProductController : Controller
    {
        ProductRepository productRepository = new ProductRepository();

        DataContext dataContext = new DataContext();

        // GET: AdminProduct
        public ActionResult Index(int sayfa=1)
        {
            return View(productRepository.List().ToPagedList(sayfa, 4));
        }

        public ActionResult Create()
        {
            List<SelectListItem> deger1 = (from i in dataContext.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Name,
                                               Value = i.Id.ToString()

                                           }).ToList();
            ViewBag.ktgr = deger1;

            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(Product data, HttpPostedFileBase File) //Resim yükleme işlemi için 2.değer
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "An error occurred");
            }

            string path = Path.Combine("~/Content/Image/" + File.FileName);
            File.SaveAs(Server.MapPath(path));

            data.Image = File.FileName.ToString();
            productRepository.Insert(data);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var delete = productRepository.GetById(id);

            productRepository.Delete(delete);

            return RedirectToAction("Index");
        }

        public ActionResult Update(int id)
        {
            var update = productRepository.GetById(id);

            List<SelectListItem> deger1 = (from i in dataContext.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Name,
                                               Value = i.Id.ToString()

                                           }).ToList();
            ViewBag.ktgr = deger1;

            return View(update);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Update(Product data, HttpPostedFileBase File)
        {
            var update = productRepository.GetById(data.Id);

            if (!ModelState.IsValid)
            {
                if (File == null)
                {
                    update.Description = data.Description;
                    update.Category = data.Category;
                    update.Stock = data.Stock;
                    update.Name = data.Name;
                    update.Price = data.Price;
                    update.IsApproved = data.IsApproved;
                    update.CategoryId = data.CategoryId;

                    productRepository.Update(data);

                    return RedirectToAction("Index");
                }
                else
                {
                    update.Description = data.Description;
                    update.Category = data.Category;
                    update.Stock = data.Stock;
                    update.Name = data.Name;
                    update.Price = data.Price;
                    update.IsApproved = data.IsApproved;
                    update.Image = File.FileName.ToString();
                    update.CategoryId = data.CategoryId;

                    productRepository.Update(update);

                    return RedirectToAction("Index");
                }
            }

            return View(update);

        }

        public ActionResult CriticalStock()
        {

            var kritik = dataContext.Products.Where(x=>x.Stock <= 50).ToList();

            return View(kritik);
        }

        public PartialViewResult StockCount()
        {

            if (User.Identity.IsAuthenticated)
            {
                var count = dataContext.Products.Where(x => x.Stock < 50).Count();
                ViewBag.count = count;

                var azalan = dataContext.Products.Where(x=>x.Stock == 50).Count();
                ViewBag.azalan = azalan;
            }

            return PartialView();
        }

    }
}