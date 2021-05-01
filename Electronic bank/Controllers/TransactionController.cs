using Electronic_bank.Data;
using Electronic_bank.DTO;
using Electronic_bank.Models;
using Electronic_bank.ViweModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Electronic_bank.Controllers
{
    [Route("api/[controller]/[action]")]

    public class TransactionController : Controller
    {
        private ApplicationDbContext _DB;
        public TransactionController(ApplicationDbContext DB)
        {
            _DB = DB;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var Transaction = _DB.Transactions.Include(x=>x.Wallet).Select(m=>new TransactionVM()
            {
                Ammount = m.Ammount,
                Decrption = m.Decrption,
                TransactionDate= m.TransactionDate,
            }).ToList();
            /*
            var viewModels = new List<TransactionVM>();


            foreach (var item in Transaction)
            {
                var get = new TransactionVM();
                get.Ammount = item.Ammount;
                get.Decrption = item.Decrption;
                get.TransactionDate = item.TransactionDate;

                viewModels.Add(get);
            }*/
            return Ok(Transaction);
        }
        [HttpPost]
        public IActionResult Craete([FromBody] TransactionDTO add)
        {
            var get = new Transaction()
            {
                Ammount=add.Ammount,
                Decrption=add.Decrption,
                TransactionDate=add.TransactionDate,
            };
            _DB.Transactions.Add(get);
            _DB.SaveChanges();
            return Ok("Done");
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var delete = _DB.Transactions.Find(id);
            _DB.Transactions.Remove(delete);
            _DB.SaveChanges();
            return Ok("Done");
        }
        [HttpPut]
        public IActionResult Update(int id, [FromBody] TransactionDTO updateTransaction)
        {
            var update = _DB.Transactions.Find(id);
            update.TransactionDate= updateTransaction.TransactionDate;
            update.Ammount = updateTransaction.Ammount;
            update.Decrption = updateTransaction.Decrption;
            _DB.Transactions.Update(update);
            _DB.SaveChanges();
            return Ok("Done");
        }
    }
}
