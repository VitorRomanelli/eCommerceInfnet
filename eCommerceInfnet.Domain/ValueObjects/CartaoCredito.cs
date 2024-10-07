using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceInfnet.Domain.ValueObjects
{
    public class CartaoCredito
    {
        public int Id { get; set; }
        public string Numero { get; private set; }
        public DateTime Validade { get; private set; }

        public CartaoCredito() { }

        public CartaoCredito(string numero, DateTime dataValidade)
        {
            if (string.IsNullOrWhiteSpace(numero) || numero.Length != 16)
                throw new ArgumentException("Número do cartão inválido.");

            if (dataValidade <= DateTime.Now)
                throw new ArgumentException("O cartão está vencido.");

            Numero = numero;
            Validade = dataValidade;
        }
    }
}
