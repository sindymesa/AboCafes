using AboCafes.Web.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AboCafes.Web.Controllers.API
{

    [ApiController]
    [Route("api/[controller]")]
    public class DepartamentosController : ControllerBase
    {
        private readonly DataContext _context;

        public DepartamentosController(DataContext context)
        {
            _context = context;
        }
    


    [HttpGet]
    public IActionResult GetDepartamentos()
    {
        return Ok(_context.Departamentos
              .Include(c => c.Ciudades)
               .ThenInclude(d => d.Corregimientos)
               .ThenInclude(f => f.Veredas)
               .ThenInclude(v => v.Fincas)
               .ThenInclude(t => t.Lotes)
               .ThenInclude(g => g.Hectareas));
    }

}

}