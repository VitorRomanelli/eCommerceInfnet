using eCommerceInfnet.Domain.Entities;
using eCommerceInfnet.Domain.Repositories;
using eCommerceInfnet.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceInfnet.Infrastructure.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly EcommerceDbContext _context;

        public PedidoRepository(EcommerceDbContext context)
        {
            _context = context;
        }

        public async Task<Pedido> GetByIdAsync(int id)
        {
            return await _context.Pedidos
                .Include(p => p.Itens)
                .Include(p => p.Cliente)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Pedido>> GetAllAsync()
        {
            return await _context.Pedidos
                .Include(p => p.Itens)
                .ToListAsync();
        }

        public async Task AddAsync(Pedido pedido)
        {
            await _context.Pedidos.AddAsync(pedido);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Pedido pedido)
        {
            _context.Pedidos.Update(pedido);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var pedido = await GetByIdAsync(id);
            if (pedido != null)
            {
                _context.Pedidos.Remove(pedido);
                await _context.SaveChangesAsync();
            }
        }
    }
}
