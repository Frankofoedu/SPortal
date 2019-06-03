using Bogus;
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
            

            var testFakeStudents = new Faker<Student>()
                                       // .RuleFor(st => st.UserID, f => f.Random.Guid())
                                        .RuleFor(st => st.Country, f => f.Address.Country())
                                        .RuleFor(st => st.DateOfBirth, f => f.Person.DateOfBirth)
                                        .RuleFor(st => st.Email, f => f.Person.Email)
                                        .RuleFor(st => st.FirstName, f => f.Person.FirstName)
                                        .RuleFor(st => st.Gender, f => f.PickRandom<Gender>())
                                       // .RuleFor(st => st.Image, f => f.Person.Avatar)
                                        .RuleFor(st => st.LastLogin, f => f.Date.Recent(10))
                                        .RuleFor(st => st.LastName, f => f.Person.LastName)
                                        .RuleFor(st => st.PhoneNumber, f => f.Person.Phone)
                                        .RuleFor(st => st.RegNo, f => f.Internet.Random.AlphaNumeric(10))
                                        .RuleFor(st => st.StateOfOrigin, f => f.Address.State());

            var testFakeParent = new Faker<Parent>()
                                       // .RuleFor(st => st.UserID, f => f.Random.Guid())
                                        .RuleFor(st => st.Country, f => f.Address.Country())
                                        .RuleFor(st => st.DateOfBirth, f => f.Person.DateOfBirth)
                                        .RuleFor(st => st.Email, f => f.Person.Email)
                                        .RuleFor(st => st.FirstName, f => f.Person.FirstName)
                                        .RuleFor(st => st.Gender, f => f.PickRandom<Gender>())
                                        .RuleFor(st => st.LastLogin, f => f.Date.Recent(10))
                                        .RuleFor(st => st.LastName, f => f.Person.LastName)
                                        .RuleFor(st => st.PhoneNumber, f => f.Person.Phone)
                                        .RuleFor(st => st.StateOfOrigin, f => f.Address.State())
                                        .RuleFor(st => st.AltPhoneNumber, f => f.Person.Phone)
                                        .RuleFor(st => st.Address, f => f.Person.Address.Street)
                                        .RuleFor(st => st.Occupation, f => f.Person.Company.Name);


            var classess = new List<dClass>()
            {
                new dClass { ClassName = "Jss1"},
                new dClass {  ClassName = "Jss2" },
                new dClass { ClassName = "Jss3"},
                new dClass { ClassName = "Sss1"}
            };


            var sections = new List<Section>()
            {
                new Section {dClassID = new Guid("186b00d8-3ffa-4467-4034-08d6deecacf1"), SectionName = "JSS1A"},
                new Section {dClassID = new Guid("186b00d8-3ffa-4467-4034-08d6deecacf1"), SectionName = "JSS1B"},
                new Section {dClassID = new Guid("186b00d8-3ffa-4467-4034-08d6deecacf1"), SectionName = "JSS1C"},
            };




            List<Parent> ptList = testFakeParent.Generate(20);
            List<Student> studs = testFakeStudents.Generate(20);

            context.Sections.AddRange(sections);
            context.AppUsers.AddRange(studs);
            context.dClasses.AddRange(classess);
            context.SaveChanges();
        }
        public static async Task Initialize(IServiceProvider serviceProvider, string testUserPw)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
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
            var userManager = serviceProvider.GetService<UserManager<AppUser>>();

            var user = await userManager.FindByNameAsync(UserName);
            if (user == null)
            {

                var testFakeStaff = new Faker<Staff>()
                                          //.RuleFor(st => st.UserID, f => f.Random.Guid())
                                            .RuleFor(st => st.Country, f => f.Address.Country())
                                            .RuleFor(st => st.DateOfBirth, f => f.Person.DateOfBirth)
                                            .RuleFor(st => st.Email, f => f.Person.Email)
                                            .RuleFor(st => st.FirstName, f => f.Person.FirstName)
                                            .RuleFor(st => st.Gender, f => f.PickRandom<Gender>())
                                            .RuleFor(st => st.Image, f => f.Person.Avatar)
                                            .RuleFor(st => st.LastLogin, f => f.Date.Recent(10))
                                            .RuleFor(st => st.LastName, f => f.Person.LastName)
                                            .RuleFor(st => st.PhoneNumber, f => f.Person.Phone)
                                            .RuleFor(st => st.Position, f => f.Person.Company.Name)
                                            .RuleFor(st => st.StateOfOrigin, f => f.Address.State());

                user = testFakeStaff.Generate();

                user.UserName = UserName;
                user.Email = UserName;

               await userManager.CreateAsync(user, testUserPw);

            }

            return user.Id.ToString();
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

            var userManager = serviceProvider.GetService<UserManager<AppUser>>();

            var user =  await userManager.FindByIdAsync(uid);

            IR = await  userManager.AddToRoleAsync(user, role);

            
            return IR;

            
        }
    }
}
