﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Yogagym.Models;

namespace Yogagym.Controllers
{
    public class MembersController : Controller
    {
        private readonly ModelContext _context;

        private readonly IWebHostEnvironment _webHostEnvironment;

        public MembersController(ModelContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Subscribe()
        {
            return View();
        }
        public IActionResult Subscribe(string Cardnumber,DateTime Expirydate, string Cvv)
        {
            var id = HttpContext.Session.GetInt32("MemberId");
            Creditcarddetail creditcarddetail = new Creditcarddetail();
            creditcarddetail.Memberid = Convert.ToDecimal(id);
            creditcarddetail.Cardnumber = Cardnumber;
            creditcarddetail.Expirydate= Expirydate;
            creditcarddetail.Cvv= Cvv;
            _context.SaveChanges();

            if (creditcarddetail.Availablebalance > 0)
            {
                Payment payment = new Payment();
                payment.Subscriptionid = creditcarddetail.Cardid;
                payment.Amount = 268;
                payment.Paymentdate = DateTime.Now;
                payment.Cardid = creditcarddetail.Cardid;
                _context.SaveChanges();

            }
            return View(creditcarddetail);
        }
        // GET: Members
        public async Task<IActionResult> Index()
        {
              return _context.Members != null ? 
                          View(await _context.Members.ToListAsync()) :
                          Problem("Entity set 'ModelContext.Members'  is null.");
        }

        // GET: Members/Details/5
        public async Task<IActionResult> Details()
        {
            var id = Convert.ToDecimal( HttpContext.Session.GetInt32("MemberId"));
           
            if (id == null || _context.Members == null)
            {
                return NotFound();
            }

            var member = await _context.Members
                .FirstOrDefaultAsync(m => m.Memberid == id);
            if (member == null)
            {
                return NotFound();
            }

            return View(member);
        }



        // GET: Members/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Members/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Memberid,Fname,Lname,ImageFile,Email")] Member member)
        {
            if (ModelState.IsValid)
            {
                if (member.ImageFile != null)
                {
                    string wwwRootPath = _webHostEnvironment.WebRootPath;
                    string fileName = Guid.NewGuid().ToString() + "_" + member.ImageFile.FileName;
                    string path = Path.Combine(wwwRootPath + "/Images/", fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await member.ImageFile.CopyToAsync(fileStream);
                    }
                    member.Imagepath = fileName;
                }
                _context.Add(member);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(member);
        }

        // GET: Members/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null || _context.Members == null)
            {
                return NotFound();
            }

            var member = await _context.Members.FindAsync(id);
            if (member == null)
            {
                return NotFound();
            }
            return View(member);
        }

        // POST: Members/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Memberid,Fname,Lname,ImageFile,Email")] Member member)
        {
            if (id != member.Memberid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (member.ImageFile != null)
                    {
                        string wwwRootPath = _webHostEnvironment.WebRootPath;
                        string fileName = Guid.NewGuid().ToString() + "_" + member.ImageFile.FileName;
                        string path = Path.Combine(wwwRootPath + "/Images/", fileName);
                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            await member.ImageFile.CopyToAsync(fileStream);
                        }
                        member.Imagepath = fileName;
                    }
                    _context.Update(member);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MemberExists(member.Memberid))
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
            return View(member);
        }

        // GET: Members/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
           
            if (id == null || _context.Members == null)
            {
                return NotFound();
            }

            var member = await _context.Members
                .FirstOrDefaultAsync(m => m.Memberid == id);
            if (member == null)
            {
                return NotFound();
            }

            return View(member);
        }

        // POST: Members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            if (_context.Members == null)
            {
                return Problem("Entity set 'ModelContext.Members'  is null.");
            }
            var member = await _context.Members.FindAsync(id);
            if (member != null)
            {
                _context.Members.Remove(member);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MemberExists(decimal id)
        {
          return (_context.Members?.Any(e => e.Memberid == id)).GetValueOrDefault();
        }
    }
}
