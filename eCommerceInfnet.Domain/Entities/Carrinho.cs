using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceInfnet.Domain.Entities
{
    public class Carrinho
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public List<ItemCarrinho> Itens { get; set; } = new List<ItemCarrinho>();

        public void AdicionarItem(ItemCarrinho item)
        {
            Itens.Add(item);
        }

        public void RemoverItem(ItemCarrinho item)
        {
            Itens.Remove(item);
        }

        public decimal CalcularTotal()
        {
            return Itens.Sum(i => i.CalcularSubTotal());
        }
    }
}
