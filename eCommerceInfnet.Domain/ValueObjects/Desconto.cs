using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceInfnet.Domain.ValueObjects
{
    public class Desconto
    {
        public decimal Percentual { get; private set; }

        public Desconto(decimal percentual)
        {
            Percentual = percentual >= 0 && percentual <= 100 ? percentual : throw new ArgumentException("O desconto deve ser entre 0 e 100.");
        }

        public decimal AplicarDesconto(decimal valor)
        {
            return valor - (valor * (Percentual / 100));
        }
    }
}
