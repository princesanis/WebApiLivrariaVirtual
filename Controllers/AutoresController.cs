using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApiLivrariaVirtual.Models;

namespace WebApiLivrariaVirtual.Controllers
{
    [ApiVersion("1.0")]
    [Route("livraria-virtual/v{version:apiversion}/[controller]")]
    public class AutoresController : Controller
    {
        private static List<Autor> Autores;
        private static List<Livro> Livros;

        public AutoresController()
        {
            Autores = new List<Autor>()
            {
                new Autor(){ Id = 1, Nome = "Paul Clements"},
                new Autor(){ Id = 2, Nome = "Felix Bachmann"},
                new Autor(){ Id = 3, Nome = "Len Bass"},
                new Autor(){ Id = 4, Nome = "David Garlan"},
                new Autor(){ Id = 5, Nome = "James Ivers"},
                new Autor(){ Id = 6, Nome = "Reed Little"},
                new Autor(){ Id = 7, Nome = "Paulo Merson"},
                new Autor(){ Id = 8, Nome = "Robert Nord"},
                new Autor(){ Id = 9, Nome = "Judith Stafford"},
                new Autor(){ Id = 10, Nome = "Humberto Cervantes"},
                new Autor(){ Id = 11, Nome = "Rick Kazman"}
            };

            Livros = new List<Livro>(){
                                        new Livro() {
                                                        Id = 1,
                                                        Titulo = "Designing Software Architectures: A Practical Approach (SEI Series in Software Engineering)",
                                                        NomeEditora = "Addison-Wesley Professional; 1 edition (May 23, 2016)",
                                                        CodigoISBN13 = "978-0134390789",
                                                        CodigoISBN10 = "0134390784",
                                                        NumeroPaginas = 320,
                                                        Edicao = "First Edition",                              
                                                        Idioma = "English",
                                                        Formato = "Hardcover",
                                                        Preco = 35.99,
                                                        Autores = new List<Autor>(){ 
                                                                                        new Autor(){ Id = 10, Nome = "Humberto Cervantes"},
                                                                                        new Autor(){ Id = 11, Nome = "Rick Kazman"}
                                                                                    },  },
                                        new Livro() {
                                                        Id = 2,
                                                        Titulo = "Documenting Software Architectures: Views and Beyond (2nd Edition)",
                                                        NomeEditora = "Addison-Wesley Professional; 2 edition (October 15, 2010)",
                                                        CodigoISBN13 = "978-0321552686",
                                                        CodigoISBN10 = "0321552687",
                                                        NumeroPaginas = 592,
                                                        Edicao = "Second Edition",                              
                                                        Idioma = "English",
                                                        Formato = "Hardcover",
                                                        Preco = 43.19,
                                                        Autores = new List<Autor>(){ 
                                                                                        new Autor(){ Id = 1, Nome = "Paul Clements"},
                                                                                        new Autor(){ Id = 2, Nome = "Felix Bachmann"},
                                                                                        new Autor(){ Id = 3, Nome = "Len Bass"},
                                                                                        new Autor(){ Id = 4, Nome = "David Garlan"},
                                                                                        new Autor(){ Id = 5, Nome = "James Ivers"},
                                                                                        new Autor(){ Id = 6, Nome = "Reed Little"},
                                                                                        new Autor(){ Id = 7, Nome = "Paulo Merson"},
                                                                                        new Autor(){ Id = 8, Nome = "Robert Nord"},
                                                                                        new Autor(){ Id = 9, Nome = "Judith Stafford"}                                                                                                                       
                                                                                    },  },
                                        new Livro() {   Id = 3,
                                                        Titulo = "Software Architecture in Practice (3rd Edition) (SEI Series in Software Engineering)",
                                                        NomeEditora = "Addison-Wesley Professional",
                                                        CodigoISBN13 = "978-0321815736",
                                                        CodigoISBN10 = "9780321815736",
                                                        Edicao = "Third Edition",
                                                        NumeroPaginas = 624,
                                                        Idioma = "English",
                                                        Formato = "Hardcover",
                                                        Preco = 65.19,
                                                        Autores = new List<Autor>(){ 
                                                                                        new Autor(){ Id = 1, Nome = "Paul Clements"},
                                                                                        new Autor(){ Id = 3, Nome = "Len Bass"},
                                                                                        new Autor(){ Id = 11, Nome = "Rick Kazman"}
                                                                                    },  }
                                    };            
        }

        // GET /livraria-virtual/v{apiversion}/autores
        [HttpGet]
        public IEnumerable<Autor> BuscarAutores()
        {
            return Autores.ToList();
        }

        // GET /livraria-virtual/v{apiversion}/autores/{autorId}
        [HttpGet("{autorId}", Name = "BuscarAutorPorId")]
        public IActionResult BuscarAutorPorId(int autorId)
        {
            if (autorId == 0)
                return BadRequest();

            Autor autor = Autores.Where(a => a.Id == autorId).FirstOrDefault();

            if (autor == null)
                return NotFound("O(A) autor(a) não foi encontrado(a).");

            return Ok(autor);
        }

        // GET /livraria-virtual/v{apiversion}/autores/{autorId}/livros
        // [HttpGet("{autorId}/livros")]
        // public IActionResult BuscarLivrosDoAutor(int autorId)
        // {
        //     if (autorId == 0)
        //         return BadRequest();

        //     List<Livro> listaRetorno = Livros.Where(l => l.IdAutor == autorId).ToList();

        //     if (listaRetorno.Count <= 0)
        //         return NotFound("Livro(s) não encontrado(s) para este autor.");

        //     return Ok(listaRetorno.ToList());
        // }

        // GET /livraria-virtual/v{apiversion}/autores/{autorId}/livros/{livroId}
        // [HttpGet("{autorId}/livros/{livroId}")]
        // public IActionResult BuscarLivroDoAutor(int autorId, int livroId)
        // {
        //     if (livroId == 0)
        //         return NotFound();

        //     List<Livro> listaRetorno = Livros.Where(l => l.IdAutor == autorId).ToList();

        //     var livro = listaRetorno.Where(l => l.Id == livroId).FirstOrDefault();

        //     if (livro == null)
        //         return NotFound("Livro não encontrado.");

        //     return Ok(livro);
        // }

        // POST /livraria-virtual/v{apiversion}/autores
        [HttpPost]
        public IActionResult CriarAutor([FromBody] Autor autor)
        {
            if (autor == null)
                return BadRequest("Não foi possível criar o autor.");

            var filtroAutor = Autores.OrderByDescending(a => a.Id).FirstOrDefault();

            var novoAutor = new Autor(){
                                              Id = filtroAutor.Id + 1,
                                              Nome = autor.Nome
                                           };

            Autores.Add(novoAutor);

            return CreatedAtRoute(routeName: "BuscarAutorPorId", routeValues: new { autorId = novoAutor.Id }, value: autor);
        }


        // PUT /livraria-virtual/v{apiversion}/autores/{autorId}
        [HttpPut("{autorId}")]
        public IActionResult AtualizarAutor([FromRoute] int autorId, [FromBody]Autor autor)
        {
            if (autorId != autor.Id)
                return BadRequest();

            if (!AutorExiste(autorId))
                return NotFound();

            var autorSelecionado = Autores.Find(a => a.Id == autorId);

            if (autorSelecionado != null) autorSelecionado.Nome = autor.Nome;

            return NoContent();
        }

        // DELETE /livraria-virtual/v{apiversion}/autores/{autorId}
        [HttpDelete("{autorId}")]
        public IActionResult ExcluirAutor([FromRoute] int autorId)
        {
            var autorSelecionado = Autores.Find(a => a.Id == autorId);

            if (autorSelecionado == null)
                return NotFound();

            Autores.Remove(autorSelecionado);

            return Ok();
        }

        private bool AutorExiste(int id)
        {
            return Autores.Any(a => a.Id == id);
        }
    }
}