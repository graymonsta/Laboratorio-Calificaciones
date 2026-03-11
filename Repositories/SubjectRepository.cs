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
        

        public IEnumerable<Subject> GetSubjects()
        {
            return new List<Subject>
        {
            new() { Id = 1, Name = "Ecuaciones Diferenciales" },
            new() { Id = 2, Name = "Física" },
            new() { Id = 3, Name = "Inglés I" },
            new() { Id = 4, Name = "Diseño Gráfico" },
        };
        }
    }
}
