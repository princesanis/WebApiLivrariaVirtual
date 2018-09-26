using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApiLivrariaVirtual.Models;

namespace WebApiLivrariaVirtual.Controllers
{
    [ApiVersion("1.0")]
    [Route("livraria-virtual/v{version:apiversion}/[controller]")]
    public class EditorasController : Controller
    {
        private static List<Editora> Editoras;
        private static List<Livro> Livros;

        public EditorasController()
        {
            Editoras = new List<Editora>()
            {
                new Editora(){
                               Id = 1,
                               Nome = "Addison-Wesley Professional",
                             },
                new Editora(){
                               Id = 2,
                               Nome = "Microsoft Press",
                             },
                new Editora(){
                               Id = 3,
                               Nome = "Manning Publications",
                             }                                                       
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

        // GET /livraria-virtual/v{apiversion}/editoras
        [HttpGet]
        public IEnumerable<Editora> BuscarEditoras()
        {
            return Editoras.ToList();
        }

        // GET /livraria-virtual/v{apiversion}/editoras/{editoraId}
        [HttpGet("{editoraId}", Name = "BuscarEditoraPorId")]
        public IActionResult BuscarEditoraPorId(int editoraId)
        {
            if (editoraId == 0)
                return BadRequest();

            Editora editora = Editoras.Where(l => l.Id == editoraId).FirstOrDefault();

            if (editora == null)
                return NotFound("A editora não foi encontrada.");

            return Ok(editora);
        }

        // GET /livraria-virtual/v{apiversion}/editoras/{editoraId}/livros
        [HttpGet("{editoraId}/livros")]
        public IActionResult BuscarLivrosDaEditora(int editoraId)
        {
            if (editoraId == 0)
                return BadRequest();

            List<Livro> listaRetorno = Livros.Where(l => l.IdEditora == editoraId).ToList();

            if (listaRetorno.Count <= 0)
                return NotFound("Livro(s) não encontrado(s) para esta editora.");

            return Ok(listaRetorno.ToList());
        }

        // GET /livraria-virtual/v{apiversion}/editoras/{editoraId}/livros/{livroId}
        [HttpGet("{editoraId}/livros/{livroId}")]
        public IActionResult BuscarLivroDaEditora(int editoraId, int livroId)
        {
            if (livroId == 0)
                return NotFound();

            // List<Livro> listaLivros = Livros.Where(l => l.Editora != null && l.Editora.Id == editoraId).ToList();
            List<Livro> listaRetorno = Livros.Where(l => l.IdEditora == editoraId).ToList();

            var livro = listaRetorno.Where(l => l.Id == livroId).FirstOrDefault();

            if (livro == null)
                return NotFound("Livro não encontrado.");

            return Ok(livro);
        }

        // POST /livraria-virtual/v{apiversion}/editoras
        [HttpPost]
        public IActionResult CriarEditora([FromBody] Editora editora)
        {
            if (editora == null)
                return BadRequest("Não foi possível criar a editora.");

            var filtroEditora = Editoras.OrderByDescending(e => e.Id).FirstOrDefault();

            var novaEditora = new Editora(){
                                              Id = filtroEditora.Id + 1,
                                              Nome = editora.Nome
                                           };

            Editoras.Add(novaEditora);

            return CreatedAtRoute(routeName: "BuscarEditoraPorId", routeValues: new { editoraId = novaEditora.Id }, value: editora);
        }


        // PUT /livraria-virtual/v{apiversion}/editoras/{editoraId}
        [HttpPut("{editoraId}")]
        public IActionResult AtualizarEditora([FromRoute] int editoraId, [FromBody]Editora editora)
        {
            if (editoraId != editora.Id)
                return BadRequest();

            if (!EditoraExiste(editoraId))
                return NotFound();

            var editoraSelecionada = Editoras.Find(e => e.Id == editoraId);

            if (editoraSelecionada != null) editoraSelecionada.Nome = editora.Nome;

            return NoContent();
        }

        // DELETE /livraria-virtual/v{apiversion}/editoras/{editoraId}
        [HttpDelete("{editoraId}")]
        public IActionResult ExcluirEditora([FromRoute] int editoraId)
        {
            var editora = Editoras.Find(e => e.Id == editoraId);

            if (editora == null)
                return NotFound();

            Editoras.Remove(editora);

            return Ok();
        }

        private bool EditoraExiste(int id)
        {
            return Editoras.Any(e => e.Id == id);
        }
    }
}