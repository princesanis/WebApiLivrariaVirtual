using System;
using System.Collections;

namespace WebApiLivrariaVirtual.Models
{
    public class Livro 
    {
        public int Id { get; set; }
        public string Nome { get ; set; }
        public List<Autor> Autores { get; set; }
        public Editora Editora { get; set; }
    }    
}