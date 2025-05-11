using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace hairmony_api.Model
{
    public class agendamentos
    {
        [Key]
        public Guid id { get; set; } = Guid.NewGuid();
        public DateTime data_de { get; set; }
        public DateTime data_ate { get; set; }
        public bool concluido { get; set; }
        public DateTime data_criacao { get; set; }
        public Guid salaoId { get; set; }
        public Guid clienteId { get; set; }
        public Guid servicoId { get; set; }
        public Guid colaboradorId { get; set; }
    }
}
