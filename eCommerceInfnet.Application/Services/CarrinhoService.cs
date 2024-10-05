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
    public class CarrinhoService : ICarrinhoService
    {
        private readonly ICarrinhoRepository _carrinhoRepository;

        public CarrinhoService(ICarrinhoRepository carrinhoRepository)
        {
            _carrinhoRepository = carrinhoRepository;
        }

        public async Task<Carrinho> ObterCarrinhoPorClienteId(int clienteId)
        {
            return await _carrinhoRepository.GetCarrinhoByClienteIdAsync(clienteId);
        }

        public async Task AdicionarItemAoCarrinho(ItemCarrinho item, int clienteId)
        {
            var carrinho = await _carrinhoRepository.GetCarrinhoByClienteIdAsync(clienteId);
            carrinho.AdicionarItem(item);
            await _carrinhoRepository.UpdateAsync(carrinho);
        }
    }
}
