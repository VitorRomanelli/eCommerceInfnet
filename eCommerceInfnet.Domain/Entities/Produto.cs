using eCommerceInfnet.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceInfnet.Domain.Entities
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Preco Preco { get; set; }
        public Categoria Categoria { get; set; }
    }
}
