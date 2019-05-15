using Sportal.Models;
using SPortal.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sportal.Services
{
    public class StudentRepository : Repository<Student>, IStudentsRepository
    {
        public StudentRepository(ApplicationDbContext dbcontext): base(dbcontext){}

        public ApplicationDbContext GetData
        {
            get
            {
                return _dbContext as ApplicationDbContext;
            }
        }

        public IQueryable<Student> GetStudentByName(string name)
        {
            return GetData.AppUsers.OfType<Student>();
        }
    }
}
