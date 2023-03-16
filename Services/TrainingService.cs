using FitnessClub3.Data;
using FitnessClub3.Models;
using FitnessClub3.Models.ViewModels;
using FitnessClub3.Services;
using FitnessClub3.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FitnessClub3.Notility
{
    [Authorize]
    public class TrainingService : ITrainingService
    {
        private readonly ApplicationDbContext _db;
        public TrainingService(ApplicationDbContext db)
        {
            _db = db;
        }

        public List<TrainerVM> GetTrainersList()
        {
            var trainers = (from user in _db.Users
                            join userRoles in _db.UserRoles on user.Id equals userRoles.UserId
                            join roles in _db.Roles.Where(x => x.Name == Helper.IndividualTrainer) on userRoles.RoleId equals roles.Id
                            select new TrainerVM
                            {
                                Id = user.Id,
                                Name = user.Name
                            }
                           ).ToList();

            return trainers;
        }
    }
}
