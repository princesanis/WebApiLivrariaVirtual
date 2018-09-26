using System.Collections.Generic;

namespace WebApiLivrariaVirtual.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public StatusPedido Status { get; set;}
        public List<Livro> Livros { get; set;}

        public enum StatusPedido
        {
            Realizado = 0,
            EmPreparacao = 1,
            EmTransito = 2,
            Cancelado = 3,
            Entregue = 4
        }
    }
}