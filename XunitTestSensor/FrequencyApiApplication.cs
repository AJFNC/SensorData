using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Sensor;
using Sensor.Controllers;
using SensorData.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XunitTestSensor
{
    internal class FrequencyApiApplication : WebApplicationFactory<FrequenciesController>
    {
        protected override IHost CreateHost(IHostBuilder builder)
        {
            var root = new InMemoryDatabaseRoot();
            builder.ConfigureServices(services =>
            {
                services.RemoveAll(typeof(DbContextOptions<SensorContext>));
                services.AddDbContext<SensorContext>(options => options.UseInMemoryDatabase("FrequencyDatabase", root));
            });
            return base.CreateHost(builder);
        }
    }
}
