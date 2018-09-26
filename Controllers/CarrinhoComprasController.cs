
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApiLivrariaVirtual.Models;

namespace WebApiLivrariaVirtual.Controllers
{
    [Route("livraria-virtual/[controller]")]
    public class CarrinhoComprasController : Controller
    {
        private static IDictionary<int, Carrinho> Carrinhos = new Dictionary<int, Carrinho>();

        public CarrinhoComprasController()
        {
            Carrinhos.Add(1, new Carrinho(1, new List<Livro>()));
            Carrinhos.Add(2, new Carrinho(2, new List<Livro>()));
            Carrinhos.Add(3, new Carrinho(3, new List<Livro>()));
        }

        // GET v1/livraria-virtual/carrinhos/{carrinhoId}
        [HttpGet("{carrinhoId}")]
        public IActionResult BuscarLivrosCarrinho(int carrinhoId)
        {            
            Carrinho carrinho = null;

            Carrinhos.TryGetValue(carrinhoId, out carrinho);

            if (carrinho != null)
                return Ok(carrinho);

            return NotFound("O carrinho não foi encontrado.");
        }

        // PUT v1/livraria-virtual/carrinhos/{carrinhoId}/livros/{livroId}
        [HttpPut("{carrinhoId}/livros/{livroId}")]
        public IActionResult AdicionarLivro(int carrinhoId, int livroId)
        {
            Carrinho carrinho = null;

            Carrinhos.TryGetValue(carrinhoId, out carrinho);

            if (carrinho == null) 
            {
                carrinho = new Carrinho(carrinhoId, new List<Livro>());
                Carrinhos.Add(carrinhoId, carrinho);
            }

            Livro livro = BuscarLivroPorId(livroId).Result;

            if (!carrinho.Livros.Contains(livro)) 
                carrinho.Livros.Add(livro);

            return Ok(livro);
        }

        // DELETE v1/livraria-virtual/carrinhos/{carrinhoId}
        [HttpDelete("{carrinhoId}")]
        public IActionResult EsvaziarCarrinho(int carrinhoId)
        {
            Carrinho carrinho  = null;

            Carrinhos.TryGetValue(carrinhoId, out carrinho);

            if (carrinho != null) 
            {
                carrinho.Livros = new List<Livro>();
                return Ok();
            }

            return NotFound("O carrinho não foi encontrado.");
        }

        // DELETE v1/livraria-virtual/carrinhos/{carrinhoId}/livros/{livroId}
        [HttpDelete("{carrinhoId}")]
        public IActionResult ExcluirLivroCarrinho(int carrinhoId, [FromRoute] int livroId)
        {
            Carrinho carrinho  = null;

            Carrinhos.TryGetValue(carrinhoId, out carrinho);
        
            if (carrinho != null) 
            {
                var livroSelecionado = carrinho.Livros.Find(c => c.Id == livroId);

                carrinho.Livros.Remove(livroSelecionado);

                return Ok();
            }

            return NotFound("O carrinho não foi encontrado.");
        }

        public async Task<Livro> BuscarLivroPorId(int livroId) 
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5000/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response =  client.GetAsync("livraria-virtual/livros/"+ livroId).Result;

                if(response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Livro>(result);
                }

                return null;
            }
        }        
    }
}