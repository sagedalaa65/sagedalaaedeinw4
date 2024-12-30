using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sagedalaaedeinw4.Contexts;
using sagedalaaedeinw4.Models.entities;

namespace sagedalaaedeinw4.Controllers
{
    public class CustomerController : Controller
    {
        ProjectDbContext dbContext = new ProjectDbContext();
        // GET: CustomerController
        public ActionResult Index()
        {
            var customer = dbContext.customers.ToList();
            return View(customer);
        }

        // GET: CustomerController/Details/5
        public ActionResult Details(int id)
        {
            var cutomer = dbContext.customers.Where(c => c.Id == id).FirstOrDefault();
            return View(cutomer);
        }


        public ActionResult Orders(int id)
        {

            var orders = dbContext.orders.Where(o => o.CustomerId == id).ToList();

            return View(orders);
        }

        // GET: CustomerController/Create
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            dbContext.customers.Add(customer);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: CustomerController/Create
      /*  [HttpPost]
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
        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {

            var customer = dbContext.customers.Where(c => c.Id == id).FirstOrDefault();

            if (customer == null)
            {
                return NotFound();
            }

            return View();
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Customer collection)
        {
            try
            {

                var customer = dbContext.customers.Where(c => c.Id == id).FirstOrDefault();

                if (customer == null)
                {
                    return NotFound();
                }
                customer.Name = collection.Name;
                customer.Email = collection.Email;
                customer.Phone = collection.Phone;
                customer.Address = collection.Address;
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
        {
            var customer = dbContext.customers.Where(c => c.Id == id).FirstOrDefault();

            dbContext.customers.Remove(customer);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: CustomerController/Delete/5
        /*[HttpPost]
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
