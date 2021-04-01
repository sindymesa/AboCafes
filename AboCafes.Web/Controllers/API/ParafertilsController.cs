using AboCafes.Web.Data;
using Microsoft.AspNetCore.Mvc;

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
