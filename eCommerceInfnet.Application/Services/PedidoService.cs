using eCommerceInfnet.Application.Interfaces;
using eCommerceInfnet.Domain.Entities;
using eCommerceInfnet.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceInfnet.Application.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoService(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public async Task<Pedido> ObterPedidoPorId(int id)
        {
            return await _pedidoRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Pedido>> ObterTodosOsPedidos()
        {
            return await _pedidoRepository.GetAllAsync();
        }

        public async Task CriarPedido(Pedido pedido)
        {
            await _pedidoRepository.AddAsync(pedido);
        }
    }
}
