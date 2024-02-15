using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Uygulama.Models.Entity;

namespace Uygulama.Controllers
{
    public class CategoryController : Controller
    {
        public CategoryController(NorthwindContext dbContext)
        {
            db = dbContext;
        }
        private readonly NorthwindContext db;
        public IActionResult Index()
        {
            var categoryList = db.Categories.ToList();
            if (categoryList != null || categoryList.Count != 0)
            {
                return View(categoryList);
            }
            return View();
        }
        public IActionResult Delete(int id)
        {
            try
            {
                var silinecek = db.Categories.Find(id);
                if (silinecek == null)
                {
                    return RedirectToAction("Index");
                }
                db.Categories.Remove(silinecek);
                db.SaveChanges();
            }
            catch (Exception)
            {
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(category);
                db.SaveChanges();
                int newCategoryId = category.CategoryId;


                return RedirectToAction("Index", "Product", new { categoryId = newCategoryId });
            }
            return View(category);

        }
    }
}
