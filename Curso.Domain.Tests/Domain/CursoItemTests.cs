using Curso.Domain.Entities;
using Xunit;

namespace Curso.Domain.Tests.Domain
{
    public class CursoItemTests
    {
        [Fact]
        public void Deve_Verificar_Se_Nome_E_maior_Que_5()
        {
            // Arrange
            string nome = "Curso de Python";
            string url = "http://curso.com/python";

            // Act
            var cursoItem = new CursoItem(nome, url);

            // Assert
            Assert.Equal(nome, cursoItem.Nome);
        }

        [Fact]
        public void Deve_Lancar_Excecao_Se_Nome_For_Menor_Que_5()
        {
            // Arrange
            string nomeInvalido = "AB";
            string url = "http://curso.com/abc";

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => new CursoItem(nomeInvalido, url));
            Assert.Equal("O nome deve ter pelo menos 5 caracteres. (Parameter 'nome')", exception.Message);
        }




        [Fact]
        public void Deve_Verificar_Se_Url_E_Maior_Que_5()
        {
            // Arrange
            string nome = "Curso de Python";
            string url = "http://curso.com/python";

            // Act
            var cursoItem = new CursoItem(nome, url);

            // Assert
            Assert.Equal(url, cursoItem.Url);
        }



        [Fact]
        public void Deve_Lancar_Excecao_Se_Url_For_Menor_Que_5()
        {
            // Arrange
            string nome = "Curso de C#";
            string urlInvalida = "abc"; // URL menor que 5 caracteres

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => new CursoItem(nome, urlInvalida));
            Assert.Equal("A URL deve ter pelo menos 5 caracteres. (Parameter 'url')", exception.Message);
        }




    }
}
