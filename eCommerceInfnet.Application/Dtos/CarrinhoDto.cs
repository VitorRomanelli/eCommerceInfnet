using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceInfnet.Application.Dtos
{
    public class CarrinhoDto
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public List<ItemCarrinhoDto> Itens { get; set; }
        public decimal Total { get; set; }
    }

    public class ItemCarrinhoDto
    {
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public decimal SubTotal { get; set; }
    }
}
