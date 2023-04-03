using _4TL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _4TL.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext dbContext = new ApplicationDbContext();
        // GET: Admin/Product
        public ActionResult Index()
        {
            var listProduct = dbContext.Products.ToList();
            return View(listProduct);
        }
        public ActionResult Create()
        {

            var listCate = dbContext.Categories.ToList();
            ViewBag.Loai = listCate;
            return View();
        }
        [HttpPost]
        public ActionResult SaveProduct(Product product, HttpPostedFileBase FeatureImage)
        {
            if (!ModelState.IsValid)
            {

                var listCate = dbContext.Categories.ToList();
                ViewBag.Loai = listCate;
                return View("Create", product);
            }
            string path = Path.Combine(Server.MapPath("~/Content/NoiThat/images"), Path.GetFileName(FeatureImage.FileName));
            FeatureImage.SaveAs(path);
            product.FeatureImage = "/Content/NoiThat/images/" + Path.GetFileName(FeatureImage.FileName);
            dbContext.Products.Add(product);
            dbContext.SaveChanges();
            return RedirectToAction("Index", "Product");
        }
        public ActionResult Edit(int id) {
            var product = dbContext.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            var listCate = dbContext.Categories.ToList();
            ViewBag.Loai = listCate;
            return View(product);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateProduct(Product product, HttpPostedFileBase FeatureImage)
        {
            if (!ModelState.IsValid)
            {
                var listCate = dbContext.Categories.ToList();
                ViewBag.Loai = listCate;
                return View("Edit", product);
            }
            string path = Path.Combine(Server.MapPath("~/Content/NoiThat/images"), Path.GetFileName(FeatureImage.FileName));
            FeatureImage.SaveAs(path);
            product.FeatureImage = "/Content/NoiThat/images/" + Path.GetFileName(FeatureImage.FileName);
            dbContext.Entry(product).State = EntityState.Modified;
            dbContext.SaveChanges();
            return RedirectToAction("Index", "Product");
        }
        public ActionResult Delete(int id)
        {
            var product = dbContext.Products.FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                return HttpNotFound();
            }
            dbContext.Products.Remove(product);
            dbContext.SaveChanges();
            return RedirectToAction("Index", "Product");
        }


    }
}