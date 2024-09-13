using eCommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Controllers
{
    public class CategoryController : Controller
    {
        MyContext db = new MyContext();
        public IActionResult Index()
        {
            var _Categories = db.Categories;
            return View(_Categories);
        }
        // Category - Action method to return a view that displays a Table of all Categories
        [HttpGet]
        public IActionResult ViewDetails(int id)
        {
           
            var _Categories = db.Categories.FirstOrDefault(c => c.CategoryId == id);
            return View(_Categories);
        }

        // Details - Action method to return a view that displays a Details info of one Category
        [HttpGet]
        public IActionResult Details(int id)
        {
            var category = db.Categories.FirstOrDefault(c => c.CategoryId == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // Create - Action method to add a new Category
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag._Products = new SelectList(db.Products, "Name");
            return View();
        }

        
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "All Fields Required");
                return View();
            }
            // Remove the CategoryId assignment, let the database generate the value
            db.Categories.Add(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // Edit - Action method to Edit an existing Category
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var category = db.Categories.FirstOrDefault(c => c.CategoryId == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "All Fields Required");
                return View();
            }
            db.Entry(category).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var category = db.Categories.FirstOrDefault(p => p.CategoryId == id);
            if (category == null)
            {
                return RedirectToAction("Index");
            }
            return View(category);  // This will use the Delete view to confirm deletion.
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var category = db.Categories.FirstOrDefault(p => p.CategoryId == id);
            if (category == null)
            {
                ViewBag._Categories = new SelectList(db.Categories, "Name", "Description"); // Corrected typo
                return RedirectToAction("Index");
            }

            db.Categories.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
