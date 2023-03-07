using Microsoft.AspNetCore.Mvc;

namespace SensorData.Controllers
{
    public class SignController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
