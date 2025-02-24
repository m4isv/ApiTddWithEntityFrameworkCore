using Curso.Domain.Entities;
using Curso.Domain.Infra.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Curso.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize] // Requer JWT para acessar
    public class CursoController : ControllerBase
    {
        private readonly ICursoService _cursoService;

        public CursoController(ICursoService cursoService)
        {
            _cursoService = cursoService;
        }

        // GET: api/Curso
        [HttpGet]
        public ActionResult<IEnumerable<CursoItem>> GetCursos()
        {
            var cursos = _cursoService.ObterTodos();
            return Ok(cursos);
        }

        // GET: api/Curso/5
        [HttpGet("{id}")]
        public ActionResult<CursoItem> GetCurso(int id)
        {
            var curso = _cursoService.ObterPorId(id);

            if (curso == null)
            {
                return NotFound(new { erro = "Curso não encontrado." });
            }

            return Ok(curso);
        }

        // POST: api/Curso
        [HttpPost]
        public ActionResult<CursoItem> CriarCurso([FromBody] CursoRequest request)
        {
            try
            {
                var curso = _cursoService.CriarCurso(request.Nome, request.Url);
                return CreatedAtAction(nameof(GetCurso), new { id = curso.Id }, curso);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { erro = ex.Message });
            }
        }

        // PUT: api/Curso/5
        [HttpPut("{id}")]
        public IActionResult AtualizarCurso(int id, [FromBody] CursoRequest request)
        {
            try
            {
                var cursoAtualizado = _cursoService.AtualizarCurso(id, request.Nome, request.Url);

                if (cursoAtualizado == null)
                {
                    return NotFound(new { erro = "Curso não encontrado." });
                }

                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { erro = ex.Message });
            }
        }

        // DELETE: api/Curso/5
        [HttpDelete("{id}")]
        public IActionResult DeletarCurso(int id)
        {
            var sucesso = _cursoService.DeletarCurso(id);

            if (!sucesso)
            {
                return NotFound(new { erro = "Curso não encontrado." });
            }

            return NoContent();
        }
    }

    public class CursoRequest
    {
        public string? Nome { get; set; }
        public string? Url { get; set; }
    }
}
