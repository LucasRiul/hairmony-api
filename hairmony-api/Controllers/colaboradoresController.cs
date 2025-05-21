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
            try
            {
                return await _context.colaboradores.OrderBy(x => x.nome).ToListAsync();
            }
            catch (Exception ex)
            {
                return Problem($"{ex.Message} - {ex.InnerException?.Message}");

                throw;
            }
        }

        // GET: api/colaboradores/5
        [HttpGet("{id}"), Authorize]
        public async Task<ActionResult<colaboradores>> Getcolaboradores(Guid id)
        {
            try
            {
                var colaboradores = await _context.colaboradores.FindAsync(id);

                if (colaboradores == null)
                {
                    return NotFound();
                }

                return colaboradores;
            }
            catch (Exception ex)
            {
                return Problem($"{ex.Message} - {ex.InnerException?.Message}");

                throw;
            }
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
            catch (Exception ex)
            {
                if (!colaboradoresExists(id))
                {
                    return NotFound();
                }
                else
                {
                    return Problem($"{ex.Message} - {ex.InnerException?.Message}");

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
            try
            {
                colaboradores.data_criacao = DateTime.Now;
                _context.colaboradores.Add(colaboradores);
                await _context.SaveChangesAsync();

                return CreatedAtAction("Getcolaboradores", new { id = colaboradores.id }, colaboradores);
            }
            catch (Exception ex)
            {
                return Problem($"{ex.Message} - {ex.InnerException?.Message}");

                throw;
            }
        }

        // DELETE: api/colaboradores/5
        [HttpDelete("{id}"), Authorize]
        public async Task<IActionResult> Deletecolaboradores(Guid id)
        {
            try
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
            catch (Exception ex)
            {
                return Problem($"{ex.Message} - {ex.InnerException?.Message}");

                throw;
            }
        }

        private bool colaboradoresExists(Guid id)
        {
            return _context.colaboradores.Any(e => e.id == id);
        }
    }
}
