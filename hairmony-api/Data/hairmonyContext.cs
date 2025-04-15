using hairmony_api.Model;
using Microsoft.EntityFrameworkCore;

namespace hairmony_api.Data
{
    public class hairmonyContext : DbContext
    {
        public hairmonyContext(DbContextOptions<hairmonyContext> options)
        : base(options)
        {

        }
        public DbSet<agendamentos> agendamentos{ get; set; }
        public DbSet<clientes> clientes { get; set; }
        public DbSet<colaboradores> colaboradores { get; set; }
        public DbSet<salao> salao { get; set; }
        public DbSet<servicos> servicos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory()) // ou AppContext.BaseDirectory
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .Build();

                var connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseNpgsql(connectionString);
            }
        }
    }
}
