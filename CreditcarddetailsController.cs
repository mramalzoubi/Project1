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
    public class CreditcarddetailsController : Controller
    {
        private readonly ModelContext _context;

        public CreditcarddetailsController(ModelContext context)
        {
            _context = context;
        }

        // GET: Creditcarddetails
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.Creditcarddetails.Include(c => c.Member);
            return View(await modelContext.ToListAsync());
        }

        // GET: Creditcarddetails/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null || _context.Creditcarddetails == null)
            {
                return NotFound();
            }

            var creditcarddetail = await _context.Creditcarddetails
                .Include(c => c.Member)
                .FirstOrDefaultAsync(m => m.Cardid == id);
            if (creditcarddetail == null)
            {
                return NotFound();
            }

            return View(creditcarddetail);
        }

        // GET: Creditcarddetails/Create
        public IActionResult Create()
        {
            ViewData["Memberid"] = new SelectList(_context.Members, "Memberid", "Memberid");
            return View();
        }

        // POST: Creditcarddetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Cardid,Memberid,Cardnumber,Expirydate,Cvv,Availablebalance")] Creditcarddetail creditcarddetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(creditcarddetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Memberid"] = new SelectList(_context.Members, "Memberid", "Memberid", creditcarddetail.Memberid);
            return View(creditcarddetail);
        }

        // GET: Creditcarddetails/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null || _context.Creditcarddetails == null)
            {
                return NotFound();
            }

            var creditcarddetail = await _context.Creditcarddetails.FindAsync(id);
            if (creditcarddetail == null)
            {
                return NotFound();
            }
            ViewData["Memberid"] = new SelectList(_context.Members, "Memberid", "Memberid", creditcarddetail.Memberid);
            return View(creditcarddetail);
        }

        // POST: Creditcarddetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Cardid,Memberid,Cardnumber,Expirydate,Cvv,Availablebalance")] Creditcarddetail creditcarddetail)
        {
            if (id != creditcarddetail.Cardid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(creditcarddetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CreditcarddetailExists(creditcarddetail.Cardid))
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
            ViewData["Memberid"] = new SelectList(_context.Members, "Memberid", "Memberid", creditcarddetail.Memberid);
            return View(creditcarddetail);
        }

        // GET: Creditcarddetails/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null || _context.Creditcarddetails == null)
            {
                return NotFound();
            }

            var creditcarddetail = await _context.Creditcarddetails
                .Include(c => c.Member)
                .FirstOrDefaultAsync(m => m.Cardid == id);
            if (creditcarddetail == null)
            {
                return NotFound();
            }

            return View(creditcarddetail);
        }

        // POST: Creditcarddetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            if (_context.Creditcarddetails == null)
            {
                return Problem("Entity set 'ModelContext.Creditcarddetails'  is null.");
            }
            var creditcarddetail = await _context.Creditcarddetails.FindAsync(id);
            if (creditcarddetail != null)
            {
                _context.Creditcarddetails.Remove(creditcarddetail);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CreditcarddetailExists(decimal id)
        {
          return (_context.Creditcarddetails?.Any(e => e.Cardid == id)).GetValueOrDefault();
        }
    }
}
