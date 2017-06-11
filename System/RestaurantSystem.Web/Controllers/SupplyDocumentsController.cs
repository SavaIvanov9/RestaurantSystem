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

        // GET: SupplyDocuments
        public IActionResult Index()
        {
            var documents = this.Data.SupplyDocuments
                .All()
                .Where(x => x.IsDeleted != true)
                .ToList();

            return View(documents);
        }

        // GET: SupplyDocuments/Details/5
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

        // GET: SupplyDocuments/Create
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

        // POST: SupplyDocuments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: SupplyDocuments/Edit/5
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

        // POST: SupplyDocuments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: SupplyDocuments/Delete/5
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

        // POST: SupplyDocuments/Delete/5
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
