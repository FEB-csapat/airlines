using Microsoft.VisualStudio.TestTools.UnitTesting;
using Database.Database.Model;
using System.Text.Json;
using Database.Database.Model.ViewModel;

namespace AirlinesApi.Controllers.Tests
{
    [TestClass()]
    public class AirlinesControllerTests
    {
        private static int testId;
        private static string testName;
         
        private static string changedName;
        
        private static AirlinesController airlinesController = new AirlinesController();

        public AirlinesControllerTests() {
            testName ??= DateTime.Now.ToString();
            changedName = "Repcsi airlines" + DateTime.Now.ToString();
        }

        [TestMethod()]
        public void T00001_PostTest()
        {
            ViewModelAirline airline = new ViewModelAirline();
            airline.Name = testName;

            airlinesController.Post(airline);
        }

        [TestMethod()]
        public void T00002_GetListTest()
        {
            string json = airlinesController.Get();
            List<Airline>? list = JsonSerializer.Deserialize<List<Airline>>(json);

            Assert.IsNotNull(list);

            Airline? airline = list.SingleOrDefault(x=>x.Name == testName);

            Assert.IsNotNull(airline);

            Assert.IsTrue(airline.Id != 0);

            testId = airline.Id;
        }

        [TestMethod()]
        public void T00003_GetItemTest()
        {
            string? json = airlinesController.Get(testId);

            Assert.IsNotNull(json);

            Airline? airline = Airline.FromJson(json);

            Assert.IsNotNull(airline);

            Assert.IsTrue(airline.Id == testId);
            Assert.IsTrue(airline.Name == testName);
        }

        [TestMethod()]
        public void T00004_PutTest()
        {
            ViewModelAirline viewModelAirline = new ViewModelAirline(changedName);

            airlinesController.Put(testId, viewModelAirline);

            string? json = airlinesController.Get(testId);

            Assert.IsNotNull(json);

            Airline? changedAirline = Airline.FromJson(json);

            Assert.IsNotNull(changedAirline);

            Assert.IsTrue(changedAirline.Id == testId);

            Assert.IsTrue(changedAirline.Name == viewModelAirline.Name);

        }

        [TestMethod()]
        public void T00005_DeleteTest()
        {
            airlinesController.Delete(testId);

            string? deletedAirlineJson = airlinesController.Get(testId);

            Assert.IsNull(deletedAirlineJson);
        }
    }
}