using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sagedalaaedeinw4.Contexts;
using sagedalaaedeinw4.Models.entities;

namespace sagedalaaedeinw4.Controllers
{
    public class ProductController : Controller
    {
        ProjectDbContext dbContext = new ProjectDbContext();
        // GET: ProductController
        public ActionResult Index()
        {
            var allProducts = dbContext.products.ToList();
            return View(allProducts);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            var product = dbContext.products.Where(p => p.Id == id).FirstOrDefault();
            return View(product);
        }

        // GET: ProductController/Create
        [HttpPost]
        public ActionResult Create(Product product)
        {

            dbContext.products.Add(product);
            dbContext.SaveChanges();

            return RedirectToAction("Index");
            
        }

        // POST: ProductController/Create
        /*
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        */
        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {

            var product = dbContext.products.Where(p => p.Id == id).FirstOrDefault();

            if (product == null)
            {
                return NotFound();
            }

            return View();
           
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Product collection)
        {
            try
            {
                var product = dbContext.products.Where(p => p.Id == id).FirstOrDefault();

                if (product == null)
                {
                    return NotFound();
                }
                product.Name = collection.Name;
                product.Description = collection.Description;
                product.Price = collection.Price;
                product.StockQuantity = collection.StockQuantity;
                product.Category = collection.Category;

                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(collection);


            }

        }
        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            var product = dbContext.products.Where(p => p.Id == id).FirstOrDefault();

            dbContext.products.Remove(product);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
/*
        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
*/
    }
}
