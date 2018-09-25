using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApiLivrariaVirtual.Models;

namespace WebApiLivrariaVirtual.Controllers
{
    [Route("livraria-virtual/[controller]")]
    public class LivrosController : Controller
    {
        private static List<Livro> Livros;

        public LivrosController()
        {
            Livros = new List<Livro>()
            {
                new Livro(){
                              Autores = new List<Autor>(),
                              Comentarios = new List<Comentario>(),
                              Editora = new Editora(),
                              Id = 1,
                              Preco = 50.0,
                              Titulo = "Livro A" },
                new Livro(){
                              Autores = new List<Autor>(){ new Autor(){ Id = 2, Nome = "Teste 02"} },
                              Comentarios = new List<Comentario>(),
                              Editora = new Editora(){ Id = 2, Nome = "Editora 02", Livros = null },
                              Id = 2,
                              Preco = 100.0,
                              Titulo = "Livro B" },
                new Livro(){
                              Autores = new List<Autor>(),
                              Comentarios = new List<Comentario>(),
                              Editora = new Editora(),
                              Id = 3,
                              Preco = 150.0,
                              Titulo = "Livro C" }
            };
        }

        // GET livraria-virtual/livros
        [HttpGet]
        public IEnumerable<Livro> Get()
        {
            return Livros.ToList();
        }

        // GET livraria-virtual/livros/{livroId}
        [HttpGet("{livroId}")]
        public IActionResult Get(int livroId)
        {
            if (livroId == 0)
                return BadRequest();

            Livro livro = Livros.Where(l => l.Id == livroId).FirstOrDefault();

            if (livro == null)
                return NotFound("O livro não foi encontrado.");

            return Ok(livro);
        }

        // GET v1/livraria-virtual/livros/{livroId}/autores
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

        // GET v1/livraria-virtual/livros/{livroId}/autores/{autorId}
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

        // GET v1/livraria-virtual/livros/{livroId}/comentarios
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

        // GET v1/livraria-virtual/livros/{livroId}/comentarios/{comentarioId}
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

        // POST v1/livraria-virtual/livros
        [HttpPost]
        public IActionResult CriarLivro([FromBody] Livro livro)
        {
            //TODO: Implementar o método

            return Ok();
        }


        // PUT v1/livraria-virtual/livros/{livroId}
        [HttpPut("{livroId}")]
        public IActionResult AtualizarLivro(int livroId, [FromBody]Livro livro)
        {
            //TODO: Implementar o método

            return Ok();
        }


        // DELETE v1/livraria-virtual/livros/{livroId}
        [HttpDelete("{livroId}")]
        public IActionResult ExcluirLivro(int livroId, [FromBody]Livro livro)
        {
            //TODO: Implementar o método

            return Ok();
        }
    }
}