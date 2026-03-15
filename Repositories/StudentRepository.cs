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
        private readonly List<Student> _students = new()
        {
            new() { Id = 1, FullName = "Juan Sánchez", Email = "jsanchez@gmail.com" },
            new() { Id = 2, FullName = "Cristian Ávila", Email = "crisavila@gmail.com" },
            new() { Id = 3, FullName = "Angel Paredes", Email = "aparedes@gmail.com" }
        };

        public IEnumerable<Student> GetStudents()
        {
            return _students;
        }

        public void Add(Student student)
        {
            _students.Add(student);
        }

        public void Update(Student student)
        {
            var existing = _students.FirstOrDefault(s => s.Id == student.Id);
            if (existing != null)
            {
                existing.FullName = student.FullName;
                existing.Email = student.Email;
            }
        }

        public void Delete(int id)
        {
            var student = _students.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                _students.Remove(student);
            }
        }
    }
}