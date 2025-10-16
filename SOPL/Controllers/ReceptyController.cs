using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SOPL.Models;
using SOPL.Web;

namespace SOPL.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReceptyController : ControllerBase
    {
        private readonly SoplDbContext _context;

        public ReceptyController(SoplDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateRecepta([FromBody] Recepta recepta)
        {
            recepta.Id = Guid.NewGuid();
            recepta.DataWystawienia = DateTime.UtcNow;

            _context.Recepty.Add(recepta);
            await _context.SaveChangesAsync();
            return Ok(recepta);
        }
    }
}
