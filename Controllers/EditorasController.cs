using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApiLivrariaVirtual.Models;

namespace WebApiLivrariaVirtual.Controllers
{
    [Route("livraria-virtual/[controller]")]
    public class EditorasController : Controller
    {
        private static List<Editora> Editoras;
        private static List<Livro> Livros;

        public EditorasController()
        {
            Livros = new List<Livro>()
            {
                new Livro(){
                              Autores = new List<Autor>(),
                              Comentarios = new List<Comentario>(),
                              //Editora = new Editora(){ Id = 1, Nome = "Editora A", Livros = null },
                              IdEditora = 1,
                              Id = 1,
                              Preco = 50.0,
                              Titulo = "Livro A" },
                new Livro(){
                              Autores = new List<Autor>(){ new Autor(){ Id = 2, Nome = "Teste 02"} },
                              Comentarios = new List<Comentario>(),
                              //Editora = new Editora(){ Id = 2, Nome = "Editora B", Livros = null },
                              IdEditora = 2,
                              Id = 2,
                              Preco = 100.0,
                              Titulo = "Livro B" },
                new Livro(){
                              Autores = new List<Autor>(),
                              Comentarios = new List<Comentario>(),
                              //Editora = new Editora(){ Id = 3, Nome = "Editora C", Livros = null },
                              IdEditora = 3,
                              Id = 3,
                              Preco = 150.0,
                              Titulo = "Livro C" }
            };

            Editoras = new List<Editora>()
            {
                new Editora(){
                               Livros = new List<Livro>(){
                                                           new Livro(){
                                                                         Autores = new List<Autor>(),
                                                                         Comentarios = new List<Comentario>(),
                                                                         IdEditora = 1,
                                                                         Id = 1,
                                                                         Preco = 50.0,
                                                                         Titulo = "Livro A"
                                                                      }
                                                         },
                               Id = 1,
                               Nome = "Editora A"
                },
                new Editora(){
                               Livros = new List<Livro>(){
                                                           new Livro(){
                                                                         Autores = new List<Autor>(),
                                                                         Comentarios = new List<Comentario>(),
                                                                         IdEditora = 2,
                                                                         Id = 2,
                                                                         Preco = 100.0,
                                                                         Titulo = "Livro B"
                                                                      }
                                                         },
                               Id = 2,
                               Nome = "Editora B"
                },
                new Editora(){
                               Livros = new List<Livro>(){
                                                           new Livro(){
                                                                         Autores = new List<Autor>(),
                                                                         Comentarios = new List<Comentario>(),
                                                                         IdEditora = 3,
                                                                         Id = 3,
                                                                         Preco = 150.0,
                                                                         Titulo = "Livro C"
                                                                      }
                                                         },
                               Id = 3,
                               Nome = "Editora C"
                }
            };
        }

        // GET livraria-virtual/editoras
        [HttpGet]
        public IEnumerable<Editora> BuscarEditoras()
        {
            return Editoras.ToList();
        }

        // GET livraria-virtual/editoras/{editoraId}
        [HttpGet("{editoraId}")]
        public IActionResult BuscarEditoraPorId(int editoraId)
        {
            if (editoraId == 0)
                return BadRequest();

            Editora editora = Editoras.Where(l => l.Id == editoraId).FirstOrDefault();

            if (editora == null)
                return NotFound("A editora não foi encontrada.");

            return Ok(editora);
        }

        // GET v1/livraria-virtual/editoras/{editoraId}/livros
        [HttpGet("{editoraId}/livros")]
        public IActionResult BuscarLivrosDaEditora(int editoraId)
        {
            if (editoraId == 0)
                return BadRequest();

            //Editora livro = Editoras.Where(e => e.Id == editoraId).FirstOrDefault();
            
            List<Livro> listaLivros = Livros.Where(l => l.IdEditora == editoraId).ToList();

            if (listaLivros.Count <= 0)
                return NotFound("Livro(s) não encontrado(s) para esta editora.");

            return Ok(listaLivros.ToList());
        }

        // GET v1/livraria-virtual/editoras/{editoraId}/livros/{livroId}
        [HttpGet("{editoraId}/livros/{livroId}")]
        public IActionResult BuscarLivroDaEditora(int editoraId, int livroId)
        {
            if (livroId == 0)
                return NotFound();

            // List<Livro> listaLivros = Livros.Where(l => l.Editora != null && l.Editora.Id == editoraId).ToList();
            List<Livro> listaLivros = Livros.Where(l => l.IdEditora == editoraId).ToList();

            var livro = listaLivros.Where(l => l.Id == livroId).FirstOrDefault();

            if (livro == null)
                return NotFound("Livro não encontrado.");

            return Ok(livro);
        }

        // POST v1/livraria-virtual/editoras
        [HttpPost]
        public IActionResult CriarEditora([FromBody] Editora editora)
        {
            if (editora == null)
                return BadRequest("Não foi possível criar a editora.");

            // var novaEditora = new Editora(){

            //                                };

            return CreatedAtAction("BuscarEditoraPorId", new { id = editora.Id, editora });
        }


        // PUT v1/livraria-virtual/editoras/{editoraId}
        [HttpPut("{editoraId}")]
        public IActionResult AtualizarEditora([FromRoute] int editoraId, [FromBody]Editora editora)
        {
            if (editoraId != editora.Id)
                return BadRequest();

            if (!EditoraExiste(editoraId))
                return NotFound();

            return NoContent();
        }

        // DELETE v1/livraria-virtual/editoras/{editoraId}
        [HttpDelete("{editoraId}")]
        public IActionResult ExcluirEditora([FromRoute] int editoraId)
        {
            var editora = Editoras.Find(e => e.Id == editoraId);

            if (editora == null)
                return NotFound();

            Editoras.Remove(editora);

            return Ok(editora);
        }

        private bool EditoraExiste(int id)
        {
            return Editoras.Any(e => e.Id == id);
        }
    }
}