﻿using DataAccessLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace E_Shop.Controllers
{
    public class AdminController : Controller
    {
        DataContext db = new DataContext();

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Comment(int sayfa = 1)
        {

            return View(db.Comments.ToList().ToPagedList(sayfa, 5));
        }

        public ActionResult Delete(int id)
        {
            var delete = db.Comments.Where(x=>x.Id == id).FirstOrDefault();
            db.Comments.Remove(delete);
            db.SaveChanges();

            return RedirectToAction("Comment");
        }
    }
}