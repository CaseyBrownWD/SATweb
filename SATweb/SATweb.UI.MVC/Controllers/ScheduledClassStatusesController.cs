﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SATweb.DATA.EF.Models;

namespace SATweb.UI.MVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ScheduledClassStatusesController : Controller
    {
        private readonly SATContext _context;

        public ScheduledClassStatusesController(SATContext context)
        {
            _context = context;
        }

        // GET: ScheduledClassStatuses
        public async Task<IActionResult> Index()
        {
              return View(await _context.ScheduledClassStatuses.ToListAsync());
        }

        // GET: ScheduledClassStatuses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ScheduledClassStatuses == null)
            {
                return NotFound();
            }

            var scheduledClassStatus = await _context.ScheduledClassStatuses
                .FirstOrDefaultAsync(m => m.Scsid == id);
            if (scheduledClassStatus == null)
            {
                return NotFound();
            }

            return View(scheduledClassStatus);
        }

        // GET: ScheduledClassStatuses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ScheduledClassStatuses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Scsid,Scsname")] ScheduledClassStatus scheduledClassStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(scheduledClassStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(scheduledClassStatus);
        }

        // GET: ScheduledClassStatuses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ScheduledClassStatuses == null)
            {
                return NotFound();
            }

            var scheduledClassStatus = await _context.ScheduledClassStatuses.FindAsync(id);
            if (scheduledClassStatus == null)
            {
                return NotFound();
            }
            return View(scheduledClassStatus);
        }

        // POST: ScheduledClassStatuses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Scsid,Scsname")] ScheduledClassStatus scheduledClassStatus)
        {
            if (id != scheduledClassStatus.Scsid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(scheduledClassStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ScheduledClassStatusExists(scheduledClassStatus.Scsid))
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
            return View(scheduledClassStatus);
        }

        // GET: ScheduledClassStatuses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ScheduledClassStatuses == null)
            {
                return NotFound();
            }

            var scheduledClassStatus = await _context.ScheduledClassStatuses
                .FirstOrDefaultAsync(m => m.Scsid == id);
            if (scheduledClassStatus == null)
            {
                return NotFound();
            }

            return View(scheduledClassStatus);
        }

        // POST: ScheduledClassStatuses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ScheduledClassStatuses == null)
            {
                return Problem("Entity set 'SATContext.ScheduledClassStatuses'  is null.");
            }
            var scheduledClassStatus = await _context.ScheduledClassStatuses.FindAsync(id);
            if (scheduledClassStatus != null)
            {
                _context.ScheduledClassStatuses.Remove(scheduledClassStatus);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ScheduledClassStatusExists(int id)
        {
          return _context.ScheduledClassStatuses.Any(e => e.Scsid == id);
        }
    }
}
