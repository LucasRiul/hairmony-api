using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using hairmony_api.Data;
using hairmony_api.Model;

namespace hairmony_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class agendamentosController : ControllerBase
    {
        private readonly hairmonyContext _context;

        public agendamentosController(hairmonyContext context)
        {
            _context = context;
        }

        // GET: api/agendamentos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<agendamentos>>> Getagendamentos()
        {
            return await _context.agendamentos.ToListAsync();
        }

        // GET: api/agendamentos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<agendamentos>> Getagendamentos(Guid id)
        {
            var agendamentos = await _context.agendamentos.FindAsync(id);

            if (agendamentos == null)
            {
                return NotFound();
            }

            return agendamentos;
        }

        // PUT: api/agendamentos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putagendamentos(Guid id, agendamentos agendamentos)
        {
            if (id != agendamentos.id)
            {
                return BadRequest();
            }

            _context.Entry(agendamentos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!agendamentosExists(id))
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

        // POST: api/agendamentos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<agendamentos>> Postagendamentos(agendamentos agendamentos)
        {
            _context.agendamentos.Add(agendamentos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getagendamentos", new { id = agendamentos.id }, agendamentos);
        }

        // DELETE: api/agendamentos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteagendamentos(Guid id)
        {
            var agendamentos = await _context.agendamentos.FindAsync(id);
            if (agendamentos == null)
            {
                return NotFound();
            }

            _context.agendamentos.Remove(agendamentos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool agendamentosExists(Guid id)
        {
            return _context.agendamentos.Any(e => e.id == id);
        }
    }
}
