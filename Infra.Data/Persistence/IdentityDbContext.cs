using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Core.Domain.Entities;
namespace Infra.Data.Persistence
{
    public class IdentityDbContext : IdentityDbContext<User>
    {
        public IdentityDbContext(DbContextOptions<IdentityDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Configurações adicionais, se necessário
        }
    }
}
