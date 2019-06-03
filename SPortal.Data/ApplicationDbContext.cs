using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sportal.Models;

namespace SPortal.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        public DbSet<dClass> dClasses { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Message> Messages { get; set; }



    }        
}
