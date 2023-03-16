using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessClub3.Utility
{
    public static class Helper
    {
        public static string Admin = "Админ";
        public static string SportsMan = "Спортист";
        public static string IndividualTrainer = "Индивидуален Треньор";
        public static string GroupTrainer = "Групов Треньор";

        
        public static List<SelectListItem> GetRolesForDropDown(bool isAdmin)
        {
            if (isAdmin == true)
            {
                return new List<SelectListItem>
                {
                    new SelectListItem{Value=Helper.Admin,Text=Helper.Admin},
                    new SelectListItem{Value=Helper.SportsMan,Text=Helper.SportsMan},
                    new SelectListItem{Value=Helper.IndividualTrainer,Text=Helper.IndividualTrainer},
                    new SelectListItem{Value=Helper.GroupTrainer,Text=Helper.GroupTrainer}
                };
            }
            else
            {
                return new List<SelectListItem>
                {
                    new SelectListItem{Value=Helper.SportsMan,Text=Helper.SportsMan}
                };
            }

        }
        public static List<SelectListItem> GetTimeDropDown()
        {
            int minute = 60;
            List<SelectListItem> duration = new List<SelectListItem>();
            for (int i = 1; i <= 12; i++)
            {
                duration.Add(new SelectListItem { Value = minute.ToString(), Text = i + "Hr" });
                minute = minute + 30;
                duration.Add(new SelectListItem { Value = minute.ToString(), Text = i + "Hr 30 min" });
                minute = minute + 30;
            }
            return duration;
        }
    }
}
