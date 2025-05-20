using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace hairmony_api.Model
{
    public class servicos
    {
        [Key]
        public Guid id { get; set; } = Guid.NewGuid();
        public DateTime data_criacao { get; set; }
        public string nome { get; set; }
        public int duracao { get; set; }
        public decimal preco { get; set; }
        public Guid salaoId { get; set; }
    }
}
