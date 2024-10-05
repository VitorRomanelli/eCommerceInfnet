using eCommerceInfnet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceInfnet.Domain.Aggregates
{
    public class PedidoAggregate
    {
        public Pedido Pedido { get; private set; }

        public PedidoAggregate(Pedido pedido)
        {
            Pedido = pedido;
        }

        public void FinalizarPedido()
        {
            Pedido.AtualizarStatus("Finalizado");
        }
    }
}
