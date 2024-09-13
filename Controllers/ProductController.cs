using eCommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Controllers
{
    public class ProductController : Controller
    {
        MyContext db = new MyContext();
        [HttpGet]
        public IActionResult Index()
        {
            var _Products = db.Products.Include(p => p.Category).ToList();
            return View(_Products);
        }

        // View details of a single product
        [HttpGet]
        public IActionResult ViewDetails(int id)
        {
            var _Product = db.Products.Include(p => p.Category).FirstOrDefault(pe => pe.ProductId == id);
            if (_Product == null)
            {
                return RedirectToAction("Index");
            }
            return View(_Product);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var categories = db.Categories.ToList();
            ViewBag._Categories = new SelectList(categories, "CategoryId", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                ViewBag._Categories = new SelectList(db.Categories, "CategoryId", "Name");
                return View(product);
            }

            db.Products.Add(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



        [HttpGet]
        public IActionResult Edit(int id)
        {
            var _Product = db.Products.Include(e => e.Category).FirstOrDefault(em => em.ProductId == id);
            if (_Product == null)
            {
                return RedirectToAction("Index");
            }

            ViewBag._Categories = new SelectList(db.Categories, "Name", "CategoryId");
            return View(_Product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            ModelState.Remove("Category");
            if (!ModelState.IsValid)
            {
                ViewBag._Categories = new SelectList(db.Categories, "Name", "CategoryId");
                return View(product);
            }

            db.Products.Update(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        // Display the delete confirmation page
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var product = db.Products.FirstOrDefault(p => p.ProductId == id);
            if (product == null)
            {
                return RedirectToAction("Index");
            }
            return View(product);
        }

       [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
         var product = db.Products.FirstOrDefault(p => p.ProductId == id);
         if (product == null)
        {
        ViewBag._Products = new SelectList(db.Products, "Title", "Description");
        return RedirectToAction("Index");
        }

          db.Products.Remove(product);
          db.SaveChanges();
          return RedirectToAction("Index");
        }
        //public IActionResult Index()
        //{
        //    // Logic to fetch and display products
        //    return View();
        //}
    }
}
