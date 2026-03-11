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
               new AlumnoNotas { AlumnoID = 1, SubjectID = 1, Nota = 85 },
               new AlumnoNotas { AlumnoID = 2, SubjectID = 2, Nota = 90 },
               new AlumnoNotas { AlumnoID = 3, SubjectID = 3, Nota = 78 },
            };
        }
    }
}
