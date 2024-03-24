#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HrHelper.Data;
using HrHelper.Models;

namespace HrHelper.Controllers
{
    public class ApplicationStatusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ApplicationStatusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ApplicationStatus
        public async Task<IActionResult> Index()
        {
            return View(await _context.ApplicationStatus.ToListAsync());
        }

        // GET: ApplicationStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationStatus = await _context.ApplicationStatus
                .FirstOrDefaultAsync(m => m.ApplicationStatusID == id);
            if (applicationStatus == null)
            {
                return NotFound();
            }

            return View(applicationStatus);
        }

        // GET: ApplicationStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ApplicationStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ApplicationStatusID,ApplicationStatusName")] ApplicationStatus applicationStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(applicationStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(applicationStatus);
        }

        // GET: ApplicationStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationStatus = await _context.ApplicationStatus.FindAsync(id);
            if (applicationStatus == null)
            {
                return NotFound();
            }
            return View(applicationStatus);
        }

        // POST: ApplicationStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ApplicationStatusID,ApplicationStatusName")] ApplicationStatus applicationStatus)
        {
            if (id != applicationStatus.ApplicationStatusID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(applicationStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicationStatusExists(applicationStatus.ApplicationStatusID))
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
            return View(applicationStatus);
        }

        // GET: ApplicationStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var applicationStatus = await _context.ApplicationStatus
                .FirstOrDefaultAsync(m => m.ApplicationStatusID == id);
            if (applicationStatus == null)
            {
                return NotFound();
            }

            return View(applicationStatus);
        }

        // POST: ApplicationStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var applicationStatus = await _context.ApplicationStatus.FindAsync(id);
            _context.ApplicationStatus.Remove(applicationStatus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApplicationStatusExists(int id)
        {
            return _context.ApplicationStatus.Any(e => e.ApplicationStatusID == id);
        }
    }
}
