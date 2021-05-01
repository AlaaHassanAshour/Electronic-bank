using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Electronic_bank.Models
{
    public class Transaction
    {
        public int Id{ get; set; }
        public float Ammount{ get; set; }
        public string Decrption{ get; set; }
        public DateTime TransactionDate { get; set; }
        public int WalletId{ get; set; }
        public Wallet Wallet { get; set; }
        //Add Transaction Type (withdraw, deposit, transfer)
        public enum TransactionType { withdraw = 0, deposit = 1, transfer = 2}

    }
}
