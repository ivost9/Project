using FitnessClub3.Models;
using FitnessClub3.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessClub3.Services
{
    public interface ITrainingService
    {
        public List<TrainerVM> GetTrainersList();
    }
}
