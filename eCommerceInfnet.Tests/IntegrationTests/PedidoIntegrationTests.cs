
using eCommerceInfnet.Application.Services;
using eCommerceInfnet.Domain.Entities;
using eCommerceInfnet.Domain.Repositories;
using eCommerceInfnet.Domain.ValueObjects;
using eCommerceInfnet.Infrastructure.Persistence;
using eCommerceInfnet.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace eCommerceInfnet.Tests.IntegrationTests
{
    public class PedidoServiceIntegrationTests
    {
        private readonly EcommerceDbContext _context;
        private readonly PedidoService _pedidoService;
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoServiceIntegrationTests()
        {
            var options = new DbContextOptionsBuilder<EcommerceDbContext>()
                .UseInMemoryDatabase(databaseName: "eCommerceTestDb")
                .Options;

            _context = new EcommerceDbContext(options);
            _pedidoRepository = new PedidoRepository(_context);
            _pedidoService = new PedidoService(_pedidoRepository);
        }

        [Fact]
        public async Task CriarPedido_DeveAdicionarPedidoComPagamento()
        {
            var pedido = new Pedido
            {
                ClienteId = 1,
                MetodoPagamento = MetodoPagamento.CartaoCredito,
                CartaoCredito = new CartaoCredito("5526439810149314", new DateTime(2026, 04, 07))
            };

            await _pedidoService.CriarPedido(pedido);

            var pedidoSalvo = await _pedidoRepository.GetByIdAsync(pedido.Id);
            Assert.NotNull(pedidoSalvo);
            Assert.Equal("Pago", pedidoSalvo.Status);
        }

        [Fact]
        public async Task ObterTodosOsPedidos_DeveRetornarTodosOsPedidosSalvos()
        {
            var pedido1 = new Pedido { ClienteId = 1, MetodoPagamento = MetodoPagamento.CartaoCredito };
            var pedido2 = new Pedido { ClienteId = 2, MetodoPagamento = MetodoPagamento.Boleto };

            _context.Pedidos.Add(pedido1);
            _context.Pedidos.Add(pedido2);
            await _context.SaveChangesAsync();

            var pedidos = await _pedidoService.ObterTodosOsPedidos();

            Assert.Equal(2, pedidos.Count());
        }
    }
}
