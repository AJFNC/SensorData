using Microsoft.AspNetCore.Mvc;
using SensorData.Models;

namespace SensorData.Controllers
{
    public class FrequenciesMVCController1 : Controller
    {
        
        public IActionResult Index()
        {
            IEnumerable<Frequency> frequencies = null;

            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:5000/Frequencies");
                //HTTP GET
                var responseTask = client.GetAsync("frequencies");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Frequency>>();
                    readTask.Wait();

                    frequencies = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    frequencies = Enumerable.Empty<Frequency>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }


            return View();
        }
    }
}
