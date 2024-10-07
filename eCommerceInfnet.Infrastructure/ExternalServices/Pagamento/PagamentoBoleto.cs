using eCommerceInfnet.Domain.Entities;
using eCommerceInfnet.Infrastructure.ExternalServices.Pagamento.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceInfnet.Infrastructure.ExternalServices.Pagamento
{
    public class PagamentoBoleto : IPagamento
    {
        public async Task<bool> ProcessarPagamentoAsync(Pedido pedido)
        {
            await Task.Delay(2000);
            pedido.Status = "Aguardando Pagamento";
            return true;
        }
    }
}
