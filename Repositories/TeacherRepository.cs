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
        private readonly List<Teacher> _teachers = new()
        {
            new() { Id = 1, Name = "Carlos Amador", Email = "camador@unicah.edu" },
            new() { Id = 2, Name = "Juli Hernández", Email = "jechersa@unicah.edu" },
        };

        public IEnumerable<Teacher> GetTeachers()
        {
            return _teachers;
        }

        public void Add(Teacher teacher)
        {
            _teachers.Add(teacher);
        }

        public void Update(Teacher teacher)
        {
            var existing = _teachers.FirstOrDefault(t => t.Id == teacher.Id);
            if (existing != null)
            {
                existing.Name = teacher.Name;
                existing.Email = teacher.Email;
            }
        }

        public void Delete(int id)
        {
            var teacher = _teachers.FirstOrDefault(t => t.Id == id);
            if (teacher != null)
            {
                _teachers.Remove(teacher);
            }
        }
    }
}
