using System.ComponentModel.DataAnnotations;

namespace hairmony_api.Model
{
    public class clientes
    {
        [Key]
        public Guid id { get; set; }
        public string nome { get; set; }
        public string celular { get; set; }
        public DateTime data_criacao { get; set; }
        public virtual salao salao { get; set; }

    }
}
