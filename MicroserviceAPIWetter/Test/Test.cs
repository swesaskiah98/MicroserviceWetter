using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroserviceAPIWetter.Model;
using Npgsql;
using NUnit.Framework;
using MicroserviceAPIWetter.Controllers;

namespace MicroserviceAPIWetter.Test {

    [TestFixture]
    public class Test {
        Database database;
        [SetUp]
        public void SetUp () {
            database = new Database();
        }
        [Test]
        public void getWetter () {
            List<WetterData> wetter = new List<WetterData> { new WetterData(DateTime.Today, 20, 25, 22), new WetterData(DateTime.Today.AddDays(1), 25, 27, 0) };

            WetterData wetterHeute=database.getTodaysData(wetter);
            Assert.AreEqual(wetterHeute.datum, DateTime.Today);
        }

    }
}
