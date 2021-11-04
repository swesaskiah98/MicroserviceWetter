using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroserviceAPIWetter.Model;
using NUnit.Framework;

namespace MicroserviceAPIWetter.Test {
    [TestFixture]
    public class Test {
        Database database;
        [SetUp]
        public void SetUp () {
            database = new Database();
        }
        [Test]
        public void test1 () {
            Assert.AreEqual(1, 1);
        }
        //[Test]
        //public void databaseNotEmpty () {
        //    List<WetterData> wetterListe = database.getData();
        //    Assert.AreEqual(wetterListe[0].datum, DateTime.Today);
        //}

    }
}
