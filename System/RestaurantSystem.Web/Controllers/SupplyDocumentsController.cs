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
        //private readonly RestaurantSystemDbContext _context;

        public SupplyDocumentsController(IRestaurantSystemData data) : base(data)
        {
        }

        // GET: SupplyDocuments
        public IActionResult Index()
        {
            var documents = this.Data.SupplyDocuments.All().ToList();

            //return View(await restaurantSystemWebContext.ToListAsync());
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
                .FirstOrDefault(m => m.Id == id);

            if (supplyDocument == null)
            {
                return NotFound();
            }

            return View(supplyDocument);
        }

        // GET: SupplyDocuments/Create
        //public IActionResult Create()
        //{
        //    ViewData["SupplierId"] = new SelectList(this.Data..Set<Supplier>(), "Id", "Name");
        //    return View();
        //}

        // POST: SupplyDocuments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,CreatedOn,ModifiedOn,IsDeleted,ReferenceNumber,DocumentDate,SupplierId")] SupplyDocument supplyDocument)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.SupplyDocument.Add(supplyDocument);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }
        //    ViewData["SupplierId"] = new SelectList(_context.Set<Supplier>(), "Id", "Name", supplyDocument.SupplierId);
        //    return View(supplyDocument);
        //}

        // GET: SupplyDocuments/Edit/5
        //public async Task<IActionResult> Edit(long? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var supplyDocument = await _context.SupplyDocument.SingleOrDefaultAsync(m => m.Id == id);
        //    if (supplyDocument == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["SupplierId"] = new SelectList(_context.Set<Supplier>(), "Id", "Name", supplyDocument.SupplierId);
        //    return View(supplyDocument);
        //}

        // POST: SupplyDocuments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(long id, [Bind("Id,CreatedOn,ModifiedOn,IsDeleted,ReferenceNumber,DocumentDate,SupplierId")] SupplyDocument supplyDocument)
        //{
        //    if (id != supplyDocument.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            //_context.SupplyDocument.Update(supplyDocument);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!SupplyDocumentExists(supplyDocument.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction("Index");
        //    }
        //    ViewData["SupplierId"] = new SelectList(_context.Set<Supplier>(), "Id", "Name", supplyDocument.SupplierId);
        //    return View(supplyDocument);
        //}

        // GET: SupplyDocuments/Delete/5
        //public async Task<IActionResult> Delete(long? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var supplyDocument = await _context.SupplyDocument
        //        .Include(s => s.Supplier)
        //        .SingleOrDefaultAsync(m => m.Id == id);
        //    if (supplyDocument == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(supplyDocument);
        //}

        // POST: SupplyDocuments/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(long id)
        //{
        //    var supplyDocument = await _context.SupplyDocument.SingleOrDefaultAsync(m => m.Id == id);
        //    _context.SupplyDocument.Remove(supplyDocument);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //}

        //private bool SupplyDocumentExists(long id)
        //{
        //    return _context.SupplyDocument.Any(e => e.Id == id);
        //}
    }
}
