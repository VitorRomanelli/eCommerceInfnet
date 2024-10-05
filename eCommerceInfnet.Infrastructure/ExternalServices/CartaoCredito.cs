using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceInfnet.Infrastructure.ExternalServices
{
    public class CartaoCredito
    {
        public string Numero { get; private set; }
        public string NomeTitular { get; private set; }
        public DateTime DataValidade { get; private set; }
        public string CodigoSeguranca { get; private set; }

        public CartaoCredito(string numero, string nomeTitular, DateTime dataValidade, string codigoSeguranca)
        {
            if (string.IsNullOrWhiteSpace(numero) || numero.Length != 16)
                throw new ArgumentException("Número do cartão inválido.");

            if (string.IsNullOrWhiteSpace(nomeTitular))
                throw new ArgumentException("Nome do titular é obrigatório.");

            if (dataValidade <= DateTime.Now)
                throw new ArgumentException("O cartão está vencido.");

            if (string.IsNullOrWhiteSpace(codigoSeguranca) || codigoSeguranca.Length != 3)
                throw new ArgumentException("Código de segurança inválido.");

            Numero = numero;
            NomeTitular = nomeTitular;
            DataValidade = dataValidade;
            CodigoSeguranca = codigoSeguranca;
        }

        public bool ProcessarPagamento(decimal valor)
        {
            return true;
        }
    }
}
