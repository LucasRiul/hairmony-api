using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using hairmony_api.Data;
using hairmony_api.Model;
using NuGet.Common;

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
        public async Task<ActionResult<agendamentos>> Postagendamentos(agendamentos agendamentos, bool repete, double? dias)
        {
            var servico = await _context.servicos.FindAsync(agendamentos.servicoId);
            if (repete && dias != null && servico != null)
            {
                var deDia = agendamentos.data_de;
                var ateDia = new DateTime(DateTime.Now.Year, 12, 31); // Até o fim do ano
                while (deDia < ateDia)
                {
                    //cria novo agendamento
                    var ag = new agendamentos();
                    ag.data_de = deDia.AddDays(dias.Value);
                    ag.data_ate = ag.data_de.AddMinutes(servico.duracao);
                    ag.clienteId = agendamentos.clienteId;
                    ag.servicoId = agendamentos.servicoId;
                    ag.salaoId = agendamentos.salaoId;
                    ag.colaboradorId = agendamentos.colaboradorId;
                    ag.data_criacao = DateTime.UtcNow;
                    _context.agendamentos.Add(ag);
                    deDia = deDia.AddDays(dias.Value);
                }
            }
            agendamentos.data_ate = agendamentos.data_de.AddMinutes(servico.duracao);
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
