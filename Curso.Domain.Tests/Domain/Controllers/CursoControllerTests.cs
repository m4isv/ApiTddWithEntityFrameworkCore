using Moq;
using Curso.Domain.Infra.Services;
using Curso.API.Controllers;
using Curso.Domain.Entities;
using Microsoft.AspNetCore.Mvc;


namespace Curso.Domain.Tests.Domain.Controllers
{
    public class CursoControllerTests
    {

        private readonly Mock<ICursoService> _cursoServiceMock;
        private readonly CursoController _controller;

        public CursoControllerTests()
        {
            _cursoServiceMock = new Mock<ICursoService>();
            _controller = new CursoController(_cursoServiceMock.Object);
        }


        [Fact]
        public void GetCursos_DeveRetornarListaDeCursos()
        {
            // Arrange
            var cursos = new List<CursoItem>
            {
                new() { Id = 1, Nome = "Curso de C#", Url = "https://curso-csharp.com" },
                new() { Id = 2, Nome = "Curso de .NET", Url = "https://curso-dotnet.com" }
            };

            _cursoServiceMock.Setup(s => s.ObterTodos()).Returns(cursos);

            // Act
            var resultado = _controller.GetCursos();
            var okResult = resultado.Result as OkObjectResult;

            // Assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
            Assert.Equal(cursos, okResult.Value);
        }

        [Fact]
        public void GetCurso_ComIdExistente_DeveRetornarCurso()
        {
            // Arrange
            var curso = new CursoItem { Id = 1, Nome = "Curso de C#", Url = "https://curso-csharp.com" };

            _cursoServiceMock.Setup(s => s.ObterPorId(1)).Returns(curso);

            // Act
            var resultado = _controller.GetCurso(1);
            var okResult = resultado.Result as OkObjectResult;

            // Assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
            Assert.Equal(curso, okResult.Value);
        }

        [Fact]
        public void GetCurso_ComIdInexistente_DeveRetornarNotFound()
        {
            // Arrange
            _cursoServiceMock.Setup(s => s.ObterPorId(999)).Returns((CursoItem)null);

            // Act
            var actionResult = _controller.GetCurso(999);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(actionResult.Result);
            Assert.NotNull(notFoundResult);
        }



        [Fact]
        public void CriarCurso_ComDadosValidos_DeveRetornarCursoCriado()
        {
            // Arrange
            var request = new CursoRequest { Nome = "Curso de Testes", Url = "https://curso-testes.com" };
            var cursoCriado = new CursoItem { Id = 10, Nome = request.Nome, Url = request.Url };

            _cursoServiceMock.Setup(s => s.CriarCurso(request.Nome, request.Url)).Returns(cursoCriado);

            // Act
            var resultado = _controller.CriarCurso(request);

            // Assert
            var actionResult = Assert.IsType<ActionResult<CursoItem>>(resultado);
            var createdAtAction = Assert.IsType<CreatedAtActionResult>(actionResult.Result);
            var cursoRetornado = Assert.IsType<CursoItem>(createdAtAction.Value);

            Assert.Equal(cursoCriado, cursoRetornado);
        }




        [Fact]
        public void CriarCurso_ComDadosInvalidos_DeveRetornarBadRequest()
        {
            // Arrange
            var request = new CursoRequest { Nome = "", Url = "" };

            _cursoServiceMock.Setup(s => s.CriarCurso(request.Nome, request.Url))
                .Throws(new ArgumentException("Nome e URL são obrigatórios."));

            // Act
            var resultado = _controller.CriarCurso(request);

            // Assert
            var actionResult = Assert.IsType<ActionResult<CursoItem>>(resultado);
            var badRequest = Assert.IsType<BadRequestObjectResult>(actionResult.Result);

            Assert.Equal(400, badRequest.StatusCode);
        }





        [Fact]
        public void DeletarCurso_ComIdExistente_DeveRetornarNoContent()
        {
            // Arrange
            _cursoServiceMock.Setup(s => s.DeletarCurso(1)).Returns(true);

            // Act
            var resultado = _controller.DeletarCurso(1) as NoContentResult;

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal(204, resultado.StatusCode);
        }

        [Fact]
        public void DeletarCurso_ComIdInexistente_DeveRetornarNotFound()
        {
            // Arrange
            _cursoServiceMock.Setup(s => s.DeletarCurso(999)).Returns(false);

            // Act
            var resultado = _controller.DeletarCurso(999);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(resultado);
            Assert.NotNull(notFoundResult);
        }









    }
}