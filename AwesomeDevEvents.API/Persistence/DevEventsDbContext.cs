using AwesomeDevEvents.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace AwesomeDevEvents.API.Persistence
{
    public class DevEventsDbContext : DbContext
    {
        // Ctor que será utilizado pelo EntityFramework Core, na parte de configuração
        public DevEventsDbContext(DbContextOptions<DevEventsDbContext> options) : base(options)
        {

        }
        // Objeto que vai armazenar o estado do nosso banco de dados
        public DbSet<DevEvent>? DevEvents { get; set; }
        public DbSet<DevEventPalestrantes>? DevEventPalestrantes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<DevEvent>(e =>
            {
                // Passando chave primária
                e.HasKey(de => de.Id);

                // Titulo
                e.Property(de => de.Titulo)
                    .IsRequired(true)
                    .HasMaxLength(180)
                    .HasColumnType("varchar(180)");

                // Descricao
                e.Property(de => de.Descricao)
                    .IsRequired(false)
                    .HasMaxLength(200)
                    .HasColumnType("varchar(200)");

                // DataInicio
                e.Property(de => de.DataInicio)
                     .IsRequired(true)
                     .HasColumnName("Data_Inicio")
                     .HasColumnType("date");

                // DataFinal
                e.Property(de => de.DataFinal)
                     .IsRequired(true)
                     .HasColumnName("Data_Final")
                     .HasColumnType("date");

                // Relacionamento entre 'DevEvent' e 'DevEventPalestrantes'
                e.HasMany(de => de.Palestrantes)
                    .WithOne()
                    .HasForeignKey(p => p.DevEventId);
            });

            builder.Entity<DevEventPalestrantes>(e => 
            {
                // Passando chave primária
                e.HasKey(deS => deS.Id);
            });
        }

    }
}
