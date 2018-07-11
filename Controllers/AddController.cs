using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using adonet.Models;

namespace adonet.Controllers
{
    [Route("api/[controller]")]
    public class AddController : Controller
    {
        public AddController() { }

         adonet.Service.Sqlhp ass = new adonet.Service.Sqlhp();

        // GET api/add
     
      

        // GET api/add/5
      

       
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Team team) {
             if (team == null)
            {
                return NotFound();
            }   

            ass.updateteam(id, team);

            return Ok("1");


         }

        // PUT api/add/5
      
    }
}