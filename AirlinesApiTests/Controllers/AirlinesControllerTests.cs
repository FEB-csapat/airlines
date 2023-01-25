using Microsoft.VisualStudio.TestTools.UnitTesting;
using AirlinesApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Database;
using System.Text.Json;
using Database.Database.Model;

namespace AirlinesApi.Controllers.Tests
{
    [TestClass()]
    public class AirlinesControllerTests
    {
        public AirlinesControllerTests() {
            App.RunTest();
        }

        [TestMethod()]
        public void GetTest()
        {
          //  AirlinesController airlinesController = new AirlinesController();

          //  string json = airlinesController.Get();
          //  List<Airline>? list = JsonSerializer.Deserialize<List<Airline>>(json);//Serialize(Context.Instance.Airlines.ToList());

            Assert.IsNotNull(list);

        }

        [TestMethod()]
        public void GetTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void PostTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void PutTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteTest()
        {
            Assert.Fail();
        }
    }
}