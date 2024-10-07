using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eCommerceInfnet.Domain.ValueObjects;

namespace eCommerceInfnet.Domain.Entities
{
    public class Pedido
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }
        public List<ItemCarrinho> Itens { get; set; } = new List<ItemCarrinho>();
        public string? Status { get; set; }
        public DateTime DataCriacao { get; set; }
        public MetodoPagamento MetodoPagamento { get; set; }

        public CartaoCredito? CartaoCredito { get; set; }


        public decimal CalcularTotal()
        {
            decimal total = 0;
            foreach (var item in Itens)
            {
                total += item.CalcularSubTotal();
            }
            return total;
        }

        public void AtualizarStatus(string novoStatus)
        {
            Status = novoStatus;
        }
    }

    public enum MetodoPagamento
    {
        CartaoCredito,
        Boleto
    }
}
