using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PomeranianTransfermarkt.Entities;

namespace PomeranianTransfermarkt.Controllers
{
    public class TrainersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TrainersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Trainers
        public async Task<IActionResult> Index()
        {
              return _context.Trainers != null ? 
                          View(await _context.Trainers.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Trainers'  is null.");
        }

        // GET: Trainers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Trainers == null)
            {
                return NotFound();
            }

            var trainers = await _context.Trainers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trainers == null)
            {
                return NotFound();
            }

            return View(trainers);
        }

        // GET: Trainers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Trainers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Surname,Age,Nationality")] Trainers trainers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trainers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(trainers);
        }

        // GET: Trainers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Trainers == null)
            {
                return NotFound();
            }

            var trainers = await _context.Trainers.FindAsync(id);
            if (trainers == null)
            {
                return NotFound();
            }
            return View(trainers);
        }

        // POST: Trainers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Surname,Age,Nationality")] Trainers trainers)
        {
            if (id != trainers.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trainers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrainersExists(trainers.Id))
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
            return View(trainers);
        }

        // GET: Trainers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Trainers == null)
            {
                return NotFound();
            }

            var trainers = await _context.Trainers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trainers == null)
            {
                return NotFound();
            }

            return View(trainers);
        }

        // POST: Trainers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Trainers == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Trainers'  is null.");
            }
            var trainers = await _context.Trainers.FindAsync(id);
            if (trainers != null)
            {
                _context.Trainers.Remove(trainers);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrainersExists(int id)
        {
          return (_context.Trainers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
