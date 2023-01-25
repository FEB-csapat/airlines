using Microsoft.VisualStudio.TestTools.UnitTesting;
using AirlinesApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Database.Model;
using System.Text.Json;
using Database.Database.Model.ViewModel;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace AirlinesApi.Controllers.Tests
{
    [TestClass()]
    public class AirlinesControllerTests
    {
        int testId;
        string testName = "Test123";

        [TestMethod()]
        public void PostTest()
        {
            AirlinesController airlinesController = new AirlinesController();

            ViewModelAirline airline = new ViewModelAirline();
            airline.Name = testName;

            airlinesController.Post(airline);
        }

        [TestMethod()]
        public void GetTest()
        {
            AirlinesController airlinesController = new AirlinesController();

            string json = airlinesController.Get();
            List<Airline>? list = JsonSerializer.Deserialize<List<Airline>>(json);//Serialize(Context.Instance.Airlines.ToList());

            Assert.IsNotNull(list);

            Airline? airline = list.SingleOrDefault(x=>x.Name == testName);

            Assert.IsNotNull(airline);

            Assert.IsTrue(airline.Id != 0);

            testId = airline.Id;
        }

        [TestMethod()]
        public void GetTest2()
        {
            AirlinesController airlinesController = new AirlinesController();

            string? json = airlinesController.Get(testId);

            Assert.IsNotNull(json);

            Airline? airline = Airline.FromJson(json);

            Assert.IsNotNull(airline);

            Assert.IsTrue(airline.Id == testId);
            Assert.IsTrue(airline.Name == testName);
        }

        [TestMethod()]
        public void PutTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteTest()
        {
            AirlinesController airlinesController = new AirlinesController();


            airlinesController.Delete(testId);

            string? deletedAirlineJson = airlinesController.Get(testId);


            Assert.IsNull(deletedAirlineJson);
        }
    }
}