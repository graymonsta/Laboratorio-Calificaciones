using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityMenuApp.Models;

namespace UniversityMenuApp.Repos
{
    public class StudentRepository : IStudentRepository
    {
        public IEnumerable<Student> GetStudents()
        {
            return new List<Student>
        {
            new() { Id = 1, FullName = "Juan Sanchez",  Email = "jsanchez@gmail.com" },
            new() { Id = 2, FullName = "Cristian Ávila",  Email = "crisavila@gmail.com" },
        };

        }
    }
}