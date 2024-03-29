﻿using AboCafes.Web.Data;
using Microsoft.AspNetCore.Mvc;

namespace AboCafes.Web.Controllers.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class TercerosController : ControllerBase
    {
        private readonly DataContext _context;

        public TercerosController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetTerceros()
        {
            return Ok(_context.Terceros);
        }
    }

}
