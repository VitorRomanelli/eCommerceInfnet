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
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<Produto> ObterProdutoPorId(int id)
        {
            return await _produtoRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Produto>> ObterTodosOsProdutos()
        {
            return await _produtoRepository.GetAllAsync();
        }

        public async Task CriarProduto(Produto produto)
        {
            await _produtoRepository.AddAsync(produto);
        }
    }
}
