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

    public class WalletController : Controller
    {
        private ApplicationDbContext _DB;
        public WalletController(ApplicationDbContext DB)
        {
            _DB = DB;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var Wallet = _DB.Wallets.Include(x => x.Currency).Include(x=>x.Client).ToList();

            var viewModels = new List<WalletVM>();
            foreach (var item in Wallet)
            {
                var get = new WalletVM();
                get.Ammount = item.Ammount;
                viewModels.Add(get);
            }
            return Ok(viewModels);
        }
        [HttpPost]
        public IActionResult Craete([FromBody] WalletDTO add)
        {

            var get = new Wallet()
            {

                Ammount = add.Ammount,

            };
            _DB.Wallets.Add(get);
            _DB.SaveChanges();


            return Ok("Done");
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {

            var delete = _DB.Wallets.Find(id);
            _DB.Wallets.Remove(delete);
            _DB.SaveChanges();


            return Ok("Done");
        }
        [HttpPut]
        public IActionResult Update(int id, [FromBody] WalletDTO updateWallet)
        {
            var update = _DB.Wallets.Find(id);
            update.Ammount = updateWallet.Ammount;
            _DB.Wallets.Update(update);
            _DB.SaveChanges();
            return Ok("Done");
        }
    }
}
