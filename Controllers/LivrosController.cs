using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApiLivrariaVirtual.Models;

namespace WebApiLivrariaVirtual.Controllers
{
    [ApiVersion("1.0")]
    [Route("livraria-virtual/v{version:apiversion}/[controller]")]
    public class LivrosController : Controller
    {
        private static List<Livro> Livros;

        public LivrosController()
        {
            Livros = new List<Livro>()
            {
                new Livro(){  
                              Id = 1,
                              Titulo = "Designing Software Architectures: A Practical Approach (SEI Series in Software Engineering)",
                              IdEditora = 1,
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
                                                         },
                              Comentarios = new List<Comentario>(){
                                                                     new Comentario(){ Id = 4, Titulo = "Comentário 01", Descricao = "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit." },
                                                                     new Comentario(){ Id = 5, Titulo = "Comentário 02", Descricao = "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit." },
                                                                     new Comentario(){ Id = 6, Titulo = "Comentário 03", Descricao = "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit." },
                                                                  }                              
                           },
                new Livro(){
                              Id = 2,
                              Titulo = "Documenting Software Architectures: Views and Beyond (2nd Edition)",
                              IdEditora = 2,
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
                                                         },
                              Comentarios = new List<Comentario>(){
                                                                     new Comentario(){ Id = 1, Titulo = "Comentário 01", Descricao = "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit." },
                                                                     new Comentario(){ Id = 2, Titulo = "Comentário 02", Descricao = "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit." },
                                                                     new Comentario(){ Id = 3, Titulo = "Comentário 03", Descricao = "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit." },
                                                                  }                             
                           },
                new Livro(){
                              Id = 3,
                              Titulo = "Software Architecture in Practice (3rd Edition) (SEI Series in Software Engineering)",
                              IdEditora = 3,
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
                                                         },
                              Comentarios = new List<Comentario>(){
                                                                     new Comentario(){ Id = 6, Titulo = "Comentário 01", Descricao = "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit." },
                                                                     new Comentario(){ Id = 7, Titulo = "Comentário 02", Descricao = "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit." },
                                                                     new Comentario(){ Id = 8, Titulo = "Comentário 03", Descricao = "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit." },
                                                                  }                              
                           }
            };
        }

        // GET /livraria-virtual/livros
        [HttpGet]
        public IEnumerable<Livro> BuscarTodosLivros()
        {
            return Livros.ToList();
        }

        // GET /livraria-virtual/livros/{livroId}
        [HttpGet("{livroId}", Name = "BuscarLivroPorId")]
        public IActionResult BuscarLivroPorId(int livroId)
        {
            if (livroId == 0)
                return BadRequest();

            Livro livro = Livros.Where(l => l.Id == livroId).FirstOrDefault();

            if (livro == null)
                return NotFound("O livro não foi encontrado.");

            return Ok(livro);
        }

        // GET /livraria-virtual/livros/{livroId}/autores
        [HttpGet("{livroId}/autores")]
        public IActionResult BuscarAutoresDoLivro(int livroId)
        {
            if (livroId == 0)
                return BadRequest();

            Livro livro = Livros.Where(l => l.Id == livroId).FirstOrDefault();

            if (livro.Autores.Count <= 0)
                return NotFound("Autor(es) não encontrado(s).");

            var listaAutores = new List<Autor>();

            foreach (var item in livro.Autores)
            {
                var autor = new Autor();
                autor.Id = item.Id;
                autor.Nome = item.Nome;

                listaAutores.Add(autor);
            }

            return Ok(listaAutores.ToList());
        }

        // GET /livraria-virtual/livros/{livroId}/autores/{autorId}
        [HttpGet("{livroId}/autores/{autorId}")]
        public IActionResult BuscarLivrosPorAutor(int autorId)
        {
            if (autorId == 0)
                return BadRequest();

            List<Livro> listaLivrosDoAutor = Livros.Where(l => l.Autores != null && l.Autores.Any(a => a.Id == autorId)).ToList();

            if (listaLivrosDoAutor.Count <= 0)
                return NotFound("Livro(s) do autor não encontrado(s).");            

            return Ok(listaLivrosDoAutor.ToList());
        }

        // GET /livraria-virtual/livros/{livroId}/comentarios
        [HttpGet("{livroId}/comentarios")]
        public IActionResult BuscarComentariosDoLivro(int livroId)
        {
            if (livroId == 0)
                return BadRequest();

            var livro = Livros.Where(l => l.Id == livroId).FirstOrDefault();

            List<Comentario> listaComentarios = livro.Comentarios.ToList();

            if(listaComentarios.Count <= 0)
                 return NotFound("Nenhum comentário encontrado para o livro."); 

            return Ok(listaComentarios.ToList());
        }

        // GET /livraria-virtual/livros/{livroId}/comentarios/{comentarioId}
        [HttpGet("{livroId}/comentarios/{comentarioId}")]
        public IActionResult BuscarComentarioDoLivro(int livroId, int comentarioId)
        {
            if (livroId == 0)
                return BadRequest();

            var livro = Livros.Where(l => l.Id == livroId).FirstOrDefault();

            Comentario comentario = livro.Comentarios.Where(c => c.Id == comentarioId).FirstOrDefault();

            if(comentario == null)
                 return NotFound("Comentário não encontrado para o livro."); 

            return Ok(comentario);
        }

        // POST /livraria-virtual/livros
        [HttpPost]
        public IActionResult CriarLivro([FromBody] Livro livro)
        {
            if (livro == null)
                return BadRequest("Não foi possível criar o livro.");

            var filtroLivro = Livros.OrderByDescending(l => l.Id).FirstOrDefault();

            var novoLivro = new Livro(){
                                              Id = filtroLivro.Id + 1,
                                              Titulo = livro.Titulo
                                           };

            Livros.Add(novoLivro);

            return CreatedAtRoute(routeName: "BuscarLivroPorId", routeValues: new { livroId = novoLivro.Id }, value: livro);
        }


        // PUT /livraria-virtual/livros/{livroId}
        [HttpPut("{livroId}")]
        public IActionResult AtualizarLivro(int livroId, [FromBody]Livro livro)
        {
            if (livroId != livro.Id)
                return BadRequest();

            if (!LivroExiste(livroId))
                return NotFound();

            var livroSelecionado = Livros.Find(l => l.Id == livroId);

            if (livroSelecionado != null) livroSelecionado.Titulo = livro.Titulo;

            return NoContent();
        }


        // DELETE /livraria-virtual/livros/{livroId}
        [HttpDelete("{livroId}")]
        public IActionResult ExcluirLivro(int livroId, [FromBody]Livro livro)
        {
            var livroSelecionado = Livros.Find(l => l.Id == livroId);

            if (livroSelecionado == null)
                return NotFound();

            Livros.Remove(livroSelecionado);

            return Ok();
        }

        private bool LivroExiste(int id)
        {
            return Livros.Any(e => e.Id == id);
        }
    }
}