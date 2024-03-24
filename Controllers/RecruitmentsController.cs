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
    public class RecruitmentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RecruitmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Recruitments
        public async Task<IActionResult> Index(string id = "")
        {
            

            
            if (!String.IsNullOrEmpty(id))
            { 
                var recruitments = _context.Recruitment.Where(r => r.Post.PostName.ToLower().Contains(id.ToLower()))
                    .Include(r => r.Company)
                    .Include(r => r.Post);
                return View(await recruitments.ToListAsync());
            }
            else
            {
                var recruitments = _context.Recruitment.Include(r => r.Company)
                    .Include(r => r.Post);
                return View(await recruitments.ToListAsync());
            }
            
        }

        

        // GET: Recruitments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recruitment = await _context.Recruitment
                .Include(r => r.Company)
                .Include(r => r.Post)
                .FirstOrDefaultAsync(m => m.RecruitmentID == id);
            if (recruitment == null)
            {
                return NotFound();
            }

            return View(recruitment);
        }

        // GET: Recruitments/Create
        public IActionResult Create()
        {
            ViewData["CompanyID"] = new SelectList(_context.Company, "CompanyID", "CompanyName");
            ViewData["PostID"] = new SelectList(_context.Post, "PostId", "PostName");
            return View();
        }

        // POST: Recruitments/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RecruitmentID,PostID,CompanyID,SrartDate,EndOfApplication,JobDescription")] Recruitment recruitment)
        {
            
            _context.Add(recruitment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            
            //ViewData["CompanyID"] = new SelectList(_context.Company, "CompanyID", "CompanyName", recruitment.CompanyID);
            //ViewData["PostID"] = new SelectList(_context.Post, "PostId", "PostName", recruitment.PostID);
            //return View(recruitment);
        }

        // GET: Recruitments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recruitment = await _context.Recruitment.FindAsync(id);
            if (recruitment == null)
            {
                return NotFound();
            }
            ViewData["CompanyID"] = new SelectList(_context.Company, "CompanyID", "CompanyName", recruitment.CompanyID);
            ViewData["PostID"] = new SelectList(_context.Post, "PostId", "PostName", recruitment.PostID);
            return View(recruitment);
        }

        // POST: Recruitments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RecruitmentID,PostID,CompanyID,SrartDate,EndOfApplication,JobDescription")] Recruitment recruitment)
        {
            if (id != recruitment.RecruitmentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recruitment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecruitmentExists(recruitment.RecruitmentID))
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
            ViewData["CompanyID"] = new SelectList(_context.Company, "CompanyID", "CompanyName", recruitment.CompanyID);
            ViewData["PostID"] = new SelectList(_context.Post, "PostId", "PostName", recruitment.PostID);
            return View(recruitment);
        }

        // GET: Recruitments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recruitment = await _context.Recruitment
                .Include(r => r.Company)
                .Include(r => r.Post)
                .FirstOrDefaultAsync(m => m.RecruitmentID == id);
            if (recruitment == null)
            {
                return NotFound();
            }

            return View(recruitment);
        }

        // POST: Recruitments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recruitment = await _context.Recruitment.FindAsync(id);
            _context.Recruitment.Remove(recruitment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecruitmentExists(int id)
        {
            return _context.Recruitment.Any(e => e.RecruitmentID == id);
        }
    }
}
