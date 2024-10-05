using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceInfnet.Domain.ValueObjects
{
    public class Categoria
    {
        public string Nome { get; private set; }

        public Categoria(string nome)
        {
            Nome = !string.IsNullOrWhiteSpace(nome) ? nome : throw new ArgumentException("A categoria não pode ser vazia.");
        }
    }
}
