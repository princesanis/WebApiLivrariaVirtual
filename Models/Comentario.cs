
using System;

namespace WebApiLivrariaVirtual.Models
{
    public class Comentario
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public Livro Livro { get; set; }
    }
}