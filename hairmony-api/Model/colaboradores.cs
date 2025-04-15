using System.ComponentModel.DataAnnotations;

namespace hairmony_api.Model
{
    public class colaboradores
    {
        [Key]
        public Guid id { get; set; }
        public DateTime data_criacao { get; set; }
        public string nome { get; set; }
        public bool ativo { get; set; }
        public virtual salao salao { get; set; }


    }
}
