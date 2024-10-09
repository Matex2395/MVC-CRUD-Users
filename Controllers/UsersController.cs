using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_CRUD_Users.Models;

namespace MVC_CRUD_Users.Controllers
{
    [Authorize]
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
            if (id == null)
            {
                TempData["ErrorMessage"] = "No se ha proporcionado un ID.";
                return NotFound();
            }

            var user = await _db.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user == null)
            {
                TempData["ErrorMessage"] = "El usuario no existe";
                return NotFound();
            }

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
            if (ModelState.IsValid)
            {
                _db.Add(user);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            } else
            {
                TempData["ErrorMessage"] = "Hubo un error al procesar la solicitud. Por favor, verifica los campos ingresados y vuelve a intentarlo.";
            }
            return View(user);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                TempData["ErrorMessage"] = "No se ha proporcionado un ID.";
                return NotFound();
            }

            var user = await _db.Users.FindAsync(id);
            if (user == null)
            {
                TempData["ErrorMessage"] = "Usuario no encontrado";
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,Password,CreatedAt,UpdatedAt,Role")] User user)
        {
            if (id != user.Id)
            {
                TempData["ErrorMessage"] = "Los IDs no coinciden";
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(user);
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
                    {
                        TempData["ErrorMessage"] = "El usuario no existe";
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["ErrorMessage"] = "Hubo un error al procesar la solicitud. Por favor, verifica los campos ingresados y vuelve a intentarlo.";
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) 
            {
                TempData["ErrorMessage"] = "No se ha proporcionado un ID.";
                return NotFound();
            }

            var user = await _db.Users.FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                TempData["ErrorMessage"] = "Usuario no encontrado";
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _db.Users.FindAsync(id);
            if (user != null)
            {
                _db.Users.Remove(user);
            }
            else
            {
                TempData["ErrorMessage"] = "Usuario no encontrado";
            }

            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _db.Users.Any(u => u.Id == id);
        }
    }
}
