using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Sportal.Models;
using SPortal.RoleAuthorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPortal.Data
{
    public class SeedData
    {
        public static void SeedDB(ApplicationDbContext context, string adminId)
        {

            // Look for any db data.
            if (context.AppUsers.OfType<Student>().Any())
            {
                return;   // DB has been seeded
            }

            context.AppUsers.AddRange(
                new Student
                {
                    FirstName = "Harry",
                    DateOfBirth = DateTime.Today,
                    Email = "harry@gmail.com",
                },
                new Student
                {
                    FirstName = "John",
                    DateOfBirth = DateTime.Today,
                    Email = "John@gmail.com"
                },
                new Student
                {
                    FirstName = "Paul",
                    DateOfBirth = DateTime.Today,
                    Email = "Paul@gmail.com"
                }
            );
            context.SaveChanges();


        }
        public static async Task Initialize(IServiceProvider serviceProvider, string testUserPw)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                // For sample purposes seed both with the same password.
                // Password is set with the following:
                // dotnet user-secrets set SeedUserPW <pw>
                // The admin user can do anything

                var adminID = await EnsureUser(serviceProvider, testUserPw, "admin@gmail.com");
                await EnsureRole(serviceProvider, adminID, Constants.PortalAdministratorsRole);



                SeedDB(context, adminID);
            }
        }

        private static async Task<string> EnsureUser(IServiceProvider serviceProvider,
                                                    string testUserPw, string UserName)
        {
            var userManager = serviceProvider.GetService<UserManager<IdentityUser>>();

            var user = await userManager.FindByNameAsync(UserName);
            if (user == null)
            {
                user = new IdentityUser { UserName = UserName };
                await userManager.CreateAsync(user, testUserPw);
            }

            return user.Id;
        }

        private static async Task<IdentityResult> EnsureRole(IServiceProvider serviceProvider,
                                                                      string uid, string role)
        {
            IdentityResult IR = null;
            var roleManager = serviceProvider.GetService<RoleManager<IdentityRole>>();

            if (roleManager == null)
            {
                throw new Exception("roleManager null");
            }

            if (!await roleManager.RoleExistsAsync(role))
            {
                IR = await roleManager.CreateAsync(new IdentityRole(role));
            }

            var userManager = serviceProvider.GetService<UserManager<IdentityUser>>();

            var user = await userManager.FindByIdAsync(uid);

            IR = await userManager.AddToRoleAsync(user, role);

            
            return IR;

            
        }
    }
}
