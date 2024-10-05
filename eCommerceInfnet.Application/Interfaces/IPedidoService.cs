using eCommerceInfnet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceInfnet.Application.Interfaces
{
    public interface IPedidoService
    {
        Task<Pedido> ObterPedidoPorId(int id);
        Task<IEnumerable<Pedido>> ObterTodosOsPedidos();
        Task CriarPedido(Pedido pedido);
    }
}
