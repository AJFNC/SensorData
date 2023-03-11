using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SensorData.Models;

namespace SensorData.Controllers
{
    public class SensorController : Controller
    {

        private readonly SensorContext _context;
        
        public SensorController(SensorContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        // GET: Sensors
        public async Task<IActionResult> Calibration()
        {
            return _context.Sensors != null ?
                          View(await _context.Sensors.ToListAsync()) :
                          Problem("Entity set 'SensorContext.Sensors'  is null.");
        }

        //public IActionResult Calibration()
        //{
        //    return View();
        //}

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
