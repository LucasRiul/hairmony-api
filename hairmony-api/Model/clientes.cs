using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace hairmony_api.Model
{
    public class clientes
    {
        [Key]
        public Guid id { get; set; } = Guid.NewGuid();
        public string nome { get; set; }
        public string celular { get; set; }
        public DateTime data_criacao { get; set; }
        public Guid salaoId { get; set; }

        [JsonIgnore, NotMapped]
        [ValidateNever]
        public virtual salao salao { get; set; }

    }
}
