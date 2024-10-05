using eCommerceInfnet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceInfnet.Domain.Repositories
{
    public interface ICarrinhoRepository
    {
        Task<Carrinho> GetCarrinhoByClienteIdAsync(int clienteId);
        Task AddAsync(Carrinho carrinho);
        Task UpdateAsync(Carrinho carrinho);
        Task DeleteAsync(int id);
    }
}
