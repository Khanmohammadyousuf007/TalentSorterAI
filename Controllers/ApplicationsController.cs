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
    public class ApplicationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ApplicationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Applications
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Application.Include(a => a.Candidate).Include(a => a.Post).Include(a => a.Recruitment);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Applications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var application = await _context.Application
                .Include(a => a.Candidate)
                .Include(a => a.Post)
                .Include(a => a.Recruitment)
                .FirstOrDefaultAsync(m => m.ApplicationID == id);
            if (application == null)
            {
                return NotFound();
            }

            return View(application);
        }

        // GET: Applications/Create
        public IActionResult Create()
        {
            ViewData["CandidateID"] = new SelectList(_context.Candidate, "CandidateID", "CandidateName");
            ViewData["PostID"] = new SelectList(_context.Post, "PostId", "PostName");
            ViewData["RecruitmentID"] = new SelectList(_context.Recruitment, "RecruitmentID", "RecruitmentID");
            return View();
        }

        // POST: Applications/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ApplicationID,PostID,RecruitmentID,CandidateID")] Application application)
        {
            
            application.ApplicationStausID = 1;
            application.ApplicationTime = DateTime.Now;
            _context.Add(application);
            await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));
            
            ViewData["CandidateID"] = new SelectList(_context.Candidate, "CandidateID", "CandidateName", application.CandidateID);
            ViewData["PostID"] = new SelectList(_context.Post, "PostId", "PostId", application.PostID);
            ViewData["RecruitmentID"] = new SelectList(_context.Recruitment, "RecruitmentID", "RecruitmentID", application.RecruitmentID);
            return View(application);
        }



        // GET: Applications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var application = await _context.Application.FindAsync(id);
            if (application == null)
            {
                return NotFound();
            }
            ViewData["CandidateID"] = new SelectList(_context.Candidate, "CandidateID", "CandidateName", application.CandidateID);
            ViewData["PostID"] = new SelectList(_context.Post, "PostId", "PostName", application.PostID);
            ViewData["RecruitmentID"] = new SelectList(_context.Recruitment, "RecruitmentID", "RecruitmentID", application.RecruitmentID);
            return View(application);
        }

        // POST: Applications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ApplicationID,PostID,RecruitmentID,CandidateID,ApplicationTime,ApplicationStausID")] Application application)
        {
            if (id != application.ApplicationID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(application);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicationExists(application.ApplicationID))
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
            ViewData["CandidateID"] = new SelectList(_context.Candidate, "CandidateID", "CandidateName", application.CandidateID);
            ViewData["PostID"] = new SelectList(_context.Post, "PostId", "PostName", application.PostID);
            ViewData["RecruitmentID"] = new SelectList(_context.Recruitment, "RecruitmentID", "RecruitmentID", application.RecruitmentID);
            return View(application);
        }

        // GET: Applications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var application = await _context.Application
                .Include(a => a.Candidate)
                .Include(a => a.Post)
                .Include(a => a.Recruitment)
                .FirstOrDefaultAsync(m => m.ApplicationID == id);
            if (application == null)
            {
                return NotFound();
            }

            return View(application);
        }

        // POST: Applications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var application = await _context.Application.FindAsync(id);
            _context.Application.Remove(application);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApplicationExists(int id)
        {
            return _context.Application.Any(e => e.ApplicationID == id);
        }
    }
}
