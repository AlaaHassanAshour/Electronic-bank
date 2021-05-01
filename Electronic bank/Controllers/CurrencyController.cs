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

    public class CurrencyController : Controller
    {
        private ApplicationDbContext _DB;
        public CurrencyController(ApplicationDbContext DB)
        {
            _DB = DB;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var Currency = _DB.Currencyes.Include(x=>x.Wallet).ToList();
            var viweModel =new List<CurrencyVM>();
            foreach (var item in Currency)
            {
                var get = new CurrencyVM();
                get.CurrencyCode = item.CurrencyCode;
                get.Name = item.Name;
                viweModel.Add(get);

            }
            return Ok(viweModel);
        }
        [HttpPost]
        public IActionResult Create([FromBody] CurrencyDTO add)
        {
            var curancy = new Currency();
            curancy.CurrencyCode = add.CurrencyCode;
            curancy.Name = add.Name;
            _DB.Currencyes.Add(curancy);
            _DB.SaveChanges();
            return Ok("Done");
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {

            var delete = _DB.Currencyes.Find(id);
            _DB.Currencyes.Remove(delete);
            _DB.SaveChanges();


            return Ok("Done");
        }
        [HttpPut]
        public IActionResult Update(int id, [FromBody] CurrencyDTO updateCurrency)
        {
            var update = _DB.Currencyes.Find(id);
            update.Name = updateCurrency.Name;
            update.CurrencyCode= updateCurrency.CurrencyCode;
            
            _DB.Currencyes.Update(update);
            _DB.SaveChanges();
            return Ok("Done");
        }

    }
}
