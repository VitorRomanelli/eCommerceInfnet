using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceInfnet.Domain.ValueObjects
{
    public class Preco
    {
        public decimal Valor { get; private set; }

        public Preco(decimal valor)
        {
            Valor = valor > 0 ? valor : throw new ArgumentException("O preço deve ser positivo.");
        }
    }
}
