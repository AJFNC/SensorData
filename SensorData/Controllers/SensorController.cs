using Microsoft.AspNetCore.Mvc;

namespace SensorData.Controllers
{
    public class SensorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Calibration()
        {
            return View();
        }

        public IActionResult Product()
        {
            return View();
        }

        public IActionResult Customer()
        {
            return View();
        }

        public IActionResult Report()
        {
            return View();
        }

        public IActionResult Map()
        {
            return View();
        }
    }
}
