using Microsoft.VisualStudio.TestTools.UnitTesting;
using Database.Database.Model;
using System.Text.Json;
using AirlinesApi.Controllers;
using Database.Database.Model.ViewModel;

namespace FlightsApi.Controllers.Tests
{
    [TestClass()]
    public class FlightssControllerTests
    {
        private static int testId;

        private static int testArlineId = 1;
        private static int testFromId = 1;
        private static int testDestinationId = 2;

        private static int testDistance = 400000;
        private static int testFlightDuration = 400;
        private static int testKmPrice = 120;

        private static int changedArlineId = 2;
        private static int changedFromId = 2;
        private static int changedDestinationId = 3;

        private static int changedDistance = 200000;
        private static int changedFlightDuration = 200;
        private static int changedKmPrice = 60;

        private static FlightsController flightsController = new FlightsController();


        [TestMethod()]
        public void T00001_PostTest()
        {
            FlightInputViewModel flight = new FlightInputViewModel(testArlineId, testFromId, testDestinationId, testDistance, testFlightDuration, testKmPrice);
            
            flightsController.Post(flight);
        }

        [TestMethod()]
        public void T00002_GetListTest()
        {
            string json = flightsController.Get();
            List<FlightOutputViewModel>? list = JsonSerializer.Deserialize<List<FlightOutputViewModel>>(json);

            Assert.IsNotNull(list);

            FlightOutputViewModel? flight = list.SingleOrDefault(x => x.Airline.Id == testArlineId && x.From.Id == testFromId 
                                               && x.Destination.Id == testDestinationId && x.Distance == testDistance
                                               && x.FlightDuration == testFlightDuration && x.KmPrice == testKmPrice);

            Assert.IsNotNull(flight);

            Assert.IsTrue(flight.Id != 0);

            testId = flight.Id;
        }

        [TestMethod()]
        public void T00003_GetItemTest()
        {
            string? json = flightsController.Get(testId);

            Assert.IsNotNull(json);

            Flight? flight = Flight.FromJson(json);

            Assert.IsNotNull(flight);

            Assert.IsTrue(flight.Id == testId);
            Assert.IsTrue(flight.AirlineId == testArlineId);
            Assert.IsTrue(flight.FromId == testFromId);
            Assert.IsTrue(flight.DestinationId == testDestinationId);
            Assert.IsTrue(flight.Distance == testDistance);
            Assert.IsTrue(flight.FlightDuration == testFlightDuration);
            Assert.IsTrue(flight.KmPrice == testKmPrice);
        }

        [TestMethod()]
        public void T00004_PutTest()
        {
            FlightInputViewModel changedFlight = new FlightInputViewModel(changedArlineId, changedFromId, changedDestinationId, changedDistance, changedFlightDuration, changedKmPrice);

            flightsController.Put(testId, changedFlight);

            string? json = flightsController.Get(testId);

            Assert.IsNotNull(json);

            Flight? newFlight = Flight.FromJson(json);

            Assert.IsTrue(newFlight.Airline.Id == testArlineId);
            Assert.IsTrue(newFlight.From.Id == testFromId);
            Assert.IsTrue(newFlight.Destination.Id == testDestinationId);
            Assert.IsTrue(newFlight.Distance == testDistance);
            Assert.IsTrue(newFlight.FlightDuration == testFlightDuration);
            Assert.IsTrue(newFlight.KmPrice == testKmPrice);

        }

        [TestMethod()]
        public void T00005_DeleteTest()
        {
            flightsController.Delete(testId);

            string? deletedFlightJson = flightsController.Get(testId);

            Assert.IsNull(deletedFlightJson);
        }
    }
}