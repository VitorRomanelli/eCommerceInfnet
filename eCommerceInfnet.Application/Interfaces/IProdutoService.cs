using eCommerceInfnet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceInfnet.Application.Interfaces
{
    public interface IProdutoService
    {
        Task<Produto> ObterProdutoPorId(int id);
        Task<IEnumerable<Produto>> ObterTodosOsProdutos();
        Task CriarProduto(Produto produto);
    }
}
