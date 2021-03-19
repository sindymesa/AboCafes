using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AboCafes.Common.Entities;
using AboCafes.Web.Data;
using Microsoft.AspNetCore.Authorization;

namespace AboCafes.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ParafertilsController : Controller
    {
        private readonly DataContext _context;

        public ParafertilsController(DataContext context)
        {
            _context = context;
        }

        // GET: Parafertils
        public async Task<IActionResult> Index()
        {
            return View(await _context.Parafertils.ToListAsync());
        }

        // GET: Parafertils/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parafertil = await _context.Parafertils
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parafertil == null)
            {
                return NotFound();
            }

            return View(parafertil);
        }

        // GET: Parafertils/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Parafertils/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Detalle,Meses,PalosDesde,PalosHasta,Phdesde,PhHasta,CantidadKN,CantidadKP,CantidadKF,Menores")] Parafertil parafertil)
        {
            if (ModelState.IsValid)
            {
                _context.Add(parafertil);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(parafertil);
        }

        // GET: Parafertils/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parafertil = await _context.Parafertils.FindAsync(id);
            if (parafertil == null)
            {
                return NotFound();
            }
            return View(parafertil);
        }

        // POST: Parafertils/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Detalle,Meses,PalosDesde,PalosHasta,Phdesde,PhHasta,CantidadKN,CantidadKP,CantidadKF,Menores")] Parafertil parafertil)
        {
            if (id != parafertil.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(parafertil);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParafertilExists(parafertil.Id))
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
            return View(parafertil);
        }

        // GET: Parafertils/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parafertil = await _context.Parafertils
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parafertil == null)
            {
                return NotFound();
            }

            return View(parafertil);
        }

        // POST: Parafertils/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var parafertil = await _context.Parafertils.FindAsync(id);
            _context.Parafertils.Remove(parafertil);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParafertilExists(int id)
        {
            return _context.Parafertils.Any(e => e.Id == id);
        }
    }
}
