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
            await FrequencyMockData.CreateFrequencies(application, false);
            var url = "/api/Frequencies";

            // Act
            var client = application.CreateClient();
            var frequencies = await client.GetFromJsonAsync<List<Frequency>>(url);

            // Assert
            Assert.NotNull(frequencies);
            Assert.True(frequencies.Count() == 0);

        }

    }
}