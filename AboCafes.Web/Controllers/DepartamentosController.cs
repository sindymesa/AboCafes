using AboCafes.Common.Entities;
using AboCafes.Web.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AboCafes.Web.Controllers
{

    [Authorize(Roles = "Admin")]
    public class DepartamentosController : Controller
    {
        private readonly DataContext _context;

        public DepartamentosController(DataContext context)
        {
            _context = context;
        }

        // GET: Departamentos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Departamentos
                .Include(c => c.Ciudades)
                .ToListAsync());
        }

        // GET: Departamentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departamento = await _context.Departamentos
               .Include(c => c.Ciudades)
               .ThenInclude(d => d.Corregimientos)
               .ThenInclude(f => f.Veredas)
               .ThenInclude(v => v.Fincas)
               .ThenInclude(t => t.Lotes)
               .ThenInclude(g => g.Hectareas)
               .FirstOrDefaultAsync(m => m.Id == id);
            if (departamento == null)
            {
                return NotFound();
            }

            return View(departamento);
        }

        // GET: Departamentos/Create
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Departamento departamento)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(departamento);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "There are a record with the same name.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }

            }

            return View(departamento);
        }

        // GET: Departamentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departamento = await _context.Departamentos.FindAsync(id);
            if (departamento == null)
            {
                return NotFound();
            }
            return View(departamento);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Departamento departamento)
        {
            if (id != departamento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(departamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartamentoExists(departamento.Id))
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
            return View(departamento);
        }

        // GET: Departamentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departamento = await _context.Departamentos
               .Include(c => c.Ciudades)
               .ThenInclude(d => d.Corregimientos)
               .ThenInclude(f => f.Veredas)
               .ThenInclude(v => v.Fincas)
               .ThenInclude(t => t.Lotes)
               .ThenInclude(g => g.Hectareas)

                .FirstOrDefaultAsync(m => m.Id == id);
            if (departamento == null)
            {
                return NotFound();
            }

            _context.Departamentos.Remove(departamento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }



        private bool DepartamentoExists(int id)
        {
            return _context.Departamentos.Any(e => e.Id == id);
        }












        //* Ciudad



        public async Task<IActionResult> AddCiudad(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Departamento departamento = await _context.Departamentos.FindAsync(id);
            if (departamento == null)
            {
                return NotFound();
            }

            Ciudad model = new Ciudad { IdDepartamento = departamento.Id };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddCiudad(Ciudad ciudad)
        {
            if (ModelState.IsValid)
            {
                Departamento departamento = await _context.Departamentos
                    .Include(c => c.Ciudades)
                    .FirstOrDefaultAsync(c => c.Id == ciudad.IdDepartamento);
                if (departamento == null)
                {
                    return NotFound();
                }

                try
                {
                    ciudad.Id = 0;
                    departamento.Ciudades.Add(ciudad);
                    _context.Update(departamento);
                    await _context.SaveChangesAsync();
                    return RedirectToAction($"{nameof(Details)}/{departamento.Id}");

                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Hay un registro con el mismo nombre");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }

            return View(ciudad);
        }


        public async Task<IActionResult> EditCiudad(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Ciudad ciudad = await _context.Ciudades.FindAsync(id);
            if (ciudad == null)
            {
                return NotFound();
            }

            Departamento departamento = await _context.Departamentos.FirstOrDefaultAsync(d => d.Ciudades.FirstOrDefault(c => c.Id == ciudad.Id) != null);
            ciudad.IdDepartamento = ciudad.Id;
            return View(ciudad);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCiudad(int id, [Bind("Id,Name")] Ciudad ciudad)
        {
            if (id != ciudad.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ciudad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartamentoExists(ciudad.Id))
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
            return View(ciudad);
        }




        public async Task<IActionResult> DeleteCiudad(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Ciudad ciudad = await _context.Ciudades
                .Include(d => d.Corregimientos)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ciudad == null)
            {
                return NotFound();
            }

            Departamento departamento = await _context.Departamentos.FirstOrDefaultAsync(c => c.Ciudades.FirstOrDefault(d => d.Id == ciudad.Id) != null);
            _context.Ciudades.Remove(ciudad);
            await _context.SaveChangesAsync();
            return RedirectToAction($"{nameof(Details)}/{ciudad.Id}");
        }



        public async Task<IActionResult> DetailsCiudad(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Ciudad ciudad = await _context.Ciudades
                .Include(d => d.Corregimientos)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ciudad == null)
            {
                return NotFound();
            }

            Departamento departamento = await _context.Departamentos.FirstOrDefaultAsync(c => c.Ciudades.FirstOrDefault(d => d.Id == ciudad.Id) != null);
            ciudad.IdDepartamento = departamento.Id;
            return View(ciudad);
        }






        //* Corregimientos

        public async Task<IActionResult> AddCorregimiento(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Ciudad ciudad = await _context.Ciudades.FindAsync(id);
            if (ciudad == null)
            {
                return NotFound();
            }

            Corregimiento model = new Corregimiento { IdCiudad = ciudad.Id };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddCorregimiento(Corregimiento corregimiento)
        {
            if (ModelState.IsValid)
            {
                Ciudad ciudad = await _context.Ciudades
                    .Include(d => d.Corregimientos)
                    .FirstOrDefaultAsync(c => c.Id == corregimiento.IdCiudad);
                if (ciudad == null)
                {
                    return NotFound();
                }

                try
                {
                    corregimiento.Id = 0;
                    ciudad.Corregimientos.Add(corregimiento);
                    _context.Update(ciudad);
                    await _context.SaveChangesAsync();
                    return RedirectToAction($"{nameof(DetailsCiudad)}/{ciudad.Id}");

                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Hay un registro con el mismo nombre ");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }

            return View(corregimiento);
        }


        public async Task<IActionResult> EditCorregimiento(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Corregimiento corregimiento = await _context.Corregimientos.FindAsync(id);
            if (corregimiento == null)
            {
                return NotFound();
            }

            Ciudad ciudad = await _context.Ciudades.FirstOrDefaultAsync(c => c.Corregimientos.FirstOrDefault(d => d.Id == corregimiento.Id) != null);
            corregimiento.IdCiudad = ciudad.Id;
            return View(corregimiento);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCorregimiento(Corregimiento corregimiento)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(corregimiento);
                    await _context.SaveChangesAsync();
                    return RedirectToAction($"{nameof(DetailsCiudad)}/{corregimiento.IdCiudad}");

                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Hay un registro con el mismo nombre.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }
            return View(corregimiento);
        }





        public async Task<IActionResult> DeleteCorregimiento(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Corregimiento corregimiento = await _context.Corregimientos
                .Include(e => e.Veredas)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (corregimiento == null)
            {
                return NotFound();
            }

            Ciudad ciudad = await _context.Ciudades.FirstOrDefaultAsync(d => d.Corregimientos.FirstOrDefault(c => c.Id == corregimiento.Id) != null);
            _context.Corregimientos.Remove(corregimiento);
            await _context.SaveChangesAsync();
            return RedirectToAction($"{nameof(DetailsCiudad)}/{ciudad.Id}");
        }






        public async Task<IActionResult> DetailsCorregimiento(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Corregimiento corregimiento = await _context.Corregimientos
                .Include(e => e.Veredas)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (corregimiento == null)
            {
                return NotFound();
            }

            Ciudad ciudad = await _context.Ciudades.FirstOrDefaultAsync(c => c.Corregimientos.FirstOrDefault(e => e.Id == corregimiento.Id) != null);
            corregimiento.IdCiudad = ciudad.Id;
            return View(corregimiento);
        }


        //* Vereda

        public async Task<IActionResult> AddVereda(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Corregimiento corregimiento = await _context.Corregimientos.FindAsync(id);
            if (corregimiento == null)
            {
                return NotFound();
            }

            Vereda model = new Vereda { IdCorregimiento = corregimiento.Id };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddVereda(Vereda vereda
            )
        {
            if (ModelState.IsValid)
            {
                Corregimiento corregimiento = await _context.Corregimientos
                    .Include(d => d.Veredas)
                    .FirstOrDefaultAsync(c => c.Id == vereda.IdCorregimiento);
                if (corregimiento == null)
                {
                    return NotFound();
                }

                try
                {
                    vereda.Id = 0;
                    corregimiento.Veredas.Add(vereda);
                    _context.Update(corregimiento);
                    await _context.SaveChangesAsync();
                    return RedirectToAction($"{nameof(DetailsCorregimiento)}/{corregimiento.Id}");

                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Hay un registro con el mismo nombre ");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }

            return View(vereda);
        }










        public async Task<IActionResult> EditVereda(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Vereda vereda = await _context.Veredas.FindAsync(id);
            if (vereda == null)
            {
                return NotFound();
            }

            Corregimiento corregimiento = await _context.Corregimientos.FirstOrDefaultAsync(c => c.Veredas.FirstOrDefault(d => d.Id == vereda.Id) != null);
            vereda.IdCorregimiento = corregimiento.Id;
            return View(vereda);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditVereda(Vereda vereda)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vereda);
                    await _context.SaveChangesAsync();
                    return RedirectToAction($"{nameof(DetailsCorregimiento)}/{vereda.IdCorregimiento}");

                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Hay un registro con el mismo nombre.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }
            return View(vereda);
        }





        public async Task<IActionResult> DeleteVereda(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Vereda vereda = await _context.Veredas
                .Include(f => f.Fincas)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vereda == null)
            {
                return NotFound();
            }

            Corregimiento corregimiento = await _context.Corregimientos.FirstOrDefaultAsync(d => d.Veredas.FirstOrDefault(e => e.Id == vereda.Id) != null);
            _context.Veredas.Remove(vereda);
            await _context.SaveChangesAsync();
            return RedirectToAction($"{nameof(DetailsCorregimiento)}/{corregimiento.Id}");
        }





        public async Task<IActionResult> DetailsVereda(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Vereda vereda = await _context.Veredas
                .Include(f => f.Fincas)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vereda == null)
            {
                return NotFound();
            }

            Corregimiento corregimiento = await _context.Corregimientos.FirstOrDefaultAsync(c => c.Veredas.FirstOrDefault(e => e.Id == vereda.Id) != null);
            vereda.IdCorregimiento = vereda.Id;
            return View(vereda);
        }















        public async Task<IActionResult> AddFinca(int? id)
        {
            ViewData["TerceroId"] = new SelectList(_context.Terceros, "Id", "Nombre");


            if (id == null)
            {
                return NotFound();
            }

            Vereda vereda = await _context.Veredas.FindAsync(id);
            if (vereda == null)
            {
                return NotFound();
            }

            Finca model = new Finca { IdVereda = vereda.Id };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddFinca(Finca finca)
        {
            if (ModelState.IsValid)
            {
                Vereda vereda = await _context.Veredas
                    .Include(g => g.Fincas)
                    .FirstOrDefaultAsync(d => d.Id == finca.IdVereda);
                if (vereda == null)
                {
                    return NotFound();
                }

                try
                {
                    finca.Id = 0;
                    vereda.Fincas.Add(finca);
                    _context.Update(vereda);
                    await _context.SaveChangesAsync();
                    return RedirectToAction($"{nameof(DetailsVereda)}/{vereda.Id}");

                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Hay un registro con el mismo nombre ");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }


            }
            ViewData["TerceroId"] = new SelectList(_context.Terceros, "Id", "Nombre", finca.TerceroId);

            return View(finca);
        }






        //* Fincas







        public async Task<IActionResult> EditFinca(int? id)
        {
            ViewData["TerceroId"] = new SelectList(_context.Terceros, "Id", "Nombre");

            if (id == null)
            {
                return NotFound();
            }

            Finca finca = await _context.Fincas.FindAsync(id);
            if (finca == null)
            {
                return NotFound();
            }

            Vereda vereda = await _context.Veredas.FirstOrDefaultAsync(c => c.Fincas.FirstOrDefault(d => d.Id == finca.Id) != null);
            finca.IdVereda = vereda.Id;
            return View(finca);


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditFinca(int id, [Bind("Id,Name,TerceroId,Email,Telefono")] Finca finca)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(finca);
                    await _context.SaveChangesAsync();
                    return RedirectToAction($"{nameof(DetailsVereda)}/{finca.IdVereda}");

                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Hay un registro con el mismo nombre.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }
            ViewData["TerceroId"] = new SelectList(_context.Terceros, "Id", "Documento", finca.TerceroId);
            return View(finca);
        }





        public async Task<IActionResult> DeleteFinca(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Finca finca = await _context.Fincas
                .Include(g => g.Lotes)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (finca == null)
            {
                return NotFound();
            }

            Vereda vereda = await _context.Veredas.FirstOrDefaultAsync(d => d.Fincas.FirstOrDefault(e => e.Id == finca.Id) != null);
            _context.Fincas.Remove(finca);
            await _context.SaveChangesAsync();
            return RedirectToAction($"{nameof(DetailsVereda)}/{vereda.Id}");
        }




        public async Task<IActionResult> DetailsFinca(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Finca finca = await _context.Fincas
                .Include(f => f.Lotes)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (finca == null)
            {
                return NotFound();
            }

            Vereda vereda = await _context.Veredas.FirstOrDefaultAsync(c => c.Fincas.FirstOrDefault(e => e.Id == finca.Id) != null);
            finca.IdVereda = finca.Id;
            return View(finca);
        }















        //*   Lotes



        public async Task<IActionResult> AddLote(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Finca finca = await _context.Fincas.FindAsync(id);
            if (finca == null)
            {
                return NotFound();
            }

            Lote model = new Lote { IdFinca = finca.Id };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddLote(Lote lote)
        {
            if (ModelState.IsValid)
            {
                Finca finca = await _context.Fincas
                    .Include(f => f.Lotes)
                    .FirstOrDefaultAsync(d => d.Id == lote.IdFinca);
                if (finca == null)
                {
                    return NotFound();
                }

                try
                {
                    lote.Id = 0;
                    finca.Lotes.Add(lote);
                    _context.Update(finca);
                    await _context.SaveChangesAsync();
                    return RedirectToAction($"{nameof(DetailsFinca)}/{finca.Id}");

                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Hay un registro con el mismo nombre ");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }

            return View(lote);
        }








        public async Task<IActionResult> EditLote(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Lote lote = await _context.Lotes.FindAsync(id);
            if (lote == null)
            {
                return NotFound();
            }

            Finca finca = await _context.Fincas.FirstOrDefaultAsync(c => c.Lotes.FirstOrDefault(d => d.Id == lote.Id) != null);
            lote.IdFinca = finca.Id;
            return View(lote);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditLote(Lote lote)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lote);
                    await _context.SaveChangesAsync();
                    return RedirectToAction($"{nameof(DetailsFinca)}/{lote.IdFinca}");

                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Hay un registro con el mismo nombre.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }
            return View(lote);
        }





        public async Task<IActionResult> DeleteLote(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Lote lote = await _context.Lotes
                .Include(g => g.Hectareas)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lote == null)
            {
                return NotFound();
            }

            Finca finca = await _context.Fincas.FirstOrDefaultAsync(d => d.Lotes.FirstOrDefault(e => e.Id == lote.Id) != null);
            _context.Lotes.Remove(lote);
            await _context.SaveChangesAsync();
            return RedirectToAction($"{nameof(DetailsFinca)}/{finca.Id}");
        }





        public async Task<IActionResult> DetailsLote(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Lote lote = await _context.Lotes
                .Include(g => g.Hectareas)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lote == null)
            {
                return NotFound();
            }

            Finca finca = await _context.Fincas.FirstOrDefaultAsync(c => c.Lotes.FirstOrDefault(e => e.Id == lote.Id) != null);
            lote.IdFinca = lote.Id;
            return View(lote);
        }




























        public async Task<IActionResult> AddHectarea(int? id)


        {
            ViewData["CafeId"] = new SelectList(_context.Cafes, "Id", "Variedad");


            if (id == null)
            {
                return NotFound();
            }

            Lote lote = await _context.Lotes.FindAsync(id);
            if (lote == null)
            {
                return NotFound();
            }

            Hectarea model = new Hectarea { IdLote = lote.Id };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddHectarea(Hectarea hectarea)
        {



            if (ModelState.IsValid)
            {
                Lote lote = await _context.Lotes
                    .Include(f => f.Hectareas)


                    .FirstOrDefaultAsync(d => d.Id == hectarea.IdLote);
                if (lote == null)
                {
                    return NotFound();
                }

                try
                {
                    hectarea.Id = 0;
                    lote.Hectareas.Add(hectarea);
                    _context.Update(lote);
                    await _context.SaveChangesAsync();
                    return RedirectToAction($"{nameof(DetailsLote)}/{lote.Id}");

                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Hay un registro con el mismo nombre ");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }
            ViewData["CafeId"] = new SelectList(_context.Cafes, "Id", "Variedad", hectarea.CafeId);
            return View(hectarea);
        }







        public async Task<IActionResult> EditHectarea(int? id)
        {

            ViewData["CafeId"] = new SelectList(_context.Cafes, "Id", "Variedad");
            if (id == null)
            {
                return NotFound();
            }

            Hectarea hectarea = await _context.Hectareas.FindAsync(id);
            if (hectarea == null)
            {
                return NotFound();
            }
            Lote lote = await _context.Lotes.FirstOrDefaultAsync(c => c.Hectareas.FirstOrDefault(d => d.Id == hectarea.Id) != null);
            hectarea.IdLote = lote.Id;
            return View(hectarea);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditHectarea(Hectarea hectarea)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hectarea);
                    await _context.SaveChangesAsync();
                    return RedirectToAction($"{nameof(DetailsLote)}/{hectarea.IdLote}");

                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Hay un registro con el mismo nombre.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }
            ViewData["CafeId"] = new SelectList(_context.Cafes, "Id", "Variedad", hectarea.CafeId);
            return View(hectarea);
        }





        public async Task<IActionResult> DeleteHectarea(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Hectarea hectarea = await _context.Hectareas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hectarea == null)
            {
                return NotFound();
            }

            Lote lote = await _context.Lotes.FirstOrDefaultAsync(d => d.Hectareas.FirstOrDefault(e => e.Id == hectarea.Id) != null);
            _context.Hectareas.Remove(hectarea);
            await _context.SaveChangesAsync();
            return RedirectToAction($"{nameof(DetailsLote)}/{lote.Id}");
        }





        public async Task<IActionResult> DetailsHectarea(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Hectarea hectarea = await _context.Hectareas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hectarea == null)
            {
                return NotFound();
            }

            Lote lote = await _context.Lotes.FirstOrDefaultAsync(c => c.Hectareas.FirstOrDefault(e => e.Id == hectarea.Id) != null);
            lote.IdFinca = lote.Id;
            return View(hectarea);
        }





    }
}







