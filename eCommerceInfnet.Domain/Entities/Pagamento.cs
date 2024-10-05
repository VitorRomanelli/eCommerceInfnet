using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceInfnet.Domain.Entities
{
    public class Pagamento
    {
        public int Id { get; set; }
        public decimal Valor { get; set; }
        public string Status { get; set; }
    }
}
