using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityMenuApp.Models;
using UniversityMenuApp.Repos;
using UniversityMenuApp.Repositories;

namespace UniversityMenuApp.Service
{
    public class Calificaciones : ICalificaciones
    {
    private readonly IStudentRepository _studentRepository;
    private readonly ISubjectRepository _subjectRepository;
    private readonly IAlumnoNotasRepository _alumnoNotasRepository;

    public List<ReporteCalificaciones> GetReporteCalificaciones()
        {
            throw new NotImplementedException();
        }
    }
}
