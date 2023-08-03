using DirectSales04.Areas.Identity.Data;
using DirectSales04.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace DirectSales04.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _dbContext;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public IActionResult Index(int orderBy = 0, int? categoryId = 0)
        {
            List<Product> products = _dbContext.Product.ToList();


            if (categoryId > 0)
            {
                products = products.Where(
                    p => _dbContext.ProductCategorie.Where(
                            pc => pc.CategoryId == categoryId
                        ).Select(
                            pc => pc.ProductId
                        ).ToList().Contains(
                            p.ProductId
                        )
                ).ToList();
            }


            switch (orderBy)
            {
                case 1: products = products.OrderBy(p => p.Title).ToList(); break;
                case 2: products = products.OrderByDescending(p => p.Title).ToList(); break;
                case 3: products = products.OrderBy(p => p.Price).ToList(); break;
                case 4: products = products.OrderByDescending(p => p.Price).ToList(); break;
            }

            ViewBag.Categories = _dbContext.Category.ToList();

            products = products.Take(10).ToList();

            return View(products);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _dbContext.Product == null)
            {
                return NotFound();
            }

            var product = await _dbContext.Product
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }


    }
}