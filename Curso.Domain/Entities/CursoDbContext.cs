
using Microsoft.EntityFrameworkCore;

namespace Curso.Domain.Entities
{
    public class CursoDbContext : DbContext
    {
        public CursoDbContext(DbContextOptions<CursoDbContext> options) : base(options)
        {
        }

        public DbSet<CursoItem> CursoItems { get; set; } = null!;

    }
}