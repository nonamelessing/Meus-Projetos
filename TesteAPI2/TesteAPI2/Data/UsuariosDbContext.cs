using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using TesteAPI2.Data.Map;
using TesteAPI2.Models;

namespace TesteAPI2.Data
{
    public class UsuariosDbContext : DbContext
    {
        public UsuariosDbContext(DbContextOptions<UsuariosDbContext> options)
            : base(options)
        {
        }

        public DbSet<UsuarioModel> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            base.OnModelCreating(modelBuilder);
        }

    }
}
