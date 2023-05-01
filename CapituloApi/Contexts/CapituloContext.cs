using CapituloApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CapituloApi.Contexts
{
    public class CapituloContext : DbContext

    {
        public CapituloContext() { }

        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) 
            {
                optionsBuilder.UseSqlServer("Data Source=AMS\\SQLEXPRESS; initial catalog = exoapi; Integrated Security = true ");
            }
        }

        public DbSet<Projeto> Prj { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

    }
}
