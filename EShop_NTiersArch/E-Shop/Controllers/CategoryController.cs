using BusinessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Shop.Controllers
{
    public class CategoryController : Controller
    {
        CategoryRepository categoryRepository = new CategoryRepository();   

        // GET: Category
        public PartialViewResult CategoryList()
        { 

            return PartialView(categoryRepository.List());
        }
    }
}