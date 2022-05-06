#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sywordtech.Data;
using Sywordtech.Models;

namespace Sywordtech.Controllers
{
    public class EspecificacionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EspecificacionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Especificacions
        public async Task<IActionResult> Index()
        {
            return View(await _context.Especificaciones.ToListAsync());
        }

        // GET: Especificacions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var especificacion = await _context.Especificaciones
                .FirstOrDefaultAsync(m => m.ID == id);
            if (especificacion == null)
            {
                return NotFound();
            }

            return View(especificacion);
        }

        // GET: Especificacions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Especificacions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Titulo,Descripcion")] Especificacion especificacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(especificacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(especificacion);
        }

        // GET: Especificacions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var especificacion = await _context.Especificaciones.FindAsync(id);
            if (especificacion == null)
            {
                return NotFound();
            }
            return View(especificacion);
        }

        // POST: Especificacions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Titulo,Descripcion")] Especificacion especificacion)
        {
            if (id != especificacion.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(especificacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EspecificacionExists(especificacion.ID))
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
            return View(especificacion);
        }

        // GET: Especificacions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var especificacion = await _context.Especificaciones
                .FirstOrDefaultAsync(m => m.ID == id);
            if (especificacion == null)
            {
                return NotFound();
            }

            return View(especificacion);
        }

        // POST: Especificacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var especificacion = await _context.Especificaciones.FindAsync(id);
            _context.Especificaciones.Remove(especificacion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EspecificacionExists(int id)
        {
            return _context.Especificaciones.Any(e => e.ID == id);
        }
    }
}
