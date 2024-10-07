using eCommerceInfnet.Domain.Entities;
using eCommerceInfnet.Domain.ValueObjects;
using eCommerceInfnet.Infrastructure.ExternalServices.Pagamento.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceInfnet.Infrastructure.ExternalServices.Pagamento
{
    public class PagamentoCartaoCredito : IPagamento
    {
        private readonly CartaoCredito _cartaoCredito;

        public PagamentoCartaoCredito(CartaoCredito cartaoCredito)
        {
            _cartaoCredito = cartaoCredito;
        }

        public async Task<bool> ProcessarPagamentoAsync(Pedido pedido)
        {
            // Simulação de processamento de pagamento com cartão de crédito
            bool pagamentoRealizado = await SimularPagamento(_cartaoCredito, pedido.CalcularTotal());

            if (pagamentoRealizado)
            {
                pedido.Status = "Pago";
            }
            else
            {
                pedido.Status = "Pagamento Falhou";
            }

            return pagamentoRealizado;
        }

        private async Task<bool> SimularPagamento(CartaoCredito cartaoCredito, decimal valor)
        {
            await Task.Delay(1000); // Simula o tempo de processamento
            return true; // Assume que o pagamento foi bem-sucedido
        }
    }
}
