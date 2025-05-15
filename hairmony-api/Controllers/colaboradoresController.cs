using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using hairmony_api.Data;
using hairmony_api.Model;
using Microsoft.AspNetCore.Authorization;

namespace hairmony_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class colaboradoresController : ControllerBase
    {
        private readonly hairmonyContext _context;

        public colaboradoresController(hairmonyContext context)
        {
            _context = context;
        }

        // GET: api/colaboradores
        [HttpGet, Authorize]
        public async Task<ActionResult<IEnumerable<colaboradores>>> Getcolaboradores()
        {
            return await _context.colaboradores.ToListAsync();
        }

        // GET: api/colaboradores/5
        [HttpGet("{id}"), Authorize]
        public async Task<ActionResult<colaboradores>> Getcolaboradores(Guid id)
        {
            var colaboradores = await _context.colaboradores.FindAsync(id);

            if (colaboradores == null)
            {
                return NotFound();
            }

            return colaboradores;
        }

        // PUT: api/colaboradores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}"), Authorize]
        public async Task<IActionResult> Putcolaboradores(Guid id, colaboradores colaboradores)
        {
            if (id != colaboradores.id)
            {
                return BadRequest();
            }

            _context.Entry(colaboradores).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!colaboradoresExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/colaboradores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost, Authorize]
        public async Task<ActionResult<colaboradores>> Postcolaboradores(colaboradores colaboradores)
        {
            _context.colaboradores.Add(colaboradores);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getcolaboradores", new { id = colaboradores.id }, colaboradores);
        }

        // DELETE: api/colaboradores/5
        [HttpDelete("{id}"), Authorize]
        public async Task<IActionResult> Deletecolaboradores(Guid id)
        {
            var colaboradores = await _context.colaboradores.FindAsync(id);
            if (colaboradores == null)
            {
                return NotFound();
            }

            _context.colaboradores.Remove(colaboradores);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool colaboradoresExists(Guid id)
        {
            return _context.colaboradores.Any(e => e.id == id);
        }
    }
}
