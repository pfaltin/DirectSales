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
    public class SalesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SalesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Sales
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Sale.Include(s => s.Client);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Sales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Sale == null)
            {
                return NotFound();
            }

            var sale = await _context.Sale
                .Include(s => s.Client)
                .FirstOrDefaultAsync(m => m.SalesId == id);
            if (sale == null)
            {
                return NotFound();
            }


            var saleItems = _context.SaleItem.Where(s => s.SaleId == id).Include(s => s.Product).ToList();
            if (saleItems == null)
            {
                return NotFound();
            }

            ViewData["saleItems"] = saleItems;


            return View(sale);
        }

        // GET: ActiveSales
        public async Task<IActionResult> ActiveSales()
        {
            List<Sale> activeSales = new List<Sale>();
            foreach (var sale in _context.Sale.Include(s => s.Client))
            {
                if (SaleActive(sale.SalesId))
                {
                    activeSales.Add(sale);
                }
            }

            return View(activeSales);

        }


        // GET: Sales/Create
        public IActionResult Create()
        {
            ViewData["ClientId"] = new SelectList(_context.Client, "ClientId", "City");
            return View();
        }

        // POST: Sales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SalesId,ClientId,Date,Remarks")] Sale sale)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sale);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientId"] = new SelectList(_context.Client, "ClientId", "City", sale.ClientId);
            return View(sale);
        }

        // GET: Sales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Sale == null)
            {
                return NotFound();
            }

            var sale = await _context.Sale.FindAsync(id);
            if (sale == null)
            {
                return NotFound();
            }
            ViewData["ClientId"] = new SelectList(_context.Client, "ClientId", "City", sale.ClientId);
            return View(sale);
        }

        // POST: Sales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SalesId,ClientId,Date,Remarks")] Sale sale)
        {
            if (id != sale.SalesId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sale);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SaleExists(sale.SalesId))
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
            ViewData["ClientId"] = new SelectList(_context.Client, "ClientId", "City", sale.ClientId);
            return View(sale);
        }

        // GET: Sales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Sale == null)
            {
                return NotFound();
            }

            var sale = await _context.Sale
                .Include(s => s.Client)
                .FirstOrDefaultAsync(m => m.SalesId == id);
            if (sale == null)
            {
                return NotFound();
            }

            return View(sale);
        }

        // POST: Sales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Sale == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Sale'  is null.");
            }
            var sale = await _context.Sale.FindAsync(id);
            if (sale != null)
            {
                _context.Sale.Remove(sale);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SaleExists(int id)
        {
          return (_context.Sale?.Any(e => e.SalesId == id)).GetValueOrDefault();
        }



        private bool SaleActive(int id)
        {
            bool status = false;

            if (_context.SaleItem.Any(s => s.SaleItemID == id &&
            (s.Status == ItemStatus.Ordered || s.Status == ItemStatus.IsAcquired || s.Status == ItemStatus.ForDelivery)))
            { status = true; }
            return status;
        }
        private List<SaleItem> SalesItems(int id)
        {


            var sales = _context.SaleItem.Where(s => s.SaleItemID == id).ToList();

            return sales;
        }

        private string SalesSatus(int id)
        {
            string status = "not_active";
            var salesItem = SalesItems(id);
            foreach (var item in salesItem)
            {
                if (item.Status == ItemStatus.Ordered || item.Status == ItemStatus.IsAcquired || item.Status == ItemStatus.ForDelivery)
                { status = "active"; }
                if (item.Status == ItemStatus.Delivered)
                { status = "active"; }
                else
                {
                    status = "active";
                }

            }

            return status;
        }


        // GET: SaleItems/Details/5
        public async Task<IActionResult> SaleItemsDetails(int? id)
        {
            if (id == null || _context.SaleItem == null)
            {
                return NotFound();
            }

            var saleItem = await _context.SaleItem
                .Include(s => s.ProductId)
                .Include(s => s.Sale)
                .FirstOrDefaultAsync(m => m.SaleItemID == id);
            if (saleItem == null)
            {
                return NotFound();
            }

            return View(saleItem);
        }

        // GET: SaleItems/Create
        public IActionResult SaleItemsCreate()
        {
            ViewData["ProductId"] = new SelectList(_context.Product, "ProductId", "Title");
            ViewData["Product"] = new SelectList(_context.Product, "ProductId", "Title", "Price");
            int routeid = Int32.Parse((string)RouteData.Values["id"]);
            ViewData["SaleId"] = routeid;






            var selectList = new SelectList(_context.Product, "ProductId", "Title", "Price");

            // Pass the SelectList to the view
            ViewBag.SelectList = selectList;



            return View();
        }

        // POST: SaleItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaleItemsCreate([Bind("SaleItemID,SaleId,ProductId,Quantity,Discount,SubTotal,Status")] SaleItem saleItem)
        {
            if (ModelState.IsValid)
            {
                _context.SaleItem.Add(saleItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Product, "ProductId", "Title", saleItem.ProductId);
            ViewData["SaleId"] = new SelectList(_context.Sale, "SalesId", "SalesId", saleItem.SaleId);
            return View(saleItem);
        }

        // GET: SaleItems/Edit/5
        public async Task<IActionResult> SaleItemsEdit(int? id)
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
        public async Task<IActionResult> SaleItemsEdit(int id, [Bind("SaleItemID,SaleId,ProductId,Quantity,Discount,SubTotal,Status")] SaleItem saleItem)
        {
            if (id != saleItem.SaleItemID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.SaleItem.Update(saleItem);
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
        public async Task<IActionResult> SaleItemsDelete(int? id)
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
        [HttpPost, ActionName("SaleItemsDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaleItemsDeleteConfirmed(int id)
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
