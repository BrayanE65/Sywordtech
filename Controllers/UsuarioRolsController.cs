using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sywordtech.Data;
using Sywordtech.Models;

namespace Sywordtech.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class UsuarioRolsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UsuarioRolsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: UsuarioRols
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.UserRoles.Include(u => u.Rol).Include(u => u.Usuario);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: UsuarioRols/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.UserRoles == null)
            {
                return NotFound();
            }

            var usuarioRol = await _context.UserRoles
                .Include(u => u.Rol)
                .Include(u => u.Usuario)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (usuarioRol == null)
            {
                return NotFound();
            }

            return View(usuarioRol);
        }

        // GET: UsuarioRols/Create
        public IActionResult Create()
        {
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Name");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "UserName");
            return View();
        }

        // POST: UsuarioRols/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,RoleId")] UsuarioRol usuarioRol)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuarioRol);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Id", usuarioRol.RoleId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", usuarioRol.UserId);
            return View(usuarioRol);
        }

        // GET: UsuarioRols/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.UserRoles == null)
            {
                return NotFound();
            }

            var usuarioRol = await _context.UserRoles.FindAsync(id);
            if (usuarioRol == null)
            {
                return NotFound();
            }
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Id", usuarioRol.RoleId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", usuarioRol.UserId);
            return View(usuarioRol);
        }

        // POST: UsuarioRols/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("UserId,RoleId")] UsuarioRol usuarioRol)
        {
            if (id != usuarioRol.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuarioRol);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioRolExists(usuarioRol.UserId))
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
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Id", usuarioRol.RoleId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", usuarioRol.UserId);
            return View(usuarioRol);
        }

        // GET: UsuarioRols/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.UserRoles == null)
            {
                return NotFound();
            }

            var usuarioRol = await _context.UserRoles
                .Include(u => u.Rol)
                .Include(u => u.Usuario)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (usuarioRol == null)
            {
                return NotFound();
            }

            return View(usuarioRol);
        }

        // POST: UsuarioRols/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.UserRoles == null)
            {
                return Problem("Entity set 'ApplicationDbContext.UserRoles'  is null.");
            }
            var usuarioRol = await _context.UserRoles.FindAsync(id);
            if (usuarioRol != null)
            {
                _context.UserRoles.Remove(usuarioRol);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioRolExists(string id)
        {
          return (_context.UserRoles?.Any(e => e.UserId == id)).GetValueOrDefault();
        }
    }
}
