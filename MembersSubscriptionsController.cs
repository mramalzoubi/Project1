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
    public class MembersSubscriptionsController : Controller
    {
        private readonly ModelContext _context;

        public MembersSubscriptionsController(ModelContext context)
        {
            _context = context;
        }

        // GET: MembersSubscriptions
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.MembersSubscriptions.Include(m => m.Member).Include(m => m.Plan).Include(m => m.Subscription);
            return View(await modelContext.ToListAsync());
        }

        // GET: MembersSubscriptions/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null || _context.MembersSubscriptions == null)
            {
                return NotFound();
            }

            var membersSubscription = await _context.MembersSubscriptions
                .Include(m => m.Member)
                .Include(m => m.Plan)
                .Include(m => m.Subscription)
                .FirstOrDefaultAsync(m => m.MembersSubscriptionsid == id);
            if (membersSubscription == null)
            {
                return NotFound();
            }

            return View(membersSubscription);
        }

        // GET: MembersSubscriptions/Create
        public IActionResult Create()
        {
            ViewData["Memberid"] = new SelectList(_context.Members, "Memberid", "Memberid");
            ViewData["Planid"] = new SelectList(_context.Workoutplans, "Planid", "Planid");
            ViewData["Subscriptionid"] = new SelectList(_context.Subscriptions, "Subscriptionid", "Subscriptionid");
            return View();
        }

        // POST: MembersSubscriptions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MembersSubscriptionsid,Planid,Subscriptionid,Memberid")] MembersSubscription membersSubscription)
        {
            if (ModelState.IsValid)
            {
                _context.Add(membersSubscription);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Memberid"] = new SelectList(_context.Members, "Memberid", "Memberid", membersSubscription.Memberid);
            ViewData["Planid"] = new SelectList(_context.Workoutplans, "Planid", "Planid", membersSubscription.Planid);
            ViewData["Subscriptionid"] = new SelectList(_context.Subscriptions, "Subscriptionid", "Subscriptionid", membersSubscription.Subscriptionid);
            return View(membersSubscription);
        }

        // GET: MembersSubscriptions/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null || _context.MembersSubscriptions == null)
            {
                return NotFound();
            }

            var membersSubscription = await _context.MembersSubscriptions.FindAsync(id);
            if (membersSubscription == null)
            {
                return NotFound();
            }
            ViewData["Memberid"] = new SelectList(_context.Members, "Memberid", "Memberid", membersSubscription.Memberid);
            ViewData["Planid"] = new SelectList(_context.Workoutplans, "Planid", "Planid", membersSubscription.Planid);
            ViewData["Subscriptionid"] = new SelectList(_context.Subscriptions, "Subscriptionid", "Subscriptionid", membersSubscription.Subscriptionid);
            return View(membersSubscription);
        }

        // POST: MembersSubscriptions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("MembersSubscriptionsid,Planid,Subscriptionid,Memberid")] MembersSubscription membersSubscription)
        {
            if (id != membersSubscription.MembersSubscriptionsid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(membersSubscription);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MembersSubscriptionExists(membersSubscription.MembersSubscriptionsid))
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
            ViewData["Memberid"] = new SelectList(_context.Members, "Memberid", "Memberid", membersSubscription.Memberid);
            ViewData["Planid"] = new SelectList(_context.Workoutplans, "Planid", "Planid", membersSubscription.Planid);
            ViewData["Subscriptionid"] = new SelectList(_context.Subscriptions, "Subscriptionid", "Subscriptionid", membersSubscription.Subscriptionid);
            return View(membersSubscription);
        }

        // GET: MembersSubscriptions/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null || _context.MembersSubscriptions == null)
            {
                return NotFound();
            }

            var membersSubscription = await _context.MembersSubscriptions
                .Include(m => m.Member)
                .Include(m => m.Plan)
                .Include(m => m.Subscription)
                .FirstOrDefaultAsync(m => m.MembersSubscriptionsid == id);
            if (membersSubscription == null)
            {
                return NotFound();
            }

            return View(membersSubscription);
        }

        // POST: MembersSubscriptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            if (_context.MembersSubscriptions == null)
            {
                return Problem("Entity set 'ModelContext.MembersSubscriptions'  is null.");
            }
            var membersSubscription = await _context.MembersSubscriptions.FindAsync(id);
            if (membersSubscription != null)
            {
                _context.MembersSubscriptions.Remove(membersSubscription);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MembersSubscriptionExists(decimal id)
        {
          return (_context.MembersSubscriptions?.Any(e => e.MembersSubscriptionsid == id)).GetValueOrDefault();
        }
    }
}
