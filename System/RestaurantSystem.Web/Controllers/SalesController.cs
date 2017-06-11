using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RestaurantSystem.Models;
using RestaurantSystem.Web.Models;
using RestaurantSystem.Data.Abstraction;

namespace RestaurantSystem.Web.Controllers
{
    public class SalesController : BaseController
    {
        public SalesController(IRestaurantSystemData data) : base(data)
        {
        }

        public IActionResult Index()
        {
            var sales = this.Data.Sales
                .All()
                .Where(x => x.IsDeleted != true);

            return View(sales.ToList());
        }

        public IActionResult Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sale = this.Data.Sales
                .All()
                .FirstOrDefault(m => m.Id == id && m.IsDeleted != true);

            if (sale == null)
            {
                return NotFound();
            }

            return View(sale);
        }

        public IActionResult Create()
        {
            ViewData["RestaurantBranchId"] = new SelectList(this.Data.RestaurantBranches
                    .All()
                    .Where(x => x.IsDeleted != true)
                    .ToList(),
                    "Id", "Name");

            ViewData["WaiterId"] = new SelectList(
                this.Data.Waiters
                    .All()
                    .Where(x => x.IsDeleted != true)
                    .ToList(),
                "Id", "Name");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,RestaurantBranchId,CreatedOn,ModifiedOn,TableNumber,WaiterId")] Sale sale)
        {
            if (ModelState.IsValid)
            {
                this.Data.Sales.Add(sale);
                this.Data.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewData["RestaurantBranchId"] = new SelectList(
                this.Data.RestaurantBranches
                    .All()
                    .Where(x => x.IsDeleted != true)
                    .ToList(),
                "Id", "Name", sale.RestaurantBranchId);

            ViewData["WaiterId"] = new SelectList(
                this.Data.Waiters
                    .All()
                    .Where(x => x.IsDeleted != true)
                    .ToList(),
                "Id", "Name", sale.WaiterId);

            return View(sale);
        }

        public IActionResult Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sale = this.Data.Sales
                .All()
                .FirstOrDefault(m => m.Id == id && m.IsDeleted != true);

            if (sale == null)
            {
                return NotFound();
            }

            ViewData["RestaurantBranchId"] = new SelectList(
                this.Data.RestaurantBranches
                    .All()
                    .Where(x => x.IsDeleted != true)
                    .ToList(), 
                "Id", "Name", sale.RestaurantBranchId);

            ViewData["WaiterId"] = new SelectList(this.Data.Waiters
                    .All()
                    .Where(x => x.IsDeleted != true)
                    .ToList(),
            "Id", "Name", sale.WaiterId);

            return View(sale);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(long id, [Bind("Id,RestaurantBranchId,CreatedOn,ModifiedOn,TableNumber,WaiterId")] Sale sale)
        {
            if (id != sale.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    this.Data.Sales.Update(sale);
                    this.Data.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SaleExists(sale.Id))
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

            ViewData["RestaurantBranchId"] = new SelectList(
                this.Data.RestaurantBranches
                    .All()
                    .Where(x => x.IsDeleted != true)
                    .ToList(), 
                "Id", "Name", sale.RestaurantBranchId);

            ViewData["WaiterId"] = new SelectList(
                this.Data.Waiters
                    .All()
                    .Where(x => x.IsDeleted != true)
                    .ToList(), 
                "Id", "Name", sale.WaiterId);

            return View(sale);
        }

        public IActionResult Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sale = this.Data.Sales
                .All()
                .FirstOrDefault(m => m.Id == id && m.IsDeleted != true);

            if (sale == null)
            {
                return NotFound();
            }

            return View(sale);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(long id)
        {
            var sale = this.Data.Sales
                .All()
                .FirstOrDefault(m => m.Id == id && m.IsDeleted != true);

            sale.IsDeleted = true;

            this.Data.Sales.Update(sale);
            this.Data.SaveChanges();

            return RedirectToAction("Index");
        }

        private bool SaleExists(long id)
        {
            return this.Data.Sales
                .All()
                .Any(e => e.Id == id && e.IsDeleted != true);
        }
    }
}
