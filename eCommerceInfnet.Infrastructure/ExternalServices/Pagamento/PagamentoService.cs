using eCommerceInfnet.Domain.Entities;
using eCommerceInfnet.Infrastructure.ExternalServices.Pagamento.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceInfnet.Infrastructure.ExternalServices.Pagamento
{
    public class PagamentoService
    {
        private readonly PagamentoFactory _pagamentoFactory;

        public PagamentoService(PagamentoFactory pagamentoFactory)
        {
            _pagamentoFactory = pagamentoFactory;
        }

        public async Task<bool> ProcessarPagamentoAsync(Pedido pedido)
        {
            IPagamento pagamento = _pagamentoFactory.CriarPagamento();
            return await pagamento.ProcessarPagamentoAsync(pedido);
        }
    }
}
