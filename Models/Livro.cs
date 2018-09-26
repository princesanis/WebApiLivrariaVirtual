using System;
using System.Collections;
using System.Collections.Generic;

namespace WebApiLivrariaVirtual.Models
{
    public class Livro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int IdEditora { get; set; }
        public string NomeEditora { get; set; }
        public string CodigoISBN13 { get; set; }
        public string CodigoISBN10 { get; set; }
        public int NumeroPaginas { get; set; }
        public string Edicao { get; set; }
        public string Idioma { get; set; }
        public string Formato { get; set; }
        public double Preco { get; set; }
        public List<Autor> Autores { get; set; }        
        public List<Comentario> Comentarios { get; set; }

        public Livro() { }
    }
}