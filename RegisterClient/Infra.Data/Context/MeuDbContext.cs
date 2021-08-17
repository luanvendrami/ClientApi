using Domain.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Context
{
    public class MeuDbContext : DbContext
    {
        public MeuDbContext(DbContextOptions<MeuDbContext> options)
            : base(options)
        {

        }
        public DbSet<ClientDto> Client { get; set; }
    }
}
