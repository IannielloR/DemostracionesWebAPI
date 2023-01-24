using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using WebApiLibros.Moldes;

namespace WebApiLibros.Data
{
    public class DBLibrosContext:DbContext
    {
        public DBLibrosContext(DbContextOptions<DBLibrosContext> options
            ):base(options) {}
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Libro> Libros { get; set; }
    }
}
