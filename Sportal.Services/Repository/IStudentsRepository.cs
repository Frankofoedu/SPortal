using Sportal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sportal.Services
{
   public interface IStudentsRepository:IRepository<Student>
    {
        IQueryable<Student> GetStudentByName(string name);
    }
}
