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
        public Guid salaoid { get; set; }
        public Guid clienteid { get; set; }
        public Guid servicoid { get; set; }
        public Guid colaboradorid { get; set; }
        public string observacao { get; set; }
    }
}
