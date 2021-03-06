namespace RestaurantSystem.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using RestaurantSystem.Data.Abstraction;
    using RestaurantSystem.Models;
    using System.Linq;

    public class WaiterController : BaseController
    {
        public WaiterController(IRestaurantSystemData data) : base(data)
        {
        }

        public IActionResult Index()
        {
            return View(this.Data.Waiters
                .All()
                .Where(x => x.IsDeleted != true)
                .ToList());
        }

        public IActionResult Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var waiter = this.Data.Waiters
                .All()
                .FirstOrDefault(m => m.Id == id && m.IsDeleted != true);

            if (waiter == null)
            {
                return NotFound();
            }

            return View(waiter);
        }

        // GET: Waiter/Create
        public IActionResult Create()
        {
            ViewData["ManagerId"] = new SelectList(
                this.Data.Waiters
                .All()
                .Where(m => m.IsDeleted != true)
                .ToList(),
            "Id", "Name");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,ManagerId,CreatedOn,ModifiedOn")] Waiter waiter)
        {
            if (ModelState.IsValid)
            {
                this.Data.Waiters.Add(waiter);
                this.Data.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewData["ManagerId"] = new SelectList(
                this.Data.Waiters
                    .All()
                    .Where(m => m.IsDeleted != true)
                    .ToList(),
                "Id", "Name", waiter.ManagerId);

            return View(waiter);
        }

        public IActionResult Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var waiter = this.Data.Waiters
                .All()
                .FirstOrDefault(m => m.Id == id && m.IsDeleted != true);

            if (waiter == null)
            {
                return NotFound();
            }

            ViewData["ManagerId"] = new SelectList(
                this.Data.Waiters
                    .All()
                    .Where(m => m.IsDeleted != true)
                    .ToList(),
                "Id", "Name", waiter.ManagerId);

            return View(waiter);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(long id, [Bind("Id,Name,ManagerId,CreatedOn,ModifiedOn")] Waiter waiter)
        {
            if (id != waiter.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    this.Data.Waiters.Update(waiter);

                    this.Data.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WaiterExists(waiter.Id))
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

            ViewData["ManagerId"] = new SelectList(
                this.Data.Waiters
                    .All()
                    .Where(m => m.IsDeleted != true)
                    .ToList(), 
                "Id", "Name", waiter.ManagerId);

            return View(waiter);
        }

        public IActionResult Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var waiter = this.Data.Waiters
                .All()
                .FirstOrDefault(m => m.Id == id && m.IsDeleted != true);

            if (waiter == null)
            {
                return NotFound();
            }

            return View(waiter);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(long id)
        {
            var waiter = this.Data.Waiters
                 .All()
                 .FirstOrDefault(m => m.Id == id && m.IsDeleted != true);

            waiter.IsDeleted = true;
            this.Data.Waiters.Update(waiter);
            this.Data.SaveChanges();

            return RedirectToAction("Index");
        }

        private bool WaiterExists(long id)
        {
            return this.Data.Waiters
                .All()
                .Any(e => e.Id == id && e.IsDeleted != true);
        }
    }
}
