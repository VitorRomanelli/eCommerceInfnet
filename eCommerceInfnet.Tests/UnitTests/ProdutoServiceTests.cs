using eCommerceInfnet.Application.Services;
using eCommerceInfnet.Domain.Entities;
using eCommerceInfnet.Domain.Repositories;
using eCommerceInfnet.Domain.ValueObjects;
using Moq;

namespace eCommerceInfnet.Tests.UnitTests
{
    public class ProdutoServiceTests
    {
        private readonly Mock<IProdutoRepository> _produtoRepositoryMock;
        private readonly ProdutoService _produtoService;

        public ProdutoServiceTests()
        {
            _produtoRepositoryMock = new Mock<IProdutoRepository>();
            _produtoService = new ProdutoService(_produtoRepositoryMock.Object);
        }

        [Fact]
        public async Task ObterProdutoPorId_DeveRetornarProdutoCorreto()
        {
            var produtoId = 1;
            var produtoEsperado = new Produto
            {
                Id = produtoId,
                Nome = "Produto Teste",
                Preco = new Preco(100),
                Categoria = new Categoria("Eletrônicos")
            };

            _produtoRepositoryMock.Setup(repo => repo.GetByIdAsync(produtoId))
                .ReturnsAsync(produtoEsperado);

            var produtoObtido = await _produtoService.ObterProdutoPorId(produtoId);

            Assert.NotNull(produtoObtido);
            Assert.Equal(produtoEsperado.Id, produtoObtido.Id);
            Assert.Equal(produtoEsperado.Nome, produtoObtido.Nome);
            Assert.Equal(produtoEsperado.Preco.Valor, produtoObtido.Preco.Valor);
            Assert.Equal(produtoEsperado.Categoria.Nome, produtoObtido.Categoria.Nome);
        }

        [Fact]
        public async Task ObterTodosOsProdutos_DeveRetornarListaDeProdutos()
        {
            var listaProdutos = new List<Produto>
        {
            new Produto { Id = 1, Nome = "Produto 1", Preco = new Preco(50), Categoria = new Categoria("Livros") },
            new Produto { Id = 2, Nome = "Produto 2", Preco = new Preco(200), Categoria = new Categoria("Eletrônicos") }
        };
            _produtoRepositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(listaProdutos);

            var produtosObtidos = await _produtoService.ObterTodosOsProdutos();

            Assert.NotNull(produtosObtidos);
            Assert.Equal(2, produtosObtidos.Count());
        }

        [Fact]
        public async Task CriarProduto_DeveAdicionarProduto()
        {
            var novoProduto = new Produto { Nome = "Novo Produto", Preco = new Preco(150), Categoria = new Categoria("Móveis") };
            _produtoRepositoryMock.Setup(repo => repo.AddAsync(novoProduto))
                .Returns(Task.CompletedTask).Verifiable();

            await _produtoService.CriarProduto(novoProduto);

            _produtoRepositoryMock.Verify(repo => repo.AddAsync(novoProduto), Times.Once);
        }
    }
}
