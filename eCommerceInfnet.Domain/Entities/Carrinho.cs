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
        public List<ItemCarrinho>? Itens { get; set; }

        public void AdicionarItem(ItemCarrinho item)
        {
            Itens ??= [];

            Itens.Add(item);
        }

        public void RemoverItem(ItemCarrinho item)
        {
            if (Itens == null)
                return;

            Itens.Remove(item);
        }

        public decimal CalcularTotal()
        {
            Itens ??= [];

            return Itens.Sum(i => i.CalcularSubTotal());
        }
    }
}
