using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Electronic_bank.Models
{
    public class Currency
    {
        public int Id{ get; set; }
        public string Name{ get; set; }
        public string CurrencyCode { get; set; }
        public List<Wallet> Wallet { get; set; }
    }
}
