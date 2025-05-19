using System.ComponentModel.DataAnnotations;

namespace hairmony_api.Model
{
    public class salao
    {
        [Key]
        public Guid id { get; set; } = Guid.NewGuid();
        public string nome { get; set; }
        public string senha { get; set; }
        public DateTime data_criacao { get; set; } = DateTime.UtcNow;
    }
}
