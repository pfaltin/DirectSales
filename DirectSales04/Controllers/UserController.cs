using DirectSales04.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace DirectSales04.Controllers
{
    
    [Authorize(Roles = "Admins")]
    public class UserController : Controller
    {


        private readonly ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;

        public UserController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }


        // Create User
        // GET: User/Create
        public IActionResult Create()

        {
            string id = Guid.NewGuid().ToString();
            ViewBag.newid = id;

            return View();
        }


        [HttpPost]
        public async Task<ActionResult> Create(ApplicationUser user, string password)
        {
            // Dodaj ulogu korisniku koji se registrira preko stranica (Customer)


            var result = await _userManager.CreateAsync(user, password);
            var customerRole = _roleManager.FindByNameAsync("Customers").Result;

            if (customerRole != null)
            {
                await _userManager.AddToRoleAsync(user, customerRole.Name);
            }


            return View(user);
        }

        // Read User
        public async Task<ActionResult> Details(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            // Pass the user object to the view for display
            return View(user);
        }

        public async Task<ActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();
            // Pass the list of users to the view for display
            return View(users);
        }

        // Update User
        // GET: User/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var applicationUser = await _context.Users.FindAsync(id);
            if (applicationUser == null)
            {
                return NotFound();
            }
            return View(applicationUser);
        }



        [HttpPost]
        public async Task<ActionResult> Edit(ApplicationUser user)
        {
            var result = await _userManager.UpdateAsync(user);
            
            return View(user);
        }




        // GET: User/Delete/5
        public async Task<IActionResult> DeleteUser(string id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var applicationUser = await _context.Users.FindAsync(id);
            if (applicationUser == null)
            {
                return NotFound();
            }
            return View(applicationUser);
        }

        // Delete User
        [HttpPost]
        public async Task<ActionResult> Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            var result = await _userManager.DeleteAsync(user);
            // Handle the result and redirect or return appropriate response
            var users = await _userManager.Users.ToListAsync();
            return View("Index",users);
        }







    }
}
