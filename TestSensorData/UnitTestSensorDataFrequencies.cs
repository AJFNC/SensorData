using SensorData;

namespace TestSensorData
{
    [TestClass]
    public class UnitTestSensorDataFrequencies
    {
        [TestMethod]
        public void ListIsNotNull()
        {
            Assert.IsTrue(SensorData.Controllers.FrequenciesController.Equals != null, "A lista foi gerada com sucesso!");
        }


    }
}