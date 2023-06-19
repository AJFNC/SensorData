using Microsoft.Extensions.DependencyInjection;
using SensorData.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XunitTestSensor
{
    internal class FrequencyMockData
    {
        public static async Task CreateFrequencies(FrequencyApiApplication application, bool criar)
        {
            using(var scope = application.Services.CreateScope())
            {
                var provider = scope.ServiceProvider;
                using(var frequencyDbContext = provider.GetRequiredService<SensorContext>())
                {
                    await frequencyDbContext.Database.EnsureCreatedAsync();
                    
                    if (criar)
                    {
                        await frequencyDbContext.Frequencies.AddAsync(new Frequency{
                            Id = 1,
                            Sensor_Id = 1,
                            Frl1 = 0.111F,
                            Frl2 = 0.222F,
                            Frl3 = 0.333F,
                            ReadDateTime = DateTime.Now
                        });
                        await frequencyDbContext.Frequencies.AddAsync(new Frequency
                        {
                            Id = 2,
                            Sensor_Id = 1,
                            Frl1 = 0.444F,
                            Frl2 = 0.555F,
                            Frl3 = 0.666F,
                            ReadDateTime = DateTime.Now
                        });
                        await frequencyDbContext.SaveChangesAsync();
                    }

                }
            }
        }

    }
}
