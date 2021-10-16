using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroserviceAPIWetter.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MicroserviceAPIWetter.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class WetterController : ControllerBase {
        Database database;
        [HttpGet]
        public List<WetterData> wetterData () {
            database = new Database();
            List<WetterData> dataList=database.getData();
            return dataList;
        }
        // GET: api/<WetterController>
        //[HttpGet]
        //public IEnumerable<string> Get () {
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<WetterController>/5
        //[HttpGet("{id}")]
        //public string Get (int id) {
        //    return "value";
        //}

        //// POST api/<WetterController>
        //[HttpPost]
        //public void Post ([FromBody] string value) {
        //}

        //// PUT api/<WetterController>/5
        //[HttpPut("{id}")]
        //public void Put (int id, [FromBody] string value) {
        //}

        //// DELETE api/<WetterController>/5
        //[HttpDelete("{id}")]
        //public void Delete (int id) {
        //}
    }
}
