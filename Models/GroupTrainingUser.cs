using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessClub3.Models
{
    public class GroupTrainingUser
    {
        [Key]
        public int GroupTrainingUserId { get; set; }
        [Display(Name = "ID на спортист")]
        public string Id { get; set; }
        [Display(Name = "ID на спортист")]
        [ForeignKey("Id")]
        public ApplicationUser ApplicationUser { get; set; }
        [Display(Name ="Име на спортист")]
        public string SportsManName { get; set; }
        [Display(Name = "ID на тренировка")]
        public int GroupTrainingId { get; set; }
        [ForeignKey("GroupTrainingId")]
        [Display(Name = "ID на тренировка")]
        public GroupTraining GroupTraining { get; set; }
    }
}
