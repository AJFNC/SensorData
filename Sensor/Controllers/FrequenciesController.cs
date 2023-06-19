using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SensorData.Models;

namespace Sensor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FrequenciesController : ControllerBase
    {
        private readonly SensorContext _context;

        public FrequenciesController(SensorContext context)
        {
            _context = context;
        }

        // GET: api/Frequencies
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<Frequency>>> GetFrequencies()
        public async Task<ActionResult<IEnumerable<Frequency>>> GetFrequencies()
        {
            if (_context.Frequencies == null)
            {
                return NotFound();
            }
            return await _context.Frequencies.ToListAsync();
        }

        // GET: api/Frequencies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Frequency>> GetFrequency(int id)
        {
            if (_context.Frequencies == null)
            {
                return NotFound();
            }
            var frequency = await _context.Frequencies.FindAsync(id);

            if (frequency == null)
            {
                return NotFound();
            }

            return frequency;
        }

        // GET: api/Frequencies/sensor/3
        [HttpGet("sensor/{sensor_id}")]
        public async Task<ActionResult<IEnumerable<Frequency>>> GetFrequenciesBySensorId(int sensor_id)
        {
            if (_context.Frequencies == null)
            {
                return NotFound();
            }
            return await _context.Frequencies.Where(p => p.Sensor_Id == sensor_id).ToListAsync();
        }

        // GET: api/Frequencies/sensor/time/24
        [HttpGet("sensor/{sensor_id}/time/{time:int}")]
        public async Task<ActionResult<IEnumerable<Frequency>>> GetFrequenciesBySensorId24H(int sensor_id, int time)
        {
            if (_context.Frequencies == null)
            {
                return NotFound();
            }
            var frequencies = await _context.Frequencies.Where(p => p.Sensor_Id == sensor_id).ToListAsync();

            DateTime dateTimeNow = DateTime.Now;

            var freqTimeHours = frequencies.Where(t => t.ReadDateTime >= dateTimeNow.AddHours(-time)).ToList();

            return freqTimeHours;
        }

        // PUT: api/Frequencies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFrequency(int id, Frequency frequency)
        {
            if (id != frequency.Id)
            {
                return BadRequest();
            }

            _context.Entry(frequency).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FrequencyExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Frequencies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FrequencyDTO>> PostFrequency(FrequencyDTO frequencyDTO)
        {
            if (_context.Frequencies == null)
            {
                return Problem("Entity set 'SensorContext.Frequencies'  is null.");
            }

            var frequency = new Frequency()
            {
                Sensor_Id = frequencyDTO.Sensor_Id,
                Frl1 = frequencyDTO.Frl1,
                Frl2 = frequencyDTO.Frl2,
                Frl3 = frequencyDTO.Frl3
            };


            _context.Frequencies.Add(frequency);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetFrequency", new { id = frequency.Id }, frequency);
            return CreatedAtAction(nameof(GetFrequency), new { id = frequency.Id }, frequencyToDTO(frequency));
        }

        private FrequencyDTO frequencyToDTO(Frequency frequency) => new FrequencyDTO
        {
            Sensor_Id = frequency.Sensor_Id,
            Frl1 = frequency.Frl1,
            Frl2 = frequency.Frl2,
            Frl3 = frequency.Frl3
        };

        // DELETE: api/Frequencies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFrequency(int id)
        {
            if (_context.Frequencies == null)
            {
                return NotFound();
            }
            var frequency = await _context.Frequencies.FindAsync(id);
            if (frequency == null)
            {
                return NotFound();
            }

            _context.Frequencies.Remove(frequency);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FrequencyExists(int id)
        {
            return (_context.Frequencies?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
