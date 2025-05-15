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
    public class clientesController : ControllerBase
    {
        private readonly hairmonyContext _context;

        public clientesController(hairmonyContext context)
        {
            _context = context;
        }

        // GET: api/clientes
        [HttpGet, Authorize]
        public async Task<ActionResult<IEnumerable<clientes>>> Getclientes()
        {
            return await _context.clientes.ToListAsync();
        }

        // GET: api/clientes/5
        [HttpGet("{id}"), Authorize]
        public async Task<ActionResult<clientes>> Getclientes(Guid id)
        {
            var clientes = await _context.clientes.FindAsync(id);

            if (clientes == null)
            {
                return NotFound();
            }

            return clientes;
        }

        // PUT: api/clientes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}"), Authorize]
        public async Task<IActionResult> Putclientes(Guid id, clientes clientes)
        {
            if (id != clientes.id)
            {
                return BadRequest();
            }

            _context.Entry(clientes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!clientesExists(id))
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

        // POST: api/clientes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost, Authorize]
        public async Task<ActionResult<clientes>> Postclientes(clientes clientes)
        {
            _context.clientes.Add(clientes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getclientes", new { id = clientes.id }, clientes);
        }

        // DELETE: api/clientes/5
        [HttpDelete("{id}"), Authorize]
        public async Task<IActionResult> Deleteclientes(Guid id)
        {
            var clientes = await _context.clientes.FindAsync(id);
            if (clientes == null)
            {
                return NotFound();
            }

            _context.clientes.Remove(clientes);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool clientesExists(Guid id)
        {
            return _context.clientes.Any(e => e.id == id);
        }
    }
}
