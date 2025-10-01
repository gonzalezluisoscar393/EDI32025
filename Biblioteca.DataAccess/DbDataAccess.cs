using Biblioteca.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.DataAccess
{
    public class DbDataAccess : IdentityDbContext
    {
        public virtual DbSet<Libro> Libros { get; set; }
        public virtual DbSet<Autor> Autores { get; set; }
        public virtual DbSet<Editorial> Editoriales { get; set; }
        public virtual DbSet<Genero> Generos { get; set; }
        public virtual DbSet<AutorPorLibro> AutoresPorLibros { get; set; }
        public virtual DbSet<GeneroPorLibro> GenerosPorLibros { get; set; }
        public DbDataAccess(DbContextOptions<DbDataAccess> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.LogTo(Console.WriteLine).EnableDetailedErrors();
    }
}
