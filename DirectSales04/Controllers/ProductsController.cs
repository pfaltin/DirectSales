using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DirectSales04.Areas.Identity.Data;
using DirectSales04.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace DirectSales04.Controllers
{
    [Authorize(Roles = "Admins")]
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
              return _context.Product != null ? 
                          View(await _context.Product.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Product'  is null.");
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Product == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Description,SKU,Image,Price")] Product product,
            IFormFile? ProductImage,
            int categoryId)
        {
            if (ProductImage != null)
            {
                var newImageName = DateTime.Now.ToString("yyyyMMddhhmmss") + "_" + ProductImage.FileName.ToLower().Replace(" ", "_");
                var saveImagePath = Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "wwwroot/images/products",
                    newImageName );
                Directory.CreateDirectory(Path.GetDirectoryName(saveImagePath));
                using (var stream = new FileStream(saveImagePath, FileMode.Create))
                {
                    ProductImage.CopyTo(stream);
                }
                product.Image = newImageName;

            }

            if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Add(product);
                        await _context.SaveChangesAsync();
                        _context.SaveChanges();

                        ProductCategorie productCategory = new ProductCategorie();
                        productCategory.ProductId = product.ProductId;
                        productCategory.CategoryId = categoryId;
                        _context.Add(productCategory);
                        _context.SaveChanges();

                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ProductExists(product.ProductId))
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
            return View(product);
        }







        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Product == null)
            {
                return NotFound();
            }

            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            ViewBag.ProductCategories = _context.ProductCategorie.Where(
                    p => p.ProductId == product.ProductId
                ).Select(
                    c => c.CategoryId
                ).ToList();

            // Ako postoji error poruka, spremi u ViewBag svojstvo
            ViewBag.ErrorMessage = TempData["ErrorMessage"] ?? "";


            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,Title,Image,Description,SKU,Price")] Product product,
           IFormFile? newImage,
           int categoryId)
        {
            if (id != product.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (newImage != null)
                    {
                        var newImageName = DateTime.Now.ToString("yyyyMMddhhmmss") + "_" + newImage.FileName.ToLower().Replace(" ", "_");
                        var saveImagePath = Path.Combine(
                            Directory.GetCurrentDirectory(),
                            "wwwroot/images/products",
                            newImageName
                        );
                        Directory.CreateDirectory(Path.GetDirectoryName(saveImagePath));
                        using (var stream = new FileStream(saveImagePath, FileMode.Create))
                        {
                            newImage.CopyTo(stream);
                        }
                        product.Image = newImageName;

                    }
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                    _context.ProductCategorie.RemoveRange(
                            _context.ProductCategorie.Where(p => p.ProductId == id)
                        );
                    _context.SaveChanges();
                    ProductCategorie productCategory = new ProductCategorie();
                    productCategory.ProductId = product.ProductId;
                    productCategory.CategoryId = categoryId;

                    _context.Add(productCategory);
                    _context.SaveChanges();




                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductId))
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
            return View(product);
        }




        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Product == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Product == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Product'  is null.");
            }
            var product = await _context.Product.FindAsync(id);
            if (product != null)
            {
                _context.Product.Remove(product);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
          return (_context.Product?.Any(e => e.ProductId == id)).GetValueOrDefault();
        }
    }
}
