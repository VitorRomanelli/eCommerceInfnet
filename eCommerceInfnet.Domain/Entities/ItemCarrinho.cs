using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceInfnet.Domain.Entities
{
    public class ItemCarrinho
    {
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }

        public decimal CalcularSubTotal()
        {
            return Produto.Preco.Valor * Quantidade;
        }
    }
}
