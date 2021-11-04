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
            List<WetterData> dataList=database.getData(database.openConnection());
            return dataList;
        }
        [HttpGet ("/api/heute")]
        public WetterData oneDate () {
            database = new Database();
            List<WetterData> dataList = database.getData(database.openConnection());
            WetterData wetterHeute = database.getTodaysData(dataList);
            return wetterHeute;
        }
    }
}
