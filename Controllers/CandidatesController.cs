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
    public class CandidatesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CandidatesController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Candidates
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Candidate.OrderByDescending(c => c.AiRecommendationScore).Include(c => c.Post);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Candidates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidate = await _context.Candidate
                .Include(c => c.Post)
                .FirstOrDefaultAsync(m => m.CandidateID == id);
            if (candidate == null)
            {
                return NotFound();
            }

            return View(candidate);
        }

        // GET: Candidates/Create
        public IActionResult Create()
        {
            ViewData["PostId"] = new SelectList(_context.Post, "PostId", "PostName");
            return View();
        }

        // POST: Candidates/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CandidateID,CandidateName,PostId,CandiateEmail,CandidatePhone,HonsCGPA,MastersCGPA,Experience,McqPercentage,WrittenPercentage,VivaPercentage,Resume,AiRecommendationScore")] Candidate candidate)
        {
            if (candidate.PostId != 0)
            {
                var sampleData = new MLModel.ModelInput()
                {
                    Hons_CGPA = candidate.HonsCGPA,
                    Masters_CGPA = candidate.MastersCGPA,
                    Experience = candidate.Experience,
                    MCQ_Exam = candidate.McqPercentage,
                    Written_Exam = candidate.WrittenPercentage,
                    Viva = candidate.VivaPercentage,
                };

                //Load model and predict output
                var result = MLModel.Predict(sampleData);
                candidate.AiRecommendationScore = (decimal)result.Score;
                candidate.FilePath = await UploadFile(candidate.Resume);
                _context.Add(candidate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(candidate);
        }

        public IActionResult AddInfo()
        {
            //ViewData["PostId"] = new SelectList(_context.Post, "PostId", "PostName");
            return View();
        }

        // POST: Candidates/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddInfo([Bind("CandidateID,CandidateName,PostId,CandiateEmail,CandidatePhone,HonsCGPA,MastersCGPA,Experience,Resume")] Candidate candidate)
        {
            
                var sampleData = new MLModel.ModelInput()
                {
                    Hons_CGPA = candidate.HonsCGPA,
                    Masters_CGPA = candidate.MastersCGPA,
                    Experience = candidate.Experience,
                    MCQ_Exam = candidate.McqPercentage,
                    Written_Exam = candidate.WrittenPercentage,
                    Viva = candidate.VivaPercentage,
                };

                //Load model and predict output
                var result = MLModel.Predict(sampleData);
                candidate.PostId = 1;
                candidate.AiRecommendationScore = (decimal)result.Score;
                candidate.FilePath = await UploadFile(candidate.Resume);
                _context.Add(candidate);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Recruitments");
            
           
        }

        public async Task<string> UploadFile(IFormFile file)
        {
            string path = "Resumes/";
            string filename = "";
            bool isUploaded = false;
            try
            {
                if (file.Length>0)
                {
                    path += Guid.NewGuid().ToString() + "_" + file.FileName;

                    string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, path);

                    await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

                    
                    //filename = Guid.NewGuid() + Path.GetExtension(file.FileName);
                    //path = Path.Combine(_webHostEnvironment.WebRootPath, "Resumes");
                    //using (var filestream = new FileStream(Path.Combine(path, filename), FileMode.Create))
                    //{
                    //    await file.CopyToAsync(filestream);
                    //}
                    isUploaded = true;
                }
                else
                {
                    isUploaded = false;
                }
            }
            catch (Exception)
            {
                throw;
            }
            if (isUploaded)
            {
                return "/" + path;
            }
            else
            {
                return "";
            }
        }

        // GET: Candidates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidate = await _context.Candidate.FindAsync(id);
            if (candidate == null)
            {
                return NotFound();
            }
            ViewData["PostId"] = new SelectList(_context.Post, "PostId", "PostId", candidate.PostId);
            return View(candidate);
        }

        // POST: Candidates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CandidateID,CandidateName,PostId,CandiateEmail,CandidatePhone,HonsCGPA,MastersCGPA,Experience,McqPercentage,WrittenPercentage,VivaPercentage,AiRecommendationScore")] Candidate candidate)
        {
            if (id != candidate.CandidateID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var sampleData = new MLModel.ModelInput()
                    {
                        Hons_CGPA = candidate.HonsCGPA,
                        Masters_CGPA = candidate.MastersCGPA,
                        Experience = candidate.Experience,
                        MCQ_Exam = candidate.McqPercentage,
                        Written_Exam = candidate.WrittenPercentage,
                        Viva = candidate.VivaPercentage,
                    };

                    //Load model and predict output
                    var result = MLModel.Predict(sampleData);
                    candidate.AiRecommendationScore = (decimal)result.Score;
                    _context.Update(candidate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CandidateExists(candidate.CandidateID))
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
            return View(candidate);
        }

        // GET: Candidates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidate = await _context.Candidate
                .Include(c => c.Post)
                .FirstOrDefaultAsync(m => m.CandidateID == id);
            if (candidate == null)
            {
                return NotFound();
            }

            return View(candidate);
        }

        // POST: Candidates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var candidate = await _context.Candidate.FindAsync(id);
            _context.Candidate.Remove(candidate);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CandidateExists(int id)
        {
            return _context.Candidate.Any(e => e.CandidateID == id);
        }
    }
}
