using eCommerceInfnet.Application.Services;
using eCommerceInfnet.Domain.Entities;
using eCommerceInfnet.Domain.Repositories;
using eCommerceInfnet.Domain.ValueObjects;
using Moq;

namespace eCommerceInfnet.Tests.UnitTests
{
    public class CarrinhoServiceTests
    {
        private readonly Mock<ICarrinhoRepository> _carrinhoRepositoryMock;
        private readonly CarrinhoService _carrinhoService;

        public CarrinhoServiceTests()
        {
            _carrinhoRepositoryMock = new Mock<ICarrinhoRepository>();
            _carrinhoService = new CarrinhoService(_carrinhoRepositoryMock.Object);
        }

        [Fact]
        public async Task ObterCarrinhoPorClienteId_DeveRetornarCarrinhoCorreto()
        {
            var clienteId = 1;
            var carrinhoEsperado = new Carrinho
            {
                ClienteId = clienteId,
                Itens = new List<ItemCarrinho>
                {
                    new ItemCarrinho
                    {
                        Produto = new Produto { Nome = "Produto Teste", Preco = new Preco(50) },
                        Quantidade = 2,
                    }
                }
            };

            _carrinhoRepositoryMock.Setup(repo => repo.GetCarrinhoByClienteIdAsync(clienteId))
                .ReturnsAsync(carrinhoEsperado);

            var carrinhoObtido = await _carrinhoService.ObterCarrinhoPorClienteId(clienteId);

            Assert.NotNull(carrinhoObtido);
            Assert.Equal(clienteId, carrinhoObtido.ClienteId);
            Assert.Single(carrinhoObtido.Itens);
        }

        [Fact]
        public async Task AdicionarItemAoCarrinho_DeveAdicionarItemCorretamente()
        {
            var clienteId = 1;
            var carrinhoExistente = new Carrinho { ClienteId = clienteId };
            _carrinhoRepositoryMock.Setup(repo => repo.GetCarrinhoByClienteIdAsync(clienteId))
                .ReturnsAsync(carrinhoExistente);

            var novoItem = new ItemCarrinho
            {
                Produto = new Produto { Nome = "Novo Produto", Preco = new Preco(100) },
                Quantidade = 1,
                CarrinhoId = carrinhoExistente.Id
            };

            _carrinhoRepositoryMock.Setup(repo => repo.UpdateAsync(It.IsAny<Carrinho>()))
                .Returns(Task.CompletedTask).Verifiable();

            await _carrinhoService.AdicionarItemAoCarrinho(novoItem, clienteId);

            _carrinhoRepositoryMock.Verify(repo => repo.UpdateAsync(It.IsAny<Carrinho>()), Times.Once);
            Assert.Single(carrinhoExistente.Itens);
        }
    }
}
