using ClosedXML.Excel;
using hairmony_api.Data;
using hairmony_api.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        [HttpGet, Authorize]
        public async Task<ActionResult<IEnumerable<agendamentos>>> Getagendamentos()
        {
            try
            {
                return await _context.agendamentos.ToListAsync();
            }
            catch (Exception ex)
            {
                return Problem($"{ex.Message} - {ex.InnerException?.Message}");

                throw;
            }
        }

        // GET: api/agendamentos/5
        [HttpGet("{id}"), Authorize]
        public async Task<ActionResult<agendamentos>> Getagendamentos(Guid id)
        {
            try
            {
                var agendamentos = await _context.agendamentos.FindAsync(id);

                if (agendamentos == null)
                {
                    return NotFound();
                }

                return agendamentos;
            }
            catch (Exception ex)
            {
                return Problem($"{ex.Message} - {ex.InnerException?.Message}");

                throw;
            }
        }

        // PUT: api/agendamentos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}"), Authorize]
        public async Task<IActionResult> Putagendamentos(Guid id, agendamentos agendamentos)
        {
            if (id != agendamentos.id)
            {
                return BadRequest();
            }
            var servico = await _context.servicos.FindAsync(agendamentos.servicoid);
            if ( servico == null)
            {
                return BadRequest();
            }
            var msg = validaAgenda(agendamentos);
            if (!string.IsNullOrEmpty(msg))
            {
                return Problem(msg);
            }
            agendamentos.data_ate = agendamentos.data_ate.AddMinutes(servico!.duracao);

            _context.Entry(agendamentos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                if (!agendamentosExists(id))
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

        // POST: api/agendamentos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost, Authorize]
        public async Task<ActionResult<agendamentos>> Postagendamentos(agendamentos agendamentos, bool repete, double? dias)
        {
            try
            {
                agendamentos.data_de = agendamentos.data_de.AddHours(-3);
                var servico = await _context.servicos.FindAsync(agendamentos.servicoid);
                var cliente = await _context.clientes.FindAsync(agendamentos.clienteid);
                var colaborador = await _context.colaboradores.FindAsync(agendamentos.colaboradorid);
                var salao = await _context.salao.FindAsync(agendamentos.salaoid);
                if (salao == null || servico == null || cliente == null || colaborador == null)
                {
                    return BadRequest();
                }
                agendamentos.data_ate = agendamentos.data_de.AddMinutes(servico!.duracao);
                agendamentos.data_criacao = DateTime.Now;

                #region validação
                var msg = validaAgenda(agendamentos);
                if (!string.IsNullOrEmpty(msg))
                {
                    return Problem(msg);
                }
                #endregion
                if (repete && dias != null)
                {
                    var deDia = agendamentos.data_de;
                    var ateDia = new DateTime(DateTime.Now.Year, 12, 31); // Até o fim do ano
                    while (deDia < ateDia)
                    {
                        //cria novo agendamento
                        var ag = new agendamentos();
                        ag.data_de = deDia.AddDays(dias.Value);
                        ag.data_ate = ag.data_de.AddMinutes(servico!.duracao);
                        ag.clienteid = agendamentos.clienteid;
                        ag.servicoid = agendamentos.servicoid;
                        ag.salaoid = agendamentos.salaoid;
                        ag.colaboradorid = agendamentos.colaboradorid;
                        ag.data_criacao = DateTime.Now;
                        ag.concluido = false;
                        ag.observacao = agendamentos.observacao;
                        _context.agendamentos.Add(ag);
                        deDia = deDia.AddDays(dias.Value);
                    }
                }
                
                _context.agendamentos.Add(agendamentos);
                await _context.SaveChangesAsync();

                return CreatedAtAction("Getagendamentos", new { id = agendamentos.id }, agendamentos);
            }
            catch (Exception ex)
            {
                return Problem($"{ex.Message} - {ex.InnerException?.Message}");

                throw;
            }
        }

        private string validaAgenda(agendamentos agendamentos)
        {
            var agendaColaborador = _context.agendamentos
                .Where(x => x.colaboradorid == agendamentos.colaboradorid)
                .ToList();

            var verificaAgendaColaborador = agendaColaborador
                .Where(x =>
                {
                    var dataDe = x.data_de;
                    var dataAte = x.data_ate;

                    return agendamentos.data_de < dataAte && agendamentos.data_ate > dataDe;
                });

            if (verificaAgendaColaborador.Any())
            {
                return "Este colaborador já possui um agendamento neste intervalo de tempo.";
            }

            var agendaCliente = _context.agendamentos
                .Where(x => x.clienteid == agendamentos.clienteid)
                .ToList();

            var verificaAgendaCliente = agendaCliente
                .Where(x =>
                {
                    var dataDe = x.data_de;
                    var dataAte = x.data_ate;

                    return agendamentos.data_de < dataAte && agendamentos.data_ate > dataDe;
                });

            if (verificaAgendaCliente.Any())
            {
                return "Este cliente já possui um agendamento neste intervalo de tempo.";
            }

            return string.Empty;
        }

        // DELETE: api/agendamentos/5
        [HttpDelete("{id}"), Authorize]
        public async Task<IActionResult> Deleteagendamentos(Guid id)
        {
            try
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
            catch (Exception ex)
            {
                return Problem($"{ex.Message} - {ex.InnerException?.Message}");

                throw;
            }
        }

        private bool agendamentosExists(Guid id)
        {
            return _context.agendamentos.Any(e => e.id == id);
        }

        [HttpGet("relatorio-semanal"), Authorize]
        public async Task<IActionResult> GerarRelatorioSemanal()
        {
            try
            {
                var inicioSemana = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + 1); // Segunda
                var fimSemana = inicioSemana.AddDays(6); // Domingo

                var agendamentos = await _context.agendamentos
                    .Where(a => a.data_de.Date >= inicioSemana && a.data_de.Date <= fimSemana)
                    .OrderBy(x => x.colaboradorid).ThenBy(x => x.data_de)
                    .ToListAsync();


                using var workbook = new XLWorkbook();
                var worksheet = workbook.Worksheets.Add("Agendamentos da Semana");

                // Cabeçalho
                worksheet.Cell(1, 1).Value = "Colaborador";
                worksheet.Cell(1, 2).Value = "Data";
                worksheet.Cell(1, 3).Value = "Hora";
                worksheet.Cell(1, 4).Value = "Cliente";
                worksheet.Cell(1, 5).Value = "WhatsApp";
                worksheet.Cell(1, 6).Value = "Serviço";
                worksheet.Cell(1, 7).Value = "Valor (R$)";

                int row = 2;
                foreach (var ag in agendamentos)
                {
                    var servico = await _context.servicos.FindAsync(ag.servicoid);
                    var cliente = await _context.clientes.FindAsync(ag.clienteid);
                    var colaborador = await _context.colaboradores.FindAsync(ag.colaboradorid);
                    if (servico == null || cliente == null || colaborador == null)
                    {
                        return BadRequest();
                    }
                    worksheet.Cell(row, 1).Value = colaborador.nome.ToUpper();
                    worksheet.Cell(row, 2).Value = ag.data_de.ToString("dd/MM/yyyy");
                    worksheet.Cell(row, 3).Value = $"{ag.data_de.ToString("HH:mm")} até {ag.data_ate.ToString("HH:mm")}";
                    worksheet.Cell(row, 4).Value = cliente.nome;
                    worksheet.Cell(row, 5).Value = AplicarMascara(cliente.celular);
                    worksheet.Cell(row, 6).Value = servico.nome;
                    worksheet.Cell(row, 7).Value = servico.preco;
                    row++;
                }

                for (int i = 1; i < 7; i++)
                {
                    worksheet.Column(i).Width = 28;
                }

                using var stream = new MemoryStream();
                workbook.SaveAs(stream);
                stream.Position = 0;

                return File(stream.ToArray(),
                    "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                    "RelatórioSemanal.xlsx");

            }
            catch (Exception ex)
            {
                return Problem($"{ex.Message} - {ex.InnerException?.Message}");

            }
        }

        private string AplicarMascara(string tel)
        {
            if (string.IsNullOrEmpty(tel))
            {
                return string.Empty;
            }
            if (tel.Length == 11)
            {
                return Convert.ToUInt64(tel).ToString(@"(00) 00000-0000");
            }
            // Telefone com DDD e 8 dígitos: (11) 1234-5678
            if (tel.Length == 10)
                return Convert.ToUInt64(tel).ToString(@"(00) 0000-0000");

            // Apenas número local com 9 dígitos: 91234-5678
            if (tel.Length == 9)
                return Convert.ToUInt64(tel).ToString(@"00000-0000");

            // Apenas número local com 8 dígitos: 1234-5678
            if (tel.Length == 8)
                return Convert.ToUInt64(tel).ToString(@"0000-0000");
            return tel;
        }
    }
}
