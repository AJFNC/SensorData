/// <summary>
/// 
/// This code is to manipulate the Frequencies model from Bananas End Device to be presented as moisture on Views
/// 
/// Author: Alexandre Cavalcanti
/// Date: 05/31/2023
/// 
/// </summary>

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
    public class Frequencies2Controller : Controller
    {
        private readonly SensorContext _context;

        public Frequencies2Controller(SensorContext context)
        {
            _context = context;
        }

        // GET: Frequencies2
        public async Task<IActionResult> Index()
        {

            return View(await FrequenciesList());

        }

        //GET: Frequencies/ViewTable

        public async Task<IActionResult> ViewTable()
        {

            var frequencies = await FrequenciesList();


            return View(frequencies);
        }


        // GET: Frequencies2/Details/5
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

        // GET: Frequencies2/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Frequencies2/Create
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

        // GET: Frequencies2/Edit/5
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

        // POST: Frequencies2/Edit/5
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

        // GET: Frequencies2/Delete/5
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

        // POST: Frequencies2/Delete/5
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

        private async Task<List<Frequency>> FrequenciesList()
        {

            if (_context.Frequencies == null)
            {
                return null;
            }
            if (_context.Spots == null)
            {
                return null;
            }
            var spot = await _context.Spots.ToListAsync();      //Para ser usado na conversão de Frel para Umid%
            var frequency = await _context.Frequencies
                .ToListAsync();

            if (frequency == null)
            {
                return null;
            }
            if (spot == null)
            {
                return null;
            }
            ///<summary>
            ///
            /// Convert frequencies into percent of soil moisture
            /// 
            /// </summary>
            foreach (Frequency item in frequency)
            {

                foreach (Spot sitem in spot.Where(s => s.Sensor_Id == item.Sensor_Id).Where(t => t.Name == "Frl3"))
                {
                    item.Frl3 = (item.Frl3 * sitem.A) + sitem.B;
                }

                foreach (Spot sitem in spot.Where(s => s.Sensor_Id == item.Sensor_Id).Where(t => t.Name == "Frl2"))
                {
                    item.Frl2 = (item.Frl2 * sitem.A) + sitem.B;
                }

                foreach (Spot sitem in spot.Where(s => s.Sensor_Id == item.Sensor_Id).Where(t => t.Name == "Frl1"))
                {
                    item.Frl1 = (item.Frl1 * sitem.A) + sitem.B;
                }


            }

            return frequency;


        }

    }
}
