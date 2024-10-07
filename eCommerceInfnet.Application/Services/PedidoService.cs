using eCommerceInfnet.Application.Interfaces;
using eCommerceInfnet.Domain.Entities;
using eCommerceInfnet.Domain.Repositories;
using eCommerceInfnet.Infrastructure.ExternalServices.Pagamento;
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
            PagamentoFactory pagamentoFactory = CriarPagamentoFactory(pedido);

            var pagamentoService = new PagamentoService(pagamentoFactory);
            bool pagamentoRealizado = await pagamentoService.ProcessarPagamentoAsync(pedido);

            await _pedidoRepository.AddAsync(pedido);
        }

        private PagamentoFactory CriarPagamentoFactory(Pedido pedido)
        {
            if (pedido.MetodoPagamento == MetodoPagamento.CartaoCredito)
            {
                return new PagamentoCartaoCreditoFactory(pedido.CartaoCredito);
            }
            else if (pedido.MetodoPagamento == MetodoPagamento.Boleto)
            {
                return new PagamentoBoletoFactory();
            }

            throw new ArgumentException("Método de pagamento não suportado.");
        }
    }
}
