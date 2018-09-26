using System.Collections.Generic;

namespace WebApiLivrariaVirtual.Models
{
    public class Carrinho
    {
        public int Id { get; set; }
        public List<Livro> Livros { get; set; }

        public Carrinho(int idCarrinho, List<Livro> livros)
        {
            Id = idCarrinho;
            Livros = livros;
        }
    }   
}