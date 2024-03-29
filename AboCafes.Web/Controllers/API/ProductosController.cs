﻿using AboCafes.Web.Data;
using Microsoft.AspNetCore.Mvc;

namespace AboCafes.Web.Controllers.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly DataContext _context;

        public ProductosController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetProductos()
        {
            return Ok(_context.Productos);
        }
    }

}
