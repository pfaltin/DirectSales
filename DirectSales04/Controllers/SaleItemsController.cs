using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DirectSales04.Areas.Identity.Data;
using DirectSales04.Models;

namespace DirectSales04.Controllers
{
    public class SaleItemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SaleItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SaleItems
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.SaleItem.Include(s => s.Product).Include(s => s.Sale);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: SaleItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SaleItem == null)
            {
                return NotFound();
            }

            var saleItem = await _context.SaleItem
                .Include(s => s.Product)
                .Include(s => s.Sale)
                .FirstOrDefaultAsync(m => m.SaleItemID == id);
            if (saleItem == null)
            {
                return NotFound();
            }

            return View(saleItem);
        }

        // GET: SaleItems/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.Product, "ProductId", "Title");
            ViewData["SaleId"] = new SelectList(_context.Sale, "SalesId", "SalesId");
            return View();
        }

        // POST: SaleItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SaleItemID,SaleId,ProductId,Price,Quantity,Discount,SubTotal,Status")] SaleItem saleItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(saleItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Product, "ProductId", "Title", saleItem.ProductId);
            ViewData["SaleId"] = new SelectList(_context.Sale, "SalesId", "SalesId", saleItem.SaleId);
            return View(saleItem);
        }

        // GET: SaleItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SaleItem == null)
            {
                return NotFound();
            }

            var saleItem = await _context.SaleItem.FindAsync(id);
            if (saleItem == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Product, "ProductId", "Title", saleItem.ProductId);
            ViewData["SaleId"] = new SelectList(_context.Sale, "SalesId", "SalesId", saleItem.SaleId);
            return View(saleItem);
        }

        // POST: SaleItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SaleItemID,SaleId,ProductId,Price,Quantity,Discount,SubTotal,Status")] SaleItem saleItem)
        {
            if (id != saleItem.SaleItemID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(saleItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SaleItemExists(saleItem.SaleItemID))
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
            ViewData["ProductId"] = new SelectList(_context.Product, "ProductId", "Title", saleItem.ProductId);
            ViewData["SaleId"] = new SelectList(_context.Sale, "SalesId", "SalesId", saleItem.SaleId);
            return View(saleItem);
        }

        // GET: SaleItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SaleItem == null)
            {
                return NotFound();
            }

            var saleItem = await _context.SaleItem
                .Include(s => s.Product)
                .Include(s => s.Sale)
                .FirstOrDefaultAsync(m => m.SaleItemID == id);
            if (saleItem == null)
            {
                return NotFound();
            }

            return View(saleItem);
        }

        // POST: SaleItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SaleItem == null)
            {
                return Problem("Entity set 'ApplicationDbContext.SaleItem'  is null.");
            }
            var saleItem = await _context.SaleItem.FindAsync(id);
            if (saleItem != null)
            {
                _context.SaleItem.Remove(saleItem);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SaleItemExists(int id)
        {
          return (_context.SaleItem?.Any(e => e.SaleItemID == id)).GetValueOrDefault();
        }
    }
}
