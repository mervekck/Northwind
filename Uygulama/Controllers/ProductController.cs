using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Uygulama.Models.Entity;

namespace Uygulama.Controllers
{
    public class ProductController : Controller
    {
        public ProductController(NorthwindContext dbContext)
        {
            db = dbContext;
        }
        private readonly NorthwindContext db;
        public IActionResult Index()
        {
            var productList = db.Products.ToList();
            if (productList != null || productList.Count != 0)
            {
                return View(productList);
            }
            return View();
        }

        public IActionResult Detail(int id)
        {
            if (id <= 0)
            {
                TempData["error"] = "Geçersiz ürün ID'si";
                return RedirectToAction("Index");
            }

            var productDetails = db.Products
                                   .Include(p => p.Category)
                                   .Include(p => p.Supplier)
                                   .FirstOrDefault(p => p.ProductId == id);

            if (productDetails == null)
            {
                TempData["error"] = "Ürün bulunamadı";
                return RedirectToAction("Index");
            }

            return View(productDetails);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = db.Products.Find(id);
            if (product == null)
            {
                return RedirectToAction("Index");
            }

            var categories = db.Categories.ToList();
            var suppliers = db.Suppliers.ToList();

            ViewBag.Categories = new SelectList(categories, "CategoryId", "CategoryName", product.CategoryId);
            ViewBag.Suppliers = new SelectList(suppliers, "SupplierId", "CompanyName", product.SupplierId);

            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var categories = db.Categories.ToList();
                    var suppliers = db.Suppliers.ToList();

                    ViewBag.Categories = new SelectList(categories, "CategoryId", "CategoryName", product.CategoryId);
                    ViewBag.Suppliers = new SelectList(suppliers, "SupplierId", "CompanyName", product.SupplierId);

                    return View(product);
                }

                db.Update(product);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                // Hata işlemleri
                // Burada hata durumunda yapılacak işlemleri ekleyebilirsiniz, örneğin loglama veya kullanıcıya hata mesajı gösterme
            }

            return View(product);
        }



        [HttpGet]
        public IActionResult Create()
        {
            var categories = db.Categories.ToDictionary(c => c.CategoryId, c => c.CategoryName);
            var suppliers = db.Suppliers.ToDictionary(s => s.SupplierId, s => s.CompanyName);

            ViewBag.Categories = new SelectList(categories, "Key", "Value");
            ViewBag.Suppliers = new SelectList(suppliers, "Key", "Value");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            var categories = db.Categories.ToDictionary(c => c.CategoryId, c => c.CategoryName);
            var suppliers = db.Suppliers.ToDictionary(s => s.SupplierId, s => s.CompanyName);

            categories.Add(0, "Yeni Ekle");
            ViewBag.Categories = new SelectList(categories, "Key", "Value", product.CategoryId);
            ViewBag.Suppliers = new SelectList(suppliers, "Key", "Value", product.SupplierId);

            return View(product);
        }
        public IActionResult Delete(int id)
        {
            try
            {
                var silinecek = db.Products.Find(id);
                if (silinecek == null)
                {
                    return RedirectToAction("Index");
                }
                db.Products.Remove(silinecek);
                db.SaveChanges();
            }
            catch (Exception)
            {
            }
            return RedirectToAction("Index");
        }


    }
}
