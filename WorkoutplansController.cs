using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Yogagym.Models;

namespace Yogagym.Controllers
{
    public class WorkoutplansController : Controller
    {
        private readonly ModelContext _context;

        private readonly IWebHostEnvironment _webHostEnvironment;

        public WorkoutplansController(ModelContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        // GET: Workoutplans
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.Workoutplans.Include(w => w.Trainer);
            return View(await modelContext.ToListAsync());
        }

        // GET: Workoutplans/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null || _context.Workoutplans == null)
            {
                return NotFound();
            }

            var workoutplan = await _context.Workoutplans
                .Include(w => w.Trainer)
                .FirstOrDefaultAsync(m => m.Planid == id);
            if (workoutplan == null)
            {
                return NotFound();
            }

            return View(workoutplan);
        }

        // GET: Workoutplans/Create
        public IActionResult Create()
        {
            ViewData["Trainerid"] = new SelectList(_context.Trainers, "Trainerid", "Trainerid");
            return View();
        }

        // POST: Workoutplans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Planid,Planname,Duration,Trainerid,Price,ImageFile")] Workoutplan workoutplan)
        {
            if (workoutplan.ImageFile != null)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                string fileName = Guid.NewGuid().ToString() + "_" + workoutplan.ImageFile.FileName;
                string path = Path.Combine(wwwRootPath + "/Images/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await workoutplan.ImageFile.CopyToAsync(fileStream);
                }

                workoutplan.Imagepath = fileName;

            }

            _context.Add(workoutplan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));


            ViewData["Trainerid"] = new SelectList(_context.Trainers, "Trainerid", "Trainerid", workoutplan.Trainerid);
            return View(workoutplan);
        }
        // GET: Workoutplans/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null || _context.Workoutplans == null)
            {
                return NotFound();
            }

            var workoutplan = await _context.Workoutplans.FindAsync(id);
            if (workoutplan == null)
            {
                return NotFound();
            }
            ViewData["Trainerid"] = new SelectList(_context.Trainers, "Trainerid", "Trainerid", workoutplan.Trainerid);
            return View(workoutplan);
        }

        // POST: Workoutplans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Planid,Planname,Duration,Trainerid,Price,Imagepath")] Workoutplan workoutplan)
        {
            _context.Update(workoutplan);
            await _context.SaveChangesAsync();
            /*
            if (id != workoutplan.Planid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkoutplanExists(workoutplan.Planid))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }*/

            ViewData["Trainerid"] = new SelectList(_context.Trainers, "Trainerid", "Trainerid", workoutplan.Trainerid);
            return View(workoutplan);
        }
        // GET: Workoutplans/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null || _context.Workoutplans == null)
            {
                return NotFound();
            }

            var workoutplan = await _context.Workoutplans
                .Include(w => w.Trainer)
                .FirstOrDefaultAsync(m => m.Planid == id);
            if (workoutplan == null)
            {
                return NotFound();
            }

            return View(workoutplan);
        }

        // POST: Workoutplans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            if (_context.Workoutplans == null)
            {
                return Problem("Entity set 'ModelContext.Workoutplans'  is null.");
            }
            var workoutplan = await _context.Workoutplans.FindAsync(id);
            if (workoutplan != null)
            {
                _context.Workoutplans.Remove(workoutplan);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkoutplanExists(decimal id)
        {
          return (_context.Workoutplans?.Any(e => e.Planid == id)).GetValueOrDefault();
        }
    }
}
