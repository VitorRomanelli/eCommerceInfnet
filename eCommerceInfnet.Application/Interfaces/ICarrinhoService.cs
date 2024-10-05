using eCommerceInfnet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceInfnet.Application.Interfaces
{
    public interface ICarrinhoService
    {
        Task<Carrinho> ObterCarrinhoPorClienteId(int clienteId);
        Task AdicionarItemAoCarrinho(ItemCarrinho item, int clienteId);
    }
}
