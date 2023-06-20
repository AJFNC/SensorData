using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGeneration.Design;
using SensorData.Models;
using System.Net;
using System.Net.Http.Json;
using Xunit;

namespace XunitTestSensor
{
    public class UnitTestSensorFrequencies
    {


        [Fact]
        public async Task Get_Return_All_Frequencies()
        {
            // Arrange
            await using var application = new FrequencyApiApplication();
            await FrequencyMockData.CreateFrequencies(application, true);
            var url = "/api/Frequencies";

            // Act
            var client = application.CreateClient();

            var result = await client.GetAsync(url);
            var frequencies = await client.GetFromJsonAsync<List<Frequency>>(url);

            //// Assert
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
            Assert.NotNull(frequencies);
            Assert.True(frequencies.Count() == 2);

        }
        //[Theory]
        //[InlineData("/")]

    }
}