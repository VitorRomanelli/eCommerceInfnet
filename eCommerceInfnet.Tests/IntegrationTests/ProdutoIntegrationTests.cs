using eCommerceInfnet.Application.Services;
using eCommerceInfnet.Domain.Entities;
using eCommerceInfnet.Domain.ValueObjects;
using eCommerceInfnet.Infrastructure.Persistence;
using eCommerceInfnet.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace eCommerceInfnet.Tests.IntegrationTests
{
    public class ProdutoServiceIntegrationTests
    {
        private readonly EcommerceDbContext _context;
        private readonly ProdutoService _produtoService;
        private readonly ProdutoRepository _produtoRepository;

        public ProdutoServiceIntegrationTests()
        {
            var options = new DbContextOptionsBuilder<EcommerceDbContext>()
                .UseInMemoryDatabase(databaseName: "eCommerceTestDb")
                .Options;

            _context = new EcommerceDbContext(options);
            _produtoRepository = new ProdutoRepository(_context);
            _produtoService = new ProdutoService(_produtoRepository);
        }

        [Fact]
        public async Task CriarProduto_DeveSalvarProdutoNoBanco()
        {
            var novoProduto = new Produto
            {
                Nome = "Produto Integrado",
                Preco = new Preco(99.99m),
                Categoria = new Categoria("Eletrônicos")
            };

            await _produtoService.CriarProduto(novoProduto);

            var produtoSalvo = await _produtoRepository.GetByIdAsync(novoProduto.Id);
            Assert.NotNull(produtoSalvo);
            Assert.Equal("Produto Integrado", produtoSalvo.Nome);
            Assert.Equal(99.99m, produtoSalvo.Preco.Valor);
            Assert.Equal("Eletrônicos", produtoSalvo.Categoria.Nome);
        }

        [Fact]
        public async Task ObterProdutoPorId_DeveRetornarProdutoDoBanco()
        {
            var produto = new Produto
            {
                Nome = "Produto Teste",
                Preco = new Preco(150),
                Categoria = new Categoria("Livros")
            };
            await _produtoService.CriarProduto(produto);

            var produtoObtido = await _produtoService.ObterProdutoPorId(produto.Id);

            Assert.NotNull(produtoObtido);
            Assert.Equal("Produto Teste", produtoObtido.Nome);
            Assert.Equal(150m, produtoObtido.Preco.Valor);
            Assert.Equal("Livros", produtoObtido.Categoria.Nome);
        }

        [Fact]
        public async Task ObterTodosOsProdutos_DeveRetornarTodosOsProdutos()
        {
            var produto1 = new Produto { Nome = "Produto 1", Preco = new Preco(75), Categoria = new Categoria("Livros") };
            var produto2 = new Produto { Nome = "Produto 2", Preco = new Preco(300), Categoria = new Categoria("Eletrônicos") };
            await _produtoService.CriarProduto(produto1);
            await _produtoService.CriarProduto(produto2);

            var produtosObtidos = await _produtoService.ObterTodosOsProdutos();
            Assert.True(produtosObtidos.Count() > 2);
        }
    }
}
