using System.ComponentModel.DataAnnotations;

namespace hairmony_api.Model
{
    public class agendamentos
    {
        [Key]
        public Guid id { get; set; }
        public DateTime data_de { get; set; }
        public DateTime data_ate { get; set; }
        public bool concluido { get; set; }
        public DateTime data_criacao { get; set; }

        public virtual clientes cliente { get; set; }
        public virtual servicos servico { get; set; }
        public virtual colaboradores colaborador { get; set; }
        public virtual salao salao { get; set; }

    }
}
