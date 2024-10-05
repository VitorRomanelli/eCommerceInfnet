using eCommerceInfnet.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace eCommerceInfnet.Infrastructure.Persistence
{
    public class EcommerceDbContext(DbContextOptions<EcommerceDbContext> options) : DbContext(options)
    {
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Carrinho> Carrinhos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
