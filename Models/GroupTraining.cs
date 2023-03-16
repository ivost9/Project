using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessClub3.Models
{
    public class GroupTraining
    {
        [Key]
        public int GroupTrainingId { get; set; }
        [Display(Name = "Вид")]
        public string Title { get; set; }
        [Display(Name = "Описание")]
        public string Description { get; set; }
        [Display(Name = "Начало")]
        public DateTime StartDate { get; set; }
        [Display(Name = "Край")]
        public DateTime EndDate { get; set; }
        [Display(Name = "Времетраене")]
        public int Duration { get; set; }
        [Display(Name = "ТреньорId")]
        public string TrainerId { get; set; }
        [Display(Name = "Треньор")]
        public string TrainerName { get; set; }
        [Display(Name = "Спортисти")]
        public ICollection<GroupTrainingUser> Users { get; set; }

    }
}
