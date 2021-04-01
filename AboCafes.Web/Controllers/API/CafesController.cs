using AboCafes.Web.Data;
using Microsoft.AspNetCore.Mvc;

namespace AboCafes.Web.Controllers.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class CafesController : ControllerBase
    {
        private readonly DataContext _context;

        public CafesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetCafes()
        {
            return Ok(_context.Cafes);
        }
    }

}
