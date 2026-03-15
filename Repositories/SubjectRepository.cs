using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityMenuApp.Models;

namespace UniversityMenuApp.Repositories
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly List<Subject> _subjects = new()
        {
            new() { Id = 1, Name = "Álgebra" },
            new() { Id = 2, Name = "Análisis y Diseño de Sistemas" },
            new() { Id = 3, Name = "Sistemas Operativos" },
            new() { Id = 4, Name = "Big Data" }
        };

        public IEnumerable<Subject> GetSubjects()
        {
            return _subjects;
        }

        public void Add(Subject subject)
        {
            _subjects.Add(subject);
        }

        public void Update(Subject subject)
        {
            var existing = _subjects.FirstOrDefault(s => s.Id == subject.Id);
            if (existing != null)
            {
                existing.Name = subject.Name;
            }
        }

        public void Delete(int id)
        {
            var subject = _subjects.FirstOrDefault(s => s.Id == id);
            if (subject != null)
            {
                _subjects.Remove(subject);
            }
        }
    }
}
