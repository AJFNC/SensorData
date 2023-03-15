using Microsoft.AspNetCore.Mvc;
using SensorData.Models;
using System.Web.Http;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace SensorData.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FrequenciesController : ControllerBase
    {

        private readonly SensorContext _context;

        public FrequenciesController(SensorContext context)
        {
            _context = context;
        }

        public IActionResult GetAllFrequencies()
        {
            IList<Frequency> frequencies = null;

            using (var contexto = _context)
            {
                frequencies = contexto.Frequencies.ToList();
            }
            if(frequencies.Count == 0)
            {
                return NotFound();
            }
                return Ok(frequencies);
        }

    }
}
