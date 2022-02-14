using Microsoft.EntityFrameworkCore;

namespace CadastroUsuario.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> option) : base(option) { }

        public DbSet<Usuario> Usuarios { get; set; }

    }
}
