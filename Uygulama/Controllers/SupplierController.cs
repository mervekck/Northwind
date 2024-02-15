using Microsoft.AspNetCore.Mvc;
using Uygulama.Models.Entity;

namespace Uygulama.Controllers
{
    public class SupplierController : Controller
    {
        public SupplierController(NorthwindContext dbContext)
        {
            db = dbContext;
        }
        private readonly NorthwindContext db;
        public IActionResult Index()
        {
            var supplierList = db.Suppliers.ToList();
            if (supplierList != null || supplierList.Count != 0)
            {
                return View(supplierList);
            }
            return View();
        }
        public IActionResult Delete(int id)
        {
            try
            {
                var silinecek = db.Suppliers.Find(id);
                if (silinecek == null)
                {
                    return RedirectToAction("Index");
                }
                db.Suppliers.Remove(silinecek);
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
        public IActionResult Create(Supplier supplier)
        {

            if (ModelState.IsValid)
            {
                db.Suppliers.Add(supplier);
                db.SaveChanges();

                int newSupplierId = supplier.SupplierId;


                return RedirectToAction("Index", "Product", new { supplierId = newSupplierId });
            }
            return View(supplier);
        }
        

    }
}
