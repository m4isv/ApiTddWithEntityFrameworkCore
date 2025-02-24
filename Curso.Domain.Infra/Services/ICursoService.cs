using Curso.Domain.Entities;
using System.Collections.Generic;

namespace Curso.Domain.Infra.Services
{
    public interface ICursoService
    {
        /// <summary>
        /// Cria um novo curso.
        /// </summary>
        /// <param name="nome">Nome do curso.</param>
        /// <param name="url">URL do curso.</param>
        /// <returns>O curso criado.</returns>
        CursoItem CriarCurso(string nome, string url);

        /// <summary>
        /// Obtém um curso pelo seu ID.
        /// </summary>
        /// <param name="id">ID do curso.</param>
        /// <returns>O curso encontrado ou null se não existir.</returns>
        CursoItem? ObterPorId(int id);

        /// <summary>
        /// Obtém todos os cursos.
        /// </summary>
        /// <returns>Uma lista de cursos.</returns>
        List<CursoItem> ObterTodos();

        /// <summary>
        /// Atualiza um curso existente.
        /// </summary>
        /// <param name="id">ID do curso a ser atualizado.</param>
        /// <param name="nome">Novo nome do curso.</param>
        /// <param name="url">Nova URL do curso.</param>
        /// <returns>O curso atualizado ou null se o curso não for encontrado.</returns>
        CursoItem? AtualizarCurso(int id, string nome, string url);

        /// <summary>
        /// Deleta um curso pelo seu ID.
        /// </summary>
        /// <param name="id">ID do curso a ser deletado.</param>
        /// <returns>True se o curso foi deletado com sucesso, False caso contrário.</returns>
        bool DeletarCurso(int id);
    }
}