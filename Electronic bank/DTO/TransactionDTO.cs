using Electronic_bank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Electronic_bank.DTO
{
    public class TransactionDTO
    {
        public float Ammount { get; set; }
        public string Decrption { get; set; }
        public DateTime TransactionDate { get; set; }
        //Add Transaction Type (withdraw, deposit, transfer)
        public enum TransactionType { withdraw = 0, deposit = 1, transfer = 2 }
    }
}
