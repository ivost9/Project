using FitnessClub3.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace FitnessClub3.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<IndividualTraining> IndividualTrainings { get; set; }
        public DbSet<GroupTraining> GroupTrainings { get; set; }
        public DbSet<GroupTrainingUser> GroupTrainingUsers { get; set; }
        //seed
        //1
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            const string admin_id = "a53f0179-0c73-43df-a2ee-f4aaff1b6069";

            var admin = new ApplicationUser
            {
                Id = admin_id,
                Name = "Ivo",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                RoleName = "Админ"
            };

            var ph = new PasswordHasher<ApplicationUser>();
            admin.PasswordHash = ph.HashPassword(admin, "12345678");
            builder.Entity<ApplicationUser>().HasData(admin);

            //2
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                //3
                //RoleId = АдминID.. ID-то е различно при всяко създаване на нова база от данни
                RoleId = "8d134180-3598-4660-8d19-e261b2d4d2db",
                UserId = admin_id
            });
        }

    }
}
