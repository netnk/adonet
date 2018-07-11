using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using adonet.Models;


namespace adonet.Controllers
{
    [Route("api/[controller]")]
    public class QueryController : Controller
    {
        public QueryController() { }

        adonet.Service.Sqlhp ass = new adonet.Service.Sqlhp();

        // GET api/query
        [HttpGet("")]
        public ActionResult Gets()
        {
            List<Team> lr = new List<Team>();
            lr = ass.getreader();
            return Json(lr);
        }

        // GET api/query/5
        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            return Json(ass.getreaderone(id));
        }

        // POST api/query
        [HttpPost("")]
        public void Post([FromBody] string value) { }

        // PUT api/query/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value) { }

        // DELETE api/query/5
        [HttpDelete("{id}")]
        public void DeleteById(int id) { }
    }
}