using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGeneration.Design;
using SensorData.Models;
using System.Net;
using System.Net.Http.Json;
using System.Security.Policy;
using Xunit;

namespace XunitTestSensor
{
    public class UnitTestSensorFrequencies
    {


        [Fact]
        public async Task GET_Return_All_Frequencies()
        {
            // Arrange
            await using var application = new FrequencyApiApplication();
            await FrequencyMockData.CreateFrequencies(application, true);
            var url = "/api/Frequencies";

            // Act
            var client = application.CreateClient();

            var result = await client.GetAsync(url);
            var frequencies = await client.GetFromJsonAsync<List<Frequency>>(url);

            // Assert
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
            Assert.NotNull(frequencies);
            Assert.True(frequencies.Count() == 2);

        }
        //[Theory]
        //[InlineData("/")]

        [Fact]
        public async Task GET_Return_Frequencies_Empty()
        {
            // Arrange
            await using var application = new FrequencyApiApplication();
            await FrequencyMockData.CreateFrequencies(application, false);
            var url = "/api/Frequencies";

            // Act
            var client = application.CreateClient();
            var frequencies = await client.GetFromJsonAsync<List<Frequency>>(url);

            // Assert
            Assert.NotNull(frequencies);
            Assert.True(frequencies.Count() == 0);

        }

        [Fact]
        public async Task POST_Valid_Frequency()
        {
            // Arrange
            await using var application = new FrequencyApiApplication();
            await FrequencyMockData.CreateFrequencies(application, true);
            var url = "/api/Frequencies";

            // Act
            var frequency = new Frequency {
                Id = 999,
                Sensor_Id = 1,
                Frl1 = 0.123F,
                Frl2 = 0.456F,
                Frl3 = 0.789F,
                ReadDateTime = DateTime.Now
            };
            var client = application.CreateClient();
            var result = await client.PostAsJsonAsync(url, frequency);
            var frequencies = await client.GetFromJsonAsync<List<Frequency>>(url);

            // Assert
            Assert.Equal(HttpStatusCode.Created, result.StatusCode);
            Assert.True(frequencies.Count == 3);

        }
        [Fact]
        public async Task DELETE_Frequency()
        {
            // Arrange
            await using var application = new FrequencyApiApplication();
            await FrequencyMockData.CreateFrequencies(application, true);
            var url = "/api/Frequencies";

            // Act
            var client = application.CreateClient();

            var result = await client.DeleteAsync(url + "/2");
            var frequencies = await client.GetFromJsonAsync<List<Frequency>>(url);

            // Assert
            Assert.Equal(HttpStatusCode.NoContent, result.StatusCode);
            Assert.NotNull(frequencies);
            Assert.True(frequencies.Count() == 1);

        }
        [Fact]
        public async Task PUT_Existing_Frequency()
        {
            // Arrange
            await using var application = new FrequencyApiApplication();
            await FrequencyMockData.CreateFrequencies(application, true);
            var url = "/api/Frequencies/1";

            // Act
            var client = application.CreateClient();
            var frequency = new Frequency
            {
                Id = 1,
                Sensor_Id = 1,
                Frl1 = 1.111F,
                Frl2 = 2.222F,
                Frl3 = 3.333F,
                ReadDateTime = DateTime.Now
            };

            var frequency1 = await client.GetFromJsonAsync<Frequency>(url);

            var result = await client.PutAsJsonAsync<Frequency>(url, frequency);
            var alteredFrequency = await client.GetFromJsonAsync<Frequency>(url);

            // Assert
            Assert.Equal(HttpStatusCode.NoContent, result.StatusCode);  //o resultado retornado é 204 - No Content, mas altera o registro com os novos valores
            Assert.NotEqual(frequency1.Frl1, alteredFrequency.Frl1);

        }
        [Fact]
        public async Task PUT_Same_Frequency()
        {
            // Arrange
            await using var application = new FrequencyApiApplication();
            await FrequencyMockData.CreateFrequencies(application, true);
            var url = "/api/Frequencies/1";

            // Act
            var client = application.CreateClient();
            var frequency = new Frequency
            {
                Id = 1,
                Sensor_Id = 1,
                Frl1 = 0.111F,
                Frl2 = 0.222F,
                Frl3 = 0.333F,
                ReadDateTime = DateTime.Now
            };

            var frequency1 = await client.GetFromJsonAsync<Frequency>(url);

            var result = await client.PutAsJsonAsync<Frequency>(url, frequency);
            var alteredFrequency = await client.GetFromJsonAsync<Frequency>(url);

            // Assert
            Assert.Equal(HttpStatusCode.NoContent, result.StatusCode);      //o resultado retornado é 204 - No Content, mas altera o registro com os novos valores
            Assert.Equal(frequency1.Frl1, alteredFrequency.Frl1);

        }
        [Fact]
        public async Task PUT_NotExisting_Frequency()
        {
            // Arrange
            await using var application = new FrequencyApiApplication();
            await FrequencyMockData.CreateFrequencies(application, true);
            var url = "/api/Frequencies/3";

            // Act
            var client = application.CreateClient();
            var frequency = new Frequency
            {
                Id = 3,
                Sensor_Id = 1,
                Frl1 = 0.111F,
                Frl2 = 0.222F,
                Frl3 = 0.333F,
                ReadDateTime = DateTime.Now
            };

            var result = await client.PutAsJsonAsync<Frequency>(url, frequency);

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, result.StatusCode);

        }
    }
}