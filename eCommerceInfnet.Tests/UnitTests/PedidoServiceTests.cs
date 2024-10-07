using eCommerceInfnet.Application.Services;
using eCommerceInfnet.Domain.Entities;
using eCommerceInfnet.Domain.Repositories;
using eCommerceInfnet.Domain.ValueObjects;
using eCommerceInfnet.Infrastructure.ExternalServices.Pagamento;
using Moq;

namespace eCommerceInfnet.Tests.UnitTests
{

    public class PedidoServiceTests
    {
        private readonly Mock<IPedidoRepository> _pedidoRepositoryMock;
        private readonly Mock<PagamentoService> _pagamentoServiceMock;
        private readonly PedidoService _pedidoService;

        public PedidoServiceTests()
        {
            _pedidoRepositoryMock = new Mock<IPedidoRepository>();
            _pagamentoServiceMock = new Mock<PagamentoService>(null);
            _pedidoService = new PedidoService(_pedidoRepositoryMock.Object);
        }

        [Fact]
        public async Task ObterPedidoPorId_DeveRetornarPedidoCorreto()
        {
            var pedidoId = 1;
            var pedidoEsperado = new Pedido { Id = pedidoId };

            _pedidoRepositoryMock.Setup(repo => repo.GetByIdAsync(pedidoId))
                .ReturnsAsync(pedidoEsperado);

            var pedidoObtido = await _pedidoService.ObterPedidoPorId(pedidoId);

            Assert.NotNull(pedidoObtido);
            Assert.Equal(pedidoId, pedidoObtido.Id);
        }

        [Fact]
        public async Task CriarPedido_DeveAdicionarPedidoEProcessarPagamentoComCartaoCredito()
        {
            var pedido = new Pedido
            {
                Id = 1,
                ClienteId = 1,
                MetodoPagamento = MetodoPagamento.CartaoCredito,
                CartaoCredito = new CartaoCredito("5526439810149314", new DateTime(2026, 04, 07))
            };

            _pedidoRepositoryMock.Setup(repo => repo.AddAsync(pedido))
                .Returns(Task.CompletedTask);

            await _pedidoService.CriarPedido(pedido);

            _pedidoRepositoryMock.Verify(repo => repo.AddAsync(pedido), Times.Once);
            Assert.Equal("Pago", pedido.Status);
        }

        [Fact]
        public async Task CriarPedido_DeveAdicionarPedidoEProcessarPagamentoComBoleto()
        {
            var pedido = new Pedido
            {
                Id = 1,
                ClienteId = 1,
                MetodoPagamento = MetodoPagamento.Boleto
            };

            _pedidoRepositoryMock.Setup(repo => repo.AddAsync(pedido))
                .Returns(Task.CompletedTask);

            await _pedidoService.CriarPedido(pedido);

            _pedidoRepositoryMock.Verify(repo => repo.AddAsync(pedido), Times.Once);
            Assert.Equal("Aguardando Pagamento", pedido.Status);
        }
    }

}