/// <summary>
/// 
/// This code is to manipulate the Spots model to be presented on Views
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
    public class SpotsController : Controller
    {
        private readonly SensorContext _context;

        public SpotsController(SensorContext context)
        {
            _context = context;
        }

        // GET: Spots
        public async Task<IActionResult> Index()
        {
              return _context.Spots != null ? 
                          View(await _context.Spots.ToListAsync()) :
                          Problem("Entity set 'SensorContext.Spots'  is null.");
        }

        // GET: Spots/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Spots == null)
            {
                return NotFound();
            }

            var spot = await _context.Spots
                .FirstOrDefaultAsync(m => m.Id == id);
            if (spot == null)
            {
                return NotFound();
            }

            return View(spot);
        }

        // GET: Spots/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Spots/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<SpotDTO>> Create([Bind("Id,Name,Lat,Long,A,B,R2,Sensor_Id")] SpotDTO spotDTO)
        {
            if (ModelState.IsValid)
            {
                var spot = new Spot()
                {
                    Name = spotDTO.Name,
                    Lat = spotDTO.Lat,
                    Long = spotDTO.Long,
                    A = spotDTO.A,
                    B = spotDTO.B,
                    R2 = spotDTO.R2,
                    Sensor_Id = spotDTO.Sensor_Id
                };
                _context.Add(spot);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(spotDTO);
        }

        // GET: Spots/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Spots == null)
            {
                return NotFound();
            }

            var spot = await _context.Spots.FindAsync(id);
            if (spot == null)
            {
                return NotFound();
            }
            return View(spot);
        }

        // POST: Spots/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Lat,Long,A,B,R2,Sensor_Id")] Spot spot)
        {
            if (id != spot.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(spot);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpotExists(spot.Id))
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
            return View(spot);
        }

        // GET: Spots/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Spots == null)
            {
                return NotFound();
            }

            var spot = await _context.Spots
                .FirstOrDefaultAsync(m => m.Id == id);
            if (spot == null)
            {
                return NotFound();
            }

            return View(spot);
        }

        // POST: Spots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Spots == null)
            {
                return Problem("Entity set 'SensorContext.Spots'  is null.");
            }
            var spot = await _context.Spots.FindAsync(id);
            if (spot != null)
            {
                _context.Spots.Remove(spot);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpotExists(int id)
        {
          return (_context.Spots?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
