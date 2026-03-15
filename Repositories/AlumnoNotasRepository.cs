using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityMenuApp.Models;

namespace UniversityMenuApp.Repositories
{
    public class AlumnoNotasRepository : IAlumnoNotasRepository
    {
        public IEnumerable<AlumnoNotas> GetAlumnoNotas()
        {
            return new List<AlumnoNotas>
            {
               new() { AlumnoID = 1, SubjectID = 1, Nota = 100 },
               new() { AlumnoID = 1, SubjectID = 2, Nota = 90 },
               new() { AlumnoID = 1, SubjectID = 3, Nota = 75 },
               new() { AlumnoID = 2, SubjectID = 1, Nota = 70 },
               new() { AlumnoID = 2, SubjectID = 2, Nota = 80 },
               new() { AlumnoID = 2, SubjectID = 3, Nota = 100 },
               new() { AlumnoID = 3, SubjectID = 1, Nota = 77 },
               new() { AlumnoID = 3, SubjectID = 2, Nota = 82 },
               new() { AlumnoID = 3, SubjectID = 3, Nota = 93 }
            };
        }
    }
}
