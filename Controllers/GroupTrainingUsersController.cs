using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FitnessClub3.Data;
using FitnessClub3.Models;

namespace FitnessClub3.Controllers
{
    public class GroupTrainingUsersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GroupTrainingUsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GroupTrainingUsers
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.GroupTrainingUsers.Include(g => g.ApplicationUser).Include(g => g.GroupTraining);
            return View(await applicationDbContext.ToListAsync());
        }

        

        // GET: GroupTrainingUsers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupTrainingUser = await _context.GroupTrainingUsers
                .Include(g => g.ApplicationUser)
                .Include(g => g.GroupTraining)
                .FirstOrDefaultAsync(m => m.GroupTrainingUserId == id);
            if (groupTrainingUser == null)
            {
                return NotFound();
            }

            return View(groupTrainingUser);
        }

        // POST: GroupTrainingUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var groupTrainingUser = await _context.GroupTrainingUsers.FindAsync(id);
            _context.GroupTrainingUsers.Remove(groupTrainingUser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
