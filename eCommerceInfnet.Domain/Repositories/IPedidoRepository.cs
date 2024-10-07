using eCommerceInfnet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceInfnet.Domain.Repositories
{
    public interface IPedidoRepository
    {
        Task<Pedido?> GetByIdAsync(int id);
        Task<IEnumerable<Pedido>> GetAllAsync();
        Task AddAsync(Pedido pedido);
        Task UpdateAsync(Pedido pedido);
        Task DeleteAsync(int id);
    }
}
