using Curso.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Curso.Domain.Infra.Services
{
    public class CursoService : ICursoService
    {
        private readonly CursoDbContext _context;

        public CursoService(CursoDbContext context)
        {
            _context = context;
        }

        public CursoItem CriarCurso(string nome, string url)
        {
            // Usando o construtor parametrizado de CursoItem
            var curso = new CursoItem(nome, url);
            _context.CursoItems.Add(curso); // Usando o DbSet correto: CursoItems
            _context.SaveChanges();
            return curso;
        }

        public CursoItem? ObterPorId(int id)
        {
            return _context.CursoItems.FirstOrDefault(c => c.Id == id); // Usando o DbSet correto: CursoItems
        }

        public List<CursoItem> ObterTodos()
        {
            return _context.CursoItems.ToList(); // Usando o DbSet correto: CursoItems
        }

        public CursoItem? AtualizarCurso(int id, string nome, string url)
        {
            var curso = _context.CursoItems.FirstOrDefault(c => c.Id == id); // Usando o DbSet correto: CursoItems
            if (curso == null) return null;

            // Usando o método AtualizarDados da classe CursoItem
            curso.AtualizarDados(nome, url);
            _context.SaveChanges();
            return curso;
        }

        public bool DeletarCurso(int id)
        {
            var curso = _context.CursoItems.FirstOrDefault(c => c.Id == id); // Usando o DbSet correto: CursoItems
            if (curso == null) return false;

            _context.CursoItems.Remove(curso); // Usando o DbSet correto: CursoItems
            _context.SaveChanges();
            return true;
        }
    }
}