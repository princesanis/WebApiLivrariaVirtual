using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApiLivrariaVirtual.Models;
using static WebApiLivrariaVirtual.Models.Pedido;

namespace WebApiLivrariaVirtual.Controllers
{
    [Route("livraria-virtual/[controller]")]
    public class PedidosController : Controller
    {
        private static List<Pedido> Pedidos;
        public PedidosController()
        {
            Pedidos = new List<Pedido>()
            {
                new Pedido(){
                               Id = 1,
                               Status = StatusPedido.Realizado,
                               Livros = new List<Livro>()
                             },
                new Pedido(){
                               Id = 2,
                               Status = StatusPedido.EmPreparacao,
                               Livros = new List<Livro>()
                             },
                new Pedido(){
                               Id = 3,
                               Status = StatusPedido.EmTransito,
                               Livros = new List<Livro>()
                             },
                new Pedido(){
                               Id = 4,
                               Status = StatusPedido.Entregue,
                               Livros = new List<Livro>()
                             },
                new Pedido(){
                               Id = 5,
                               Status = StatusPedido.Cancelado,
                               Livros = new List<Livro>()
                             }                                                          
            };
        }

        // GET v1/livraria-virtual/pedidos
        [HttpGet]
        public IEnumerable<Pedido> BuscarPedidos()
        {
            return Pedidos.ToList();
        }

        // GET v1/livraria-virtual/pedidos/{pedidoId}
        [HttpGet("{pedidoId}", Name = "BuscarPedidoPorId")]
        public IActionResult BuscarPedidoPorId(int pedidoId)
        {
            if (pedidoId == 0)
                return BadRequest();

            Pedido pedido = Pedidos.Where(l => l.Id == pedidoId).FirstOrDefault();

            if (pedido == null)
                return NotFound("O pedido não foi encontrado.");

            return Ok(pedido);
        }

        // POST v1/livraria-virtual/pedidos
        [HttpPost]
        public IActionResult CriarPedido([FromBody] Pedido pedido)
        {
            if (pedido == null)
                return BadRequest("Não foi possível criar o pedido.");

            var filtroPedido = Pedidos.OrderByDescending(p => p.Id).FirstOrDefault();

            var novoPedido = new Pedido(){
                                              Id = filtroPedido.Id + 1,
                                              Status = StatusPedido.Realizado,
                                              Livros = new List<Livro>()
                                           };

            Pedidos.Add(novoPedido);

            return CreatedAtRoute(
                                    routeName: "BuscarPedidoPorId", 
                                    routeValues: new { pedidoId = novoPedido.Id }, 
                                    value: pedido
                                 );
        }
    }
}