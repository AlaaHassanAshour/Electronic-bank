using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Electronic_bank.Models
{
    public class Wallet
    {
        public int Id{ get; set; }
        public float Ammount{ get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public int CurrencyId { get; set; }
        public Currency Currency { get; set; }
        public List<Transaction> Transaction { get; set; }
    }
}
