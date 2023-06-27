﻿using DirectSales04.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DirectSales04.Areas.Admin.Controllers
{
    public class UserController : Controller
    {


        private readonly ApplicationDbContext _context;
        private UserManager<ApplicationUser> userManager;
        private RoleManager<IdentityRole> roleManager;

        public UserController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            _context = context;
        }

        // Create User
        [HttpPost]
        public async Task<ActionResult> Create(ApplicationUser user, string password)
        {
            var result = await userManager.CreateAsync(user, password);
            // Handle the result and redirect or return appropriate response
            return View(user);
        }

        // Read User
        public async Task<ActionResult> Details(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            // Pass the user object to the view for display
            return View(user);
        }

        public async Task<ActionResult> Index()
        {
            var users = await userManager.Users.ToListAsync();
            // Pass the list of users to the view for display
            return View(users);
        }

        // Update User
        [HttpPost]
        public async Task<ActionResult> Edit(ApplicationUser user)
        {
            var result = await userManager.UpdateAsync(user);
            // Handle the result and redirect or return appropriate response
            return View(user);
        }

        // Delete User
        [HttpPost]
        public async Task<ActionResult> Delete(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            var result = await userManager.DeleteAsync(user);
            // Handle the result and redirect or return appropriate response
            return View();
        }







    }
}
