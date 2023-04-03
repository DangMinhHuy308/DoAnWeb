using _4TL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _4TL.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        private readonly ApplicationDbContext dbContext = new ApplicationDbContext();

        public ActionResult Index(int Cateid)
        {
            var category = dbContext.Categories.Find(Cateid);
            return View(category);
        }   
        public ActionResult ProductCategory(int Cateid) 
        {
            var products = dbContext.Products.Where(p => p.CateId == Cateid).ToList();
            return View(products);
        }
    }
}