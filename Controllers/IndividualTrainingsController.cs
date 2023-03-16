using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FitnessClub3.Data;
using FitnessClub3.Models;
using FitnessClub3.Services;
using FitnessClub3.Utility;
using System.Security.Claims;
using FitnessClub3.Models.ViewModels;

namespace FitnessClub3.Controllers
{
    public class IndividualTrainingsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ITrainingService _trainingService;
        public IndividualTrainingsController(ApplicationDbContext context, ITrainingService trainingServices)
        {
            _context = context;
            _trainingService = trainingServices;
        }

        // GET: Trainings
        public async Task<IActionResult> Index()
        {
            if (User.IsInRole(FitnessClub3.Utility.Helper.SportsMan))
            {
                return View(await _context.IndividualTrainings.Where(x => x.SportsmanId.Contains(this.User.FindFirstValue(ClaimTypes.NameIdentifier)) || this.User.FindFirstValue(ClaimTypes.NameIdentifier) == null)
                .ToListAsync());
            }
            else if (User.IsInRole(FitnessClub3.Utility.Helper.IndividualTrainer))
            {
                return View(await _context.IndividualTrainings.Where(x => x.TrainerId.Contains(this.User.FindFirstValue(ClaimTypes.NameIdentifier)) || this.User.FindFirstValue(ClaimTypes.NameIdentifier) == null)
                .ToListAsync());
            }
            else
            {
                return View(await _context.IndividualTrainings
                .ToListAsync());
            }


        }



        public async Task<IActionResult> ShowSearchForm()
        {


            return View();

        }

        //POST: Trainings/ShowSearchResults

        public async Task<IActionResult> ShowSearchResults(String SearchPhrase)
        {
            return View("Index", await _context.IndividualTrainings.Where(j => j.Title.Contains(SearchPhrase)).Where(x => x.TrainerId.Contains(this.User.FindFirstValue(ClaimTypes.NameIdentifier)) || this.User.FindFirstValue(ClaimTypes.NameIdentifier) == null)
                .ToListAsync());
        }

        // GET: Trainings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var training = await _context.IndividualTrainings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (training == null)
            {
                return NotFound();
            }

            return View(training);
        }

        // GET: Trainings/Create
        public IActionResult Create()
        {
            ViewBag.TrainerList = _trainingService.GetTrainersList();
            ViewBag.Duration = Helper.GetTimeDropDown();
            return View();
        }

        // POST: Trainings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,StartDate,EndDate,Duration,TrainerId,SportsmanId,IsTrainerApproved,AdminId")] IndividualTraining training)
        {
            ViewBag.TrainerList = _trainingService.GetTrainersList();
            ViewBag.Duration = Helper.GetTimeDropDown();
            if (ModelState.IsValid)
            {
                training.TrainerName = _context.Users.Where(x => x.Id == training.TrainerId).Select(x => x.Name).FirstOrDefault();
                training.SportsmanId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                training.SportsmanName = this.User.Identity.Name;
                _context.Add(training);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(training);
        }


        // GET: Trainings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var training = await _context.IndividualTrainings.FindAsync(id);
            if (training == null)
            {
                return NotFound();
            }
            return View(training);
        }

        // POST: Trainings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,StartDate,EndDate,Duration,TrainerId,TrainerName,SportsmanId,SportsmanName,IsTrainerApproved,AdminId")] IndividualTraining training)
        {
            if (id != training.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(training);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrainingExists(training.Id))
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
            return View(training);
        }

        // GET: Trainings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var training = await _context.IndividualTrainings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (training == null)
            {
                return NotFound();
            }

            return View(training);
        }

        // POST: Trainings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var training = await _context.IndividualTrainings.FindAsync(id);
            _context.IndividualTrainings.Remove(training);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrainingExists(int id)
        {
            return _context.IndividualTrainings.Any(e => e.Id == id);
        }
    }
}
