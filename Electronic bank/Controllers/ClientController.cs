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

    public class ClientController : Controller
    {
        private ApplicationDbContext _DB;
        public ClientController(ApplicationDbContext DB)
        {
            _DB = DB;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var Client = _DB.Client.ToList();

            var viewModels = new List<ClinetVM>();


            foreach (var item in Client)
            {
                var get = new ClinetVM();
                get.Address = item.Address;
                get.Name = item.Name;
                get.Phone = item.Phone;



                viewModels.Add(get);
            }
            return Ok(viewModels);
        }
        [HttpPost]
        public IActionResult Craete([FromBody] ClinetDTO addClinet)
        {

            var get = new Client()
            {

                Name = addClinet.Name,
                Address=addClinet.Address,
                Phone=addClinet.Phone,
            };
            _DB.Client.Add(get);
            _DB.SaveChanges();


            return Ok("Done");
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {

            var delete = _DB.Client.Find(id);
            _DB.Client.Remove(delete);
            _DB.SaveChanges();


            return Ok("Done");
        }
        [HttpPut]
        public IActionResult Update(int id, [FromBody] ClinetDTO updateClinet)
        {
            var update = _DB.Client.Find(id);
            update.Name = updateClinet.Name;
            update.Address = updateClinet.Address;
            update.Phone = updateClinet.Phone;
            _DB.Client.Update(update);
            _DB.SaveChanges();
            return Ok("Done");
        }

    }
}
