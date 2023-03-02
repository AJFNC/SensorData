using Microsoft.AspNetCore.Mvc;

namespace SensorData.Controllers
{
    public class SensorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
