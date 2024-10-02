using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_CRUD_Users.Models;

namespace MVC_CRUD_Users.Controllers
{
    public class UsersController : Controller
    {
        private readonly MvccrudusersContext _db;

        public UsersController(MvccrudusersContext context)
        {
            _db = context;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            return View(await _db.Users.ToListAsync());
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Id == id);
            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,Password,CreatedAt,UpdatedAt,Role")] User user)
        {
            _db.Add(user);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var user = await _db.Users.FindAsync(id);
            return View(user);
        }

        // POST: Users/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,Password,CreatedAt,UpdatedAt,Role")] User user)
        {
            _db.Update(user);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var user = await _db.Users.FirstOrDefaultAsync(m => m.Id == id);
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _db.Users.FindAsync(id);
            _db.Users.Remove(user);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
