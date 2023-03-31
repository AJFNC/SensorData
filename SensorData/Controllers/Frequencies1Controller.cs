using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SensorData.Models;

namespace SensorData.Controllers
{
    public class Frequencies1Controller : Controller
    {
        private readonly SensorContext _context;

        public Frequencies1Controller(SensorContext context)
        {
            _context = context;
        }

        // GET: Frequencies1
        public async Task<IActionResult> Index()
        {
              return _context.Frequencies != null ? 
                          View(await _context.Frequencies.ToListAsync()) :
                          Problem("Entity set 'SensorContext.Frequencies'  is null.");
        }

        // GET: Frequencies1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Frequencies == null)
            {
                return NotFound();
            }

            var frequency = await _context.Frequencies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (frequency == null)
            {
                return NotFound();
            }

            return View(frequency);
        }

        // GET: Frequencies1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Frequencies1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Sensor_Id,Frl1,Frl2,Frl3,ReadDateTime")] Frequency frequency)
        {
            if (ModelState.IsValid)
            {
                _context.Add(frequency);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(frequency);
        }

        // GET: Frequencies1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Frequencies == null)
            {
                return NotFound();
            }

            var frequency = await _context.Frequencies.FindAsync(id);
            if (frequency == null)
            {
                return NotFound();
            }
            return View(frequency);
        }

        // POST: Frequencies1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Sensor_Id,Frl1,Frl2,Frl3,ReadDateTime")] Frequency frequency)
        {
            if (id != frequency.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(frequency);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FrequencyExists(frequency.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(frequency);
        }

        // GET: Frequencies1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Frequencies == null)
            {
                return NotFound();
            }

            var frequency = await _context.Frequencies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (frequency == null)
            {
                return NotFound();
            }

            return View(frequency);
        }

        // POST: Frequencies1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Frequencies == null)
            {
                return Problem("Entity set 'SensorContext.Frequencies'  is null.");
            }
            var frequency = await _context.Frequencies.FindAsync(id);
            if (frequency != null)
            {
                _context.Frequencies.Remove(frequency);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FrequencyExists(int id)
        {
          return (_context.Frequencies?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
