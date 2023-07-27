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
    public class ProductCategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductCategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProductCategories
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ProductCategorie.Include(p => p.Category).Include(p => p.Product);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ProductCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProductCategorie == null)
            {
                return NotFound();
            }

            var productCategorie = await _context.ProductCategorie
                .Include(p => p.Category)
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.ProductCategoryId == id);
            if (productCategorie == null)
            {
                return NotFound();
            }

            return View(productCategorie);
        }

        // GET: ProductCategories/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Set<Category>(), "CategoryId", "CategoryName");
            ViewData["ProductId"] = new SelectList(_context.Product, "ProductId", "Title");
            return View();
        }

        // POST: ProductCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductCategoryId,CategoryId,ProductId")] ProductCategorie productCategorie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productCategorie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Set<Category>(), "CategoryId", "CategoryName", productCategorie.CategoryId);
            ViewData["ProductId"] = new SelectList(_context.Product, "ProductId", "Title", productCategorie.ProductId);
            return View(productCategorie);
        }

        // GET: ProductCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProductCategorie == null)
            {
                return NotFound();
            }

            var productCategorie = await _context.ProductCategorie.FindAsync(id);
            if (productCategorie == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Set<Category>(), "CategoryId", "CategoryName", productCategorie.CategoryId);
            ViewData["ProductId"] = new SelectList(_context.Product, "ProductId", "Title", productCategorie.ProductId);
            return View(productCategorie);
        }

        // POST: ProductCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductCategoryId,CategoryId,ProductId")] ProductCategorie productCategorie)
        {
            if (id != productCategorie.ProductCategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productCategorie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductCategorieExists(productCategorie.ProductCategoryId))
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
            ViewData["CategoryId"] = new SelectList(_context.Set<Category>(), "CategoryId", "CategoryName", productCategorie.CategoryId);
            ViewData["ProductId"] = new SelectList(_context.Product, "ProductId", "Title", productCategorie.ProductId);
            return View(productCategorie);
        }

        // GET: ProductCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProductCategorie == null)
            {
                return NotFound();
            }

            var productCategorie = await _context.ProductCategorie
                .Include(p => p.Category)
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.ProductCategoryId == id);
            if (productCategorie == null)
            {
                return NotFound();
            }

            return View(productCategorie);
        }

        // POST: ProductCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProductCategorie == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ProductCategorie'  is null.");
            }
            var productCategorie = await _context.ProductCategorie.FindAsync(id);
            if (productCategorie != null)
            {
                _context.ProductCategorie.Remove(productCategorie);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductCategorieExists(int id)
        {
          return (_context.ProductCategorie?.Any(e => e.ProductCategoryId == id)).GetValueOrDefault();
        }
    }
}
