using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NextGenInventories_4.Data;
using NextGenInventories_4.Models;

namespace NextGenInventories_4.Controllers
{
    public class InventoryDatesController : Controller
    {
        private readonly NextGenInventories_4Context _context;

        public InventoryDatesController(NextGenInventories_4Context context)
        {
            _context = context;
        }

        [HttpPost]
        public string Index(string searchString, bool notUsed)
        {
            return "From [HttpPost]Index: filter on " + searchString;
        }

        // GET: InventoryDates
        public async Task<IActionResult> Index(string searchString)
        {
            if (_context.InventoryDate == null)
            {
                return Problem("Entity set 'NextGenInventories_4Context.Inventory'  is null.");
            }
            var nextGenInventories_4Context = from p in _context.InventoryDate.Include(i => i.Product) select p;
            if (!String.IsNullOrEmpty(searchString))
            {
                nextGenInventories_4Context = nextGenInventories_4Context.Where(s => s.Product.ProductName!.Contains(searchString));
            }
            return View(await nextGenInventories_4Context.ToListAsync());
        }

        // GET: InventoryDates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.InventoryDate == null)
            {
                return NotFound();
            }

            var inventoryDate = _context.InventoryDate
                .Include(i=>i.Product)
                .Where(p=>p.ProductId==id);
            if (inventoryDate == null)
            {
                return NotFound();
            }

            return View(inventoryDate);
        }

        /*// GET: InventoryDates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.InventoryDate == null)
            {
                return NotFound();
            }

            var inventoryDate = await _context.InventoryDate
                .Include(i => i.Product)
                .FirstOrDefaultAsync(m => m.InventoryDateId == id);
            if (inventoryDate == null)
            {
                return NotFound();
            }

            return View(inventoryDate);
        }*/


        // GET: InventoryDates/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.Product, "ProductId", "ProductName");
            return View();
        }


        // POST: InventoryDates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InventoryDateId,UserId,ProductId,Quantity,DateAdded,DateModified")] InventoryDate inventoryDate)
        {
            
            inventoryDate.DateAdded = DateTime.Today;
            inventoryDate.DateModified = DateTime.Now;
            
            if (ModelState.IsValid)
            {
                _context.Add(inventoryDate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Product, "ProductId", "ProductName", inventoryDate.ProductId);
            return View(inventoryDate);
        }

        // GET: InventoryDates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.InventoryDate == null)
            {
                return NotFound();
            }

            var inventoryDate = await _context.InventoryDate.FindAsync(id);
            if (inventoryDate == null)
            {
                return NotFound();
            }
            
            ViewData["ProductId"] = new SelectList(_context.Product, "ProductId", "ProductName", inventoryDate.ProductId);
            return View(inventoryDate);
        }

        // POST: InventoryDates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InventoryDateId,UserId,ProductId,Quantity,DateAdded,DateModified")] InventoryDate inventoryDate)
        {
            
            if (id != inventoryDate.InventoryDateId)
            {
                return NotFound();
            }
            
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inventoryDate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InventoryDateExists(inventoryDate.InventoryDateId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Product, "ProductId", "ProductName", inventoryDate.ProductId);
            return View(inventoryDate);
        }

        // GET: InventoryDates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.InventoryDate == null)
            {
                return NotFound();
            }

            var inventoryDate = await _context.InventoryDate
                .Include(i => i.Product)
                .FirstOrDefaultAsync(m => m.InventoryDateId == id);
            if (inventoryDate == null)
            {
                return NotFound();
            }

            return View(inventoryDate);
        }

        // POST: InventoryDates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.InventoryDate == null)
            {
                return Problem("Entity set 'NextGenInventories_4Context.InventoryDate'  is null.");
            }
            var inventoryDate = await _context.InventoryDate.FindAsync(id);
            if (inventoryDate != null)
            {
                _context.InventoryDate.Remove(inventoryDate);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InventoryDateExists(int id)
        {
          return (_context.InventoryDate?.Any(e => e.InventoryDateId == id)).GetValueOrDefault();
        }
    }
}
