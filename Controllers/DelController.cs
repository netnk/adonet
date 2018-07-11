using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using adonet.Models;

namespace adonet.Controllers
{
    [Route("api/[controller]")]
    public class DelController : Controller
    {
        public DelController() { }


        adonet.Service.Sqlhp ass = new adonet.Service.Sqlhp();

        // DELETE api/del/5
        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id) {            

            ass.deleteteam(id);
            return Ok("1");


        }
    }
}