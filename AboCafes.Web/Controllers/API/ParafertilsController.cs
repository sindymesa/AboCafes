using AboCafes.Web.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AboCafes.Web.Controllers.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParafertilsController : ControllerBase
    {
        private readonly DataContext _context;

        public ParafertilsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetParafertils()
        {
            return Ok(_context.Parafertils);
        }
    }

}
