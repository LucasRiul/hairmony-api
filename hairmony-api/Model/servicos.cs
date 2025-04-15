using System.ComponentModel.DataAnnotations;

namespace hairmony_api.Model
{
    public class servicos
    {
        [Key]
        public Guid id { get; set; }
        public DateTime data_criacao { get; set; }
        public string nome { get; set; }
        public int duracao { get; set; }
        public decimal preco { get; set; }
        public virtual salao salao { get; set; }

    }
}
