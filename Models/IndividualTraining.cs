using FitnessClub3.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessClub3.Models
{

    public class IndividualTraining
    {
        public int Id { get; set; }
        [Display(Name="Вид")]
        public string Title { get; set; }
        [Display(Name = "Описание")]
        public string Description { get; set; }
        [Display(Name = "Начало")]
        public DateTime StartDate { get; set; }
        [Display(Name = "Край")]
        public DateTime EndDate { get; set; }
        [Display(Name = "Времетраене")]
        public int Duration { get; set; }
        [Display(Name = "Треньор")]
        public string TrainerId { get; set; }
        [Display(Name = "Треньор")]
        public string TrainerName { get; set; }
        [Display(Name = "Спортист")]
        public string SportsmanId { get; set; }
        [Display(Name = "Спортист")]
        public string SportsmanName { get; set; }
        [Display(Name = "Статус")]
        public bool IsTrainerApproved { get; set; }
        public string AdminId { get; set; }
    }
}
