using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessClub3.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "Име")]
        public string Name { get; set; }
        [Display(Name = "Презиме")]
        public string MiddleName { get; set; }
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }
        [Display(Name = "Възраст")]
        public int Age { get; set; }
        [Display(Name = "Роля")]
        public string RoleName { get; set; }
        [Display(Name = "Снимка")]
        public string Photo { get; set; }
        public ICollection<GroupTrainingUser> GroupTraining { get; set; }
    }
}
