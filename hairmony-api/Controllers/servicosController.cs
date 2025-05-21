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
    public class servicosController : ControllerBase
    {
        private readonly hairmonyContext _context;

        public servicosController(hairmonyContext context)
        {
            _context = context;
        }

        // GET: api/servicos
        [HttpGet, Authorize]
        public async Task<ActionResult<IEnumerable<servicos>>> Getservicos()
        {
            try
            {
                return await _context.servicos.OrderBy(x => x.nome).ToListAsync();
            }
            catch (Exception ex)
            {
                return Problem($"{ex.Message} - {ex.InnerException?.Message}");

                throw;
            }
        }

        // GET: api/servicos/5
        [HttpGet("{id}"), Authorize]
        public async Task<ActionResult<servicos>> Getservicos(Guid id)
        {
            try
            {
                var servicos = await _context.servicos.FindAsync(id);

                if (servicos == null)
                {
                    return NotFound();
                }

                return servicos;
            }
            catch (Exception ex)
            {
                return Problem($"{ex.Message} - {ex.InnerException?.Message}");

                throw;
            }
        }

        // PUT: api/servicos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}"), Authorize]
        public async Task<IActionResult> Putservicos(Guid id, servicos servicos)
        {
            if (id != servicos.id)
            {
                return BadRequest();
            }

            _context.Entry(servicos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                if (!servicosExists(id))
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

        // POST: api/servicos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost, Authorize]
        public async Task<ActionResult<servicos>> Postservicos(servicos servicos)
        {
            try
            {
                servicos.data_criacao = DateTime.Now;
                _context.servicos.Add(servicos);
                await _context.SaveChangesAsync();

                return CreatedAtAction("Getservicos", new { id = servicos.id }, servicos);
            }
            catch (Exception ex)
            {
                return Problem($"{ex.Message} - {ex.InnerException?.Message}");

                throw;
            }
        }

        // DELETE: api/servicos/5
        [HttpDelete("{id}"), Authorize]
        public async Task<IActionResult> Deleteservicos(Guid id)
        {
            try
            {
                var servicos = await _context.servicos.FindAsync(id);
                if (servicos == null)
                {
                    return NotFound();
                }

                _context.servicos.Remove(servicos);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return Problem($"{ex.Message} - {ex.InnerException?.Message}");

                throw;
            }
        }

        private bool servicosExists(Guid id)
        {
            return _context.servicos.Any(e => e.id == id);
        }
    }
}
