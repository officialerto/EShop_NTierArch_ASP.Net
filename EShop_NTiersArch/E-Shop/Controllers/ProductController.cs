using BusinessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Shop.Controllers
{
    public class ProductController : Controller
    {
        ProductRepository productRepository = new ProductRepository();

        // GET: Product
        public PartialViewResult PopularProduct()
        {
            var product = productRepository.GetPopularProduct();
            ViewBag.popular = product;

            return PartialView();
        }

        public ActionResult ProductDetails(int id)
        {
            var details = productRepository.GetById(id);

            return View(details);
        }
    }
}