using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FitnessClub3.Data;
using FitnessClub3.Models;
using System.Security.Claims;
using FitnessClub3.Utility;
using Microsoft.AspNetCore.Identity;

namespace FitnessClub3.Controllers
{
    public class GroupTrainingsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public GroupTrainingsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }
        
        public async Task<IActionResult> Attend(int? id)
        {
            var groupTraining = await _context.GroupTrainings
                .FirstOrDefaultAsync(m => m.GroupTrainingId == id);
            return View(groupTraining);
        }

        // POST: GroupTrainingUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Attend([Bind("GroupTrainingUserId,Id,GroupTrainingId")] GroupTrainingUser groupTrainingUser, int id)
        {
            
            var groupTraining = await _context.GroupTrainings
                    .FirstOrDefaultAsync(m => m.GroupTrainingId == id);
             if (ModelState.IsValid)
             {
                
                    var user = await _userManager.GetUserAsync(this.User);
                    var training = await _context.GroupTrainingUsers
                        .Include(g => g.GroupTraining)
                        .Include(a => a.ApplicationUser)
                        .Where(y => y.ApplicationUser == user)
                        .Where(x=>x.GroupTraining.GroupTrainingId ==id)
                        .Select(w => w.GroupTraining)
                        .FirstOrDefaultAsync();
                if (training!=null)
                {
                    return RedirectToAction(nameof(Index));
                }
                groupTrainingUser.SportsManName = this.User.Identity.Name;
                groupTrainingUser.Id = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                groupTrainingUser.GroupTrainingId = id;
                _context.Add(groupTrainingUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
             }
                //ViewData["Id"] = new SelectList(_context.Users, "Id", "Id", groupTrainingUser.Id);
                //ViewData["GroupTrainingId"] = new SelectList(_context.GroupTrainings, "GroupTrainingId", "GroupTrainingId", groupTrainingUser.GroupTrainingId);
                return View(groupTrainingUser);
            
        }
        
        // GET: GroupTrainings
        public async Task<IActionResult> MyGroupTrainings()
        {
            var user = await _userManager.GetUserAsync(this.User);
            var training = await _context.GroupTrainingUsers
                .Include(g => g.GroupTraining)
                .Include(a => a.ApplicationUser)
                .Where(y => y.ApplicationUser == user)
                .Select(w => w.GroupTraining)
                .ToListAsync();
            return View(training);
        }
        
        public async Task<IActionResult> Index()
        {
            ViewBag.Duration = Helper.GetTimeDropDown();
            if (User.IsInRole(FitnessClub3.Utility.Helper.SportsMan))
            {
                return View(await _context.GroupTrainings
                .ToListAsync());
            }
            else if (User.IsInRole(FitnessClub3.Utility.Helper.GroupTrainer))
            {
                return View(await _context.GroupTrainings.Where(x => x.TrainerId.Contains(this.User.FindFirstValue(ClaimTypes.NameIdentifier)) || this.User.FindFirstValue(ClaimTypes.NameIdentifier) == null)
                .ToListAsync());
            }
            else
            {
                return View(await _context.GroupTrainings
                .ToListAsync());
            }
        }

        // GET: GroupTrainings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupTraining = await _context.GroupTrainings.
                Include(m=>m.Users)
                .FirstOrDefaultAsync(m => m.GroupTrainingId == id);
            if (groupTraining == null)
            {
                return NotFound();
            }

            return View(groupTraining);
        }

        // GET: GroupTrainings/Create
        public IActionResult Create()
        {
            ViewBag.Duration = Helper.GetTimeDropDown();
            return View();
        }

        // POST: GroupTrainings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GroupTrainingId,Title,Description,StartDate,EndDate,Duration,TrainerId,TrainerName")] GroupTraining groupTraining)
        {
            ViewBag.Duration = Helper.GetTimeDropDown();
            if (ModelState.IsValid)
            {
                groupTraining.TrainerId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                groupTraining.TrainerName = this.User.Identity.Name;
                _context.Add(groupTraining);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(groupTraining);
        }

        // GET: GroupTrainings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupTraining = await _context.GroupTrainings.FindAsync(id);
            if (groupTraining == null)
            {
                return NotFound();
            }
            return View(groupTraining);
        }

        // POST: GroupTrainings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,StartDate,EndDate,Duration,TrainerId,TrainerName,SportsmanId")] GroupTraining groupTraining)
        {
            if (id != groupTraining.GroupTrainingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(groupTraining);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GroupTrainingExists(groupTraining.GroupTrainingId))
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
            return View(groupTraining);
        }

        // GET: GroupTrainings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupTraining = await _context.GroupTrainings
                .FirstOrDefaultAsync(m => m.GroupTrainingId == id);
            if (groupTraining == null)
            {
                return NotFound();
            }

            return View(groupTraining);
        }

        // POST: GroupTrainings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var groupTraining = await _context.GroupTrainings.FindAsync(id);
            _context.GroupTrainings.Remove(groupTraining);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GroupTrainingExists(int? id)
        {
            return _context.GroupTrainings.Any(e => e.GroupTrainingId == id);
        }
    }
}
