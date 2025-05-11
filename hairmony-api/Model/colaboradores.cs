using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace hairmony_api.Model
{
    public class colaboradores
    {
        [Key]
        public Guid id { get; set; } = Guid.NewGuid();
        public DateTime data_criacao { get; set; }
        public string nome { get; set; }
        public bool ativo { get; set; }
        public Guid salaoId { get; set; }
    }
}
