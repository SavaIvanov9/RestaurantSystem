namespace RestaurantSystem.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using RestaurantSystem.Data.Abstraction;
    using RestaurantSystem.Models;
    using System.Linq;

    public class ProductController : BaseController
    {
        public ProductController(IRestaurantSystemData data) : base(data)
        {
        }

        public IActionResult Index()
        {
            var products = this.Data.Products
                .All()
                .Where(x => x.IsDeleted != true);

            return View(products.ToList());
        }

        public IActionResult Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = this.Data.Products
             .All()
             .FirstOrDefault(m => m.Id == id && m.IsDeleted != true);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        public IActionResult Create()
        {
            ViewData["MeasuringUnitId"] = new SelectList(
                this.Data.MeasuringUnits
                    .All()
                    .Where(x => x.IsDeleted != true)
                    .ToList(),
                    "Id", "Name");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,CreatedOn,ModifiedOn,MeasuringUnitId,AveragePrice")] Product product)
        {
            if (ModelState.IsValid)
            {
                this.Data.Products.Add(product);
                this.Data.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewData["MeasuringUnitId"] = new SelectList(
                this.Data.MeasuringUnits
                    .All()
                    .Where(x => x.IsDeleted != true)
                    .ToList(), 
                "Id", "Name", product.MeasuringUnitId);

            return View(product);
        }

        public IActionResult Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = this.Data.Products
           .All()
           .FirstOrDefault(m => m.Id == id && m.IsDeleted != true);

            if (product == null)
            {
                return NotFound();
            }

            ViewData["MeasuringUnitId"] = new SelectList(
                this.Data.MeasuringUnits
                    .All()
                    .Where(x => x.IsDeleted != true)
                    .ToList(),
                    "Id", "Name", product.MeasuringUnitId);

            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(long id, [Bind("Id,Name,CreatedOn,ModifiedOn,MeasuringUnitId,AveragePrice")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    this.Data.Products.Update(product);
                    this.Data.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction("Index");
            }

            ViewData["MeasuringUnitId"] = new SelectList(
                this.Data.MeasuringUnits
                    .All()
                    .Where(x => x.IsDeleted != true)
                    .ToList(), 
                "Id", "Name", product.MeasuringUnitId);

            return View(product);
        }

        public IActionResult Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = this.Data.Products
                .All()
                .FirstOrDefault(m => m.Id == id && m.IsDeleted != true);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(long id)
        {
            var product = this.Data.Products
                .All()
                .FirstOrDefault(m => m.Id == id && m.IsDeleted != true);

            product.IsDeleted = true;

            this.Data.Products.Update(product);
            this.Data.SaveChanges();

            return RedirectToAction("Index");
        }

        private bool ProductExists(long id)
        {
            return this.Data.Products
                .All()
                .Any(e => e.Id == id && e.IsDeleted != true);
        }
    }
}
