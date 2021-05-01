using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Electronic_bank.DTO
{
    public class WalletDTO
    {
        public float Ammount { get; set; }
        public int ClientId { get; set; }
        public int CurrencyId { get; set; }

    }
}
