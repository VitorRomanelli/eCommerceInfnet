using eCommerceInfnet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceInfnet.Infrastructure.ExternalServices.Pagamento.Interface
{
    public interface IPagamento
    {
        Task<bool> ProcessarPagamentoAsync(Pedido pedido);
    }
}
