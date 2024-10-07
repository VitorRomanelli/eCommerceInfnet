using eCommerceInfnet.Application.Services;
using eCommerceInfnet.Domain.Entities;
using eCommerceInfnet.Domain.ValueObjects;
using eCommerceInfnet.Infrastructure.Persistence;
using eCommerceInfnet.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace eCommerceInfnet.Tests.IntegrationTests
{
    public class CarrinhoServiceIntegrationTests
    {
        private readonly EcommerceDbContext _context;
        private readonly CarrinhoService _carrinhoService;
        private readonly CarrinhoRepository _carrinhoRepository;

        public CarrinhoServiceIntegrationTests()
        {
            var options = new DbContextOptionsBuilder<EcommerceDbContext>()
                .UseInMemoryDatabase(databaseName: "eCommerceTestDb")
                .Options;

            _context = new EcommerceDbContext(options);
            _carrinhoRepository = new CarrinhoRepository(_context);
            _carrinhoService = new CarrinhoService(_carrinhoRepository);
        }

        [Fact]
        public async Task ObterCarrinhoPorClienteId_DeveRetornarCarrinhoSalvo()
        {
            var clienteId = 2;
            var carrinho = new Carrinho
            {
                ClienteId = clienteId,
                Itens = new List<ItemCarrinho>
            {
                new ItemCarrinho
                {
                    Produto = new Produto { Nome = "Produto Teste", Preco = new Preco(50) },
                    Quantidade = 2
                }
            }
            };

            _context.Carrinhos.Add(carrinho);
            await _context.SaveChangesAsync();

            var carrinhoObtido = await _carrinhoService.ObterCarrinhoPorClienteId(clienteId);

            Assert.NotNull(carrinhoObtido);
            Assert.Equal(clienteId, carrinhoObtido.ClienteId);
            Assert.Single(carrinhoObtido.Itens);
        }

        [Fact]
        public async Task AdicionarItemAoCarrinho_DeveAdicionarItemEAtualizarCarrinhoNoBanco()
        {
            var clienteId = 1;
            var carrinho = new Carrinho { ClienteId = clienteId };
            _context.Carrinhos.Add(carrinho);
            await _context.SaveChangesAsync();

            var novoItem = new ItemCarrinho
            {
                Produto = new Produto { Nome = "Novo Produto", Preco = new Preco(75) },
                Quantidade = 1,
                CarrinhoId = carrinho.Id
            };

            await _carrinhoService.AdicionarItemAoCarrinho(novoItem, clienteId);

            var carrinhoAtualizado = await _context.Carrinhos.Include(c => c.Itens).FirstOrDefaultAsync(c => c.Id == carrinho.Id);
            Assert.Single(carrinhoAtualizado.Itens);
            Assert.Equal("Novo Produto", carrinhoAtualizado.Itens.First().Produto.Nome);
            Assert.Equal(75m, carrinhoAtualizado.Itens.First().Produto.Preco.Valor);
        }
    }

}
