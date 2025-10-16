using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SOPL.Web;

namespace SOPL.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LekarzeController : ControllerBase
    {
        private readonly SdOPLDbContext _context;

        public LekarzeController(SdOPLDbContext context)
        {
            _context = context;
        }

        
        [HttpGet("pacjenci/{lekarzId}")]
        public async Task<IActionResult> GetPacjenciByLekarz(Guid lekarzId)
        {
            var pacjenci = await _context.HistorieChorob
                .Include(h => h.Pacjent)
                .Where(h => h.LekarzId == lekarzId)
                .Select(h => new {
                    h.Pacjent.Imie,
                    h.Pacjent.Nazwisko,
                    h.Diagnoza,
                    h.Zalecenia
                })
                .ToListAsync();

            return Ok(pacjenci);
        }

        // GET: api/lekarze/leki
        [HttpGet("leki")]
        public async Task<IActionResult> GetLeki()
        {
            var leki = await _context.Leki.ToListAsync();
            return Ok(leki);
        }
    }

}
