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
    public class salaoController : ControllerBase
    {
        private readonly hairmonyContext _context;

        public salaoController(hairmonyContext context)
        {
            _context = context;
        }

        // GET: api/salao
        [HttpGet, Authorize]
        public async Task<ActionResult<IEnumerable<salao>>> Getsalao()
        {
            return await _context.salao.ToListAsync();
        }

        // GET: api/salao/5
        [HttpGet("{id}"), Authorize]
        public async Task<ActionResult<salao>> Getsalao(Guid id)
        {
            var salao = await _context.salao.FindAsync(id);

            if (salao == null)
            {
                return NotFound();
            }

            return salao;
        }

        // PUT: api/salao/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}"), Authorize]
        public async Task<IActionResult> Putsalao([FromRoute]Guid id, [FromBody] salao salao)
        {
            if (id != salao.id)
            {
                return BadRequest();
            }

            _context.Entry(salao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!salaoExists(id))
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

        // POST: api/salao
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost, Authorize]
        public async Task<ActionResult<salao>> Postsalao(salao salao)
        {
            salao.senha = BCrypt.Net.BCrypt.HashPassword(salao.senha);
            _context.salao.Add(salao);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getsalao", new { id = salao.id }, salao);
        }

        // DELETE: api/salao/5
        [HttpDelete("{id}"), Authorize]
        public async Task<IActionResult> Deletesalao(Guid id)
        {
            var salao = await _context.salao.FindAsync(id);
            if (salao == null)
            {
                return NotFound();
            }

            _context.salao.Remove(salao);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool salaoExists(Guid id)
        {
            return _context.salao.Any(e => e.id == id);
        }
    }
}
