using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityMenuApp.Models;

namespace UniversityMenuApp.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        public IEnumerable<Teacher> GetTeachers()
        {
            return new List<Teacher>
            {
            new() { Id = 1, FullName = "Carlos Amador",  Email = "camador@unicah.edu" },
            new() { Id = 2, FullName = "Julio Hernández",    Email = "jechersa@unicah.edu" },
            
            };
        }

    }
}
