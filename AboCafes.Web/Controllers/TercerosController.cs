using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AboCafes.Common.Entities;
using AboCafes.Web.Data;

namespace AboCafes.Web.Controllers
{
    public class TercerosController : Controller
    {
        private readonly DataContext _context;

        public TercerosController(DataContext context)
        {
            _context = context;
        }

        // GET: Terceros
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.Terceros.Include(t => t.Ciudad);
            return View(await dataContext.ToListAsync());
        }

        // GET: Terceros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tercero = await _context.Terceros
                .Include(t => t.Ciudad)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tercero == null)
            {
                return NotFound();
            }

            return View(tercero);
        }

        // GET: Terceros/Create
        public IActionResult Create()
        {
            ViewData["CiudadId"] = new SelectList(_context.Ciudades, "Id", "Name");
            return View();
        }

        // POST: Terceros/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Documento,Nombre,Direccion,Telefono,Email,CiudadId")] Tercero tercero)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tercero);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CiudadId"] = new SelectList(_context.Ciudades, "Id", "Name", tercero.CiudadId);
            return View(tercero);
        }

        // GET: Terceros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tercero = await _context.Terceros.FindAsync(id);
            if (tercero == null)
            {
                return NotFound();
            }
            ViewData["CiudadId"] = new SelectList(_context.Ciudades, "Id", "Name", tercero.CiudadId);
            return View(tercero);
        }

        // POST: Terceros/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Documento,Nombre,Direccion,Telefono,Email,CiudadId")] Tercero tercero)
        {
            if (id != tercero.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tercero);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TerceroExists(tercero.Id))
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
            ViewData["CiudadId"] = new SelectList(_context.Ciudades, "Id", "Name", tercero.CiudadId);
            return View(tercero);
        }

        // GET: Terceros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tercero = await _context.Terceros
                .Include(t => t.Ciudad)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tercero == null)
            {
                return NotFound();
            }

            return View(tercero);
        }

        // POST: Terceros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tercero = await _context.Terceros.FindAsync(id);
            _context.Terceros.Remove(tercero);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TerceroExists(int id)
        {
            return _context.Terceros.Any(e => e.Id == id);
        }
    }
}
