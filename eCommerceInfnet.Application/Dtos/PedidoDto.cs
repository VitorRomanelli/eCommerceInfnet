using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceInfnet.Application.Dtos
{
    public class PedidoDto
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public List<ItemPedidoDto> Itens { get; set; }
        public string Status { get; set; }
        public DateTime DataCriacao { get; set; }
        public decimal Total { get; set; }
    }

    public class ItemPedidoDto
    {
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public decimal SubTotal { get; set; }
    }
}
