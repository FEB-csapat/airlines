using Microsoft.VisualStudio.TestTools.UnitTesting;
using Database.Database.Model;
using System.Text.Json;
using AirlinesApi.Controllers;

namespace CitysApi.Controllers.Tests
{
    [TestClass()]
    public class CitiesControllerTests
    {
        private static int testId;
        private static string testName;
        
        private static int testPopulation;
        private static string changedName;
        private static int changedPopulation;

        private static CitiesController citysController = new CitiesController();

        public CitiesControllerTests()
        {
            testName ??= DateTime.Now.ToString();
            if (testPopulation == 0)
            {
                testPopulation = new Random().Next(10000000);
            }
            

            changedName ??= "Maglód city " + DateTime.Now.ToString();
            if (changedPopulation == 0)
            {
                changedPopulation = new Random().Next(10000000);
            }
        }

        [TestMethod()]
        public void T00001_PostTest()
        {
            City city = new City(testName, testPopulation);
            city.Name = testName;

            citysController.Post(city);
        }

        [TestMethod()]
        public void T00002_GetListTest()
        {
            string json = citysController.Get();
            List<City>? list = JsonSerializer.Deserialize<List<City>>(json);

            Assert.IsNotNull(list);

            City? city = list.SingleOrDefault(x => x.Name == testName);

            Assert.IsNotNull(city);

            Assert.IsTrue(city.Id != 0);

            testId = city.Id;
        }

        [TestMethod()]
        public void T00003_GetItemTest()
        {
            string? json = citysController.Get(testId);

            Assert.IsNotNull(json);

            City? city = City.FromJson(json);

            Assert.IsNotNull(city);

            Assert.IsTrue(city.Id == testId);
            Assert.IsTrue(city.Name == testName);
            Assert.IsTrue(city.Population == testPopulation);
        }

        [TestMethod()]
        public void T00004_PutTest()
        {
            City changedCity = new City(changedName, changedPopulation);

            citysController.Put(testId, changedCity);

            string? json = citysController.Get(testId);

            Assert.IsNotNull(json);

            City? newCity = City.FromJson(json);

            Assert.IsNotNull(newCity);

            Assert.IsTrue(newCity.Id == testId);

            Assert.IsTrue(newCity.Name == changedCity.Name);

            Assert.IsTrue(newCity.Population == changedCity.Population);

        }

        [TestMethod()]
        public void T00005_DeleteTest()
        {
            citysController.Delete(testId);

            string? deletedCityJson = citysController.Get(testId);

            Assert.IsNull(deletedCityJson);
        }
    }
}