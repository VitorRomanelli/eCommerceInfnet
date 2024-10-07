using eCommerceInfnet.Domain.ValueObjects;
using eCommerceInfnet.Infrastructure.ExternalServices.Pagamento.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceInfnet.Infrastructure.ExternalServices.Pagamento
{
    public abstract class PagamentoFactory
    {
        public abstract IPagamento CriarPagamento();
    }

    public class PagamentoCartaoCreditoFactory : PagamentoFactory
    {
        private readonly CartaoCredito _cartaoCredito;

        public PagamentoCartaoCreditoFactory(CartaoCredito cartaoCredito)
        {
            _cartaoCredito = cartaoCredito;
        }

        public override IPagamento CriarPagamento()
        {
            return new PagamentoCartaoCredito(_cartaoCredito);
        }
    }

    public class PagamentoBoletoFactory : PagamentoFactory
    {
        public override IPagamento CriarPagamento()
        {
            return new PagamentoBoleto();
        }
    }
}
