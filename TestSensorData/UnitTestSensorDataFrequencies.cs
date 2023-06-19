using SensorData;
using Sensor;

namespace TestSensorData
{
    [TestClass]
    public class UnitTestSensorDataFrequencies
    {
        [TestMethod]
        public void SensorDataControllerIsNotNull()
        {
            Assert.IsTrue(SensorData.Controllers.FrequenciesController.Equals != null, "O Controller do MVC não é nulo!");
        }
        [TestMethod]
        public void ContextIsNotNull()
        {
            Assert.IsTrue(SensorData.Models.SensorContext.Equals != null, "O contexto não é nulo!");
        }
        [TestMethod]
        public void SensorControllerIsNotNull()
        {
            Assert.IsTrue(Sensor.Controllers.FrequenciesController.Equals != null, "O Controller da API não é nulo!");
        }

    }
}