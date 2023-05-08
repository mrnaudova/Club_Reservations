using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Club_Reservations.Data;
using Club_Reservations.Models;

namespace Club_Reservations.Controllers
{
    public class StatisticsModulesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StatisticsModulesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StatisticsModules
        public async Task<IActionResult> Index()
        {
              return _context.StatisticsModule != null ? 
                          View(await _context.StatisticsModule.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.StatisticsModule'  is null.");
        }

        // GET: StatisticsModules/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.StatisticsModule == null)
            {
                return NotFound();
            }

            var statisticsModule = await _context.StatisticsModule
                .FirstOrDefaultAsync(m => m.Id == id);
            if (statisticsModule == null)
            {
                return NotFound();
            }

            return View(statisticsModule);
        }

        // GET: StatisticsModules/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StatisticsModules/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NumberOfTables,NumberOfCustomers,NumberOfPastReservations,NumberOfUpcomingReservations")] StatisticsModule statisticsModule)
        {
            if (ModelState.IsValid)
            {
                _context.Add(statisticsModule);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(statisticsModule);
        }

        // GET: StatisticsModules/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.StatisticsModule == null)
            {
                return NotFound();
            }

            var statisticsModule = await _context.StatisticsModule.FindAsync(id);
            if (statisticsModule == null)
            {
                return NotFound();
            }
            return View(statisticsModule);
        }

        // POST: StatisticsModules/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NumberOfTables,NumberOfCustomers,NumberOfPastReservations,NumberOfUpcomingReservations")] StatisticsModule statisticsModule)
        {
            if (id != statisticsModule.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(statisticsModule);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StatisticsModuleExists(statisticsModule.Id))
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
            return View(statisticsModule);
        }

        // GET: StatisticsModules/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.StatisticsModule == null)
            {
                return NotFound();
            }

            var statisticsModule = await _context.StatisticsModule
                .FirstOrDefaultAsync(m => m.Id == id);
            if (statisticsModule == null)
            {
                return NotFound();
            }

            return View(statisticsModule);
        }

        // POST: StatisticsModules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.StatisticsModule == null)
            {
                return Problem("Entity set 'ApplicationDbContext.StatisticsModule'  is null.");
            }
            var statisticsModule = await _context.StatisticsModule.FindAsync(id);
            if (statisticsModule != null)
            {
                _context.StatisticsModule.Remove(statisticsModule);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StatisticsModuleExists(int id)
        {
          return (_context.StatisticsModule?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
