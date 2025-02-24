namespace Curso.Domain.Entities
{
    public class CursoItem
    {
        public int Id { get; set; }
        public string Nome { get; set; } // Setter público
        public string Url { get; set; } // Setter público

        // Construtor sem parâmetros necessário para o EF Core
        public CursoItem()
        {
        }

        // Construtor parametrizado com validações
        public CursoItem(string nome, string url)
        {
            if (string.IsNullOrWhiteSpace(nome) || nome.Length < 5)
                throw new ArgumentException("O nome deve ter pelo menos 5 caracteres.", nameof(nome));

            if (string.IsNullOrWhiteSpace(url) || url.Length < 5)
                throw new ArgumentException("A URL deve ter pelo menos 5 caracteres.", nameof(url));

            Nome = nome;
            Url = url;
        }

        // Método para atualizar os dados do curso
        public void AtualizarDados(string nome, string url)
        {
            if (string.IsNullOrWhiteSpace(nome) || nome.Length < 5)
                throw new ArgumentException("O nome deve ter pelo menos 5 caracteres.", nameof(nome));

            if (string.IsNullOrWhiteSpace(url) || url.Length < 5)
                throw new ArgumentException("A URL deve ter pelo menos 5 caracteres.", nameof(url));

            Nome = nome;
            Url = url;
        }
    }
}