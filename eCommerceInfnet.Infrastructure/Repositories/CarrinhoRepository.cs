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
    public class CarrinhoRepository : ICarrinhoRepository
    {
        private readonly EcommerceDbContext _context;

        public CarrinhoRepository(EcommerceDbContext context)
        {
            _context = context;
        }

        public async Task<Carrinho> GetCarrinhoByClienteIdAsync(int clienteId)
        {
            return await _context.Carrinhos
                .Include(c => c.Itens)
                .FirstOrDefaultAsync(c => c.ClienteId == clienteId);
        }

        public async Task AddAsync(Carrinho carrinho)
        {
            await _context.Carrinhos.AddAsync(carrinho);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Carrinho carrinho)
        {
            _context.Carrinhos.Update(carrinho);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var carrinho = await _context.Carrinhos.FindAsync(id);
            if (carrinho != null)
            {
                _context.Carrinhos.Remove(carrinho);
                await _context.SaveChangesAsync();
            }
        }
    }
}
