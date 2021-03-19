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
    public class FinquintasController : Controller
    {
        private readonly DataContext _context;

        public FinquintasController(DataContext context)
        {
            _context = context;
        }

        // GET: Finquintas
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.Fincas.Include(f => f.Tercero);
            return View(await dataContext.ToListAsync());
        }

        // GET: Finquintas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var finca = await _context.Fincas
                .Include(f => f.Tercero)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (finca == null)
            {
                return NotFound();
            }

            return View(finca);
        }

        // GET: Finquintas/Create
        public IActionResult Create()
        {
            ViewData["TerceroId"] = new SelectList(_context.Terceros, "Id", "Nombre");
            return View();
        }

        // POST: Finquintas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,TerceroId,Email,Telefono")] Finca finca)
        {
            if (ModelState.IsValid)
            {
                _context.Add(finca);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TerceroId"] = new SelectList(_context.Terceros, "Id", "Documento", finca.TerceroId);
            return View(finca);
        }

        // GET: Finquintas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var finca = await _context.Fincas.FindAsync(id);
            if (finca == null)
            {
                return NotFound();
            }
            ViewData["TerceroId"] = new SelectList(_context.Terceros, "Id", "Nombre", finca.TerceroId);
            return View(finca);
        }

        // POST: Finquintas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,TerceroId,Email,Telefono")] Finca finca)
        {
            if (id != finca.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(finca);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FincaExists(finca.Id))
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
            ViewData["TerceroId"] = new SelectList(_context.Terceros, "Id", "Documento", finca.TerceroId);
            return View(finca);
        }

        // GET: Finquintas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var finca = await _context.Fincas
                .Include(f => f.Tercero)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (finca == null)
            {
                return NotFound();
            }

            return View(finca);
        }

        // POST: Finquintas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var finca = await _context.Fincas.FindAsync(id);
            _context.Fincas.Remove(finca);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FincaExists(int id)
        {
            return _context.Fincas.Any(e => e.Id == id);
        }
    }
}
