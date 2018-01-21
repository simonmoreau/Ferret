using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ferret.Models;

namespace Ferret.Controllers
{
    [Route("api/[controller]")]
    public class MainController : Controller
    {
        private readonly FerretContext _context;

        public MainController(FerretContext context)
        {
            _context = context;
        }

        // GET api/main
        [HttpGet]
        public IEnumerable<string> Get()
        {
            Ferret.Services.SeLogerRetriever retriever = new Ferret.Services.SeLogerRetriever(_context);
            retriever.Retrive();
            return new string[] { "value1", "value2" };
        }

        // GET api/main/number
        [HttpGet("number")]
        public string GetNumber()
        {
            return _context.HousingUnits.Count().ToString();
        }

        // GET api/main/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/main
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/main/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
