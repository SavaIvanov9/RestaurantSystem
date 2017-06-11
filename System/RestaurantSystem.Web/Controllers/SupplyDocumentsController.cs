namespace RestaurantSystem.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using RestaurantSystem.Data.Abstraction;
    using RestaurantSystem.Models;
    using RestaurantSystem.Web.Models;
    using System.Linq;
    using System.Threading.Tasks;
    using RestaurantSystem.Data;

    public class SupplyDocumentsController : BaseController
    {
        public SupplyDocumentsController(IRestaurantSystemData data) : base(data)
        {
        }

        public IActionResult Index()
        {
            var documents = this.Data.SupplyDocuments
                .All()
                .Where(x => x.IsDeleted != true)
                .ToList();

            return View(documents);
        }

        public IActionResult Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplyDocument = this.Data.SupplyDocuments
                .All()
                .FirstOrDefault(m => m.Id == id && m.IsDeleted != true);

            if (supplyDocument == null)
            {
                return NotFound();
            }

            return View(supplyDocument);
        }

        public IActionResult Create()
        {
            ViewData["SupplierId"] = new SelectList(
                this.Data.Suppliers
                    .All()
                    .Where(x => x.IsDeleted != true)
                    .ToList(),
                "Id", "Name");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,CreatedOn,ModifiedOn,ReferenceNumber,DocumentDate,SupplierId")] SupplyDocument supplyDocument)
        {
            if (ModelState.IsValid)
            {
                this.Data.SupplyDocuments.Add(supplyDocument);
                this.Data.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewData["SupplierId"] = new SelectList(
                this.Data.Suppliers
                    .All()
                    .Where(x => x.IsDeleted != true)
                    .ToList(),
                "Id", "Name", supplyDocument.SupplierId);

            return View(supplyDocument);
        }

        public IActionResult Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplyDocument = this.Data.SupplyDocuments
                .All()
                .FirstOrDefault(m => m.Id == id && m.IsDeleted != true);

            if (supplyDocument == null)
            {
                return NotFound();
            }

            ViewData["SupplierId"] = new SelectList(
                this.Data.Suppliers
                    .All()
                    .Where(x => x.IsDeleted != true)
                    .ToList(), 
                "Id", "Name", supplyDocument.SupplierId);

            return View(supplyDocument);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(long id, [Bind("Id,CreatedOn,ModifiedOn,ReferenceNumber,DocumentDate,SupplierId")] SupplyDocument supplyDocument)
        {
            if (id != supplyDocument.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    this.Data.SupplyDocuments.Update(supplyDocument);
                    this.Data.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SupplyDocumentExists(supplyDocument.Id))
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

            ViewData["SupplierId"] = new SelectList(
                this.Data.Suppliers
                    .All()
                    .Where(x => x.IsDeleted != true)
                    .ToList(), 
                "Id", "Name", supplyDocument.SupplierId);

            return View(supplyDocument);
        }

        public IActionResult Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplyDocument = this.Data.SupplyDocuments
                .All()
                .FirstOrDefault(m => m.Id == id && m.IsDeleted != true);

            if (supplyDocument == null)
            {
                return NotFound();
            }

            return View(supplyDocument);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(long id)
        {
            var supplyDocument = this.Data.SupplyDocuments
               .All()
               .FirstOrDefault(m => m.Id == id && m.IsDeleted != true);

            supplyDocument.IsDeleted = true;

            this.Data.SupplyDocuments.Update(supplyDocument);
            this.Data.SaveChanges();

            return RedirectToAction("Index");
        }

        private bool SupplyDocumentExists(long id)
        {
            return this.Data.SupplyDocuments
                .All()
                .Any(e => e.Id == id && e.IsDeleted != true);
        }
    }
}
