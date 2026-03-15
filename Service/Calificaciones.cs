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

        public Calificaciones(
               IStudentRepository studentRepository,
               ISubjectRepository subjectRepository,
               IAlumnoNotasRepository alumnoNotasRepository)
        {
            _studentRepository = studentRepository;
            _subjectRepository = subjectRepository;
            _alumnoNotasRepository = alumnoNotasRepository;
        }

        public List<ReporteCalificaciones> GetReporteCalificaciones()
        {
            var alumnos = _studentRepository.GetStudents();
            var materias = _subjectRepository.GetSubjects();
            var notas = _alumnoNotasRepository.GetAlumnoNotas();

            var resultado = (
                from nota in notas
                join alumno in alumnos on nota.AlumnoID equals alumno.Id
                join materia in materias on nota.SubjectID equals materia.Id
                select new ReporteCalificaciones
                {
                    StudentId = alumno.Id,
                    StudentName = alumno.FullName,
                    SubjectId = materia.Id,
                    SubjectName = materia.Name,
                    Nota = nota.Nota
                }
            ).ToList();

            return resultado;
        }

        public List<ReporteCalificaciones> NotasxAlumno(int id)
        {
            var alumnos = _studentRepository.GetStudents();
            var materias = _subjectRepository.GetSubjects();
            var notas = _alumnoNotasRepository.GetAlumnoNotas();

            var resultado = (
                from nota in notas
                where nota.AlumnoID == id
                join alumno in alumnos on nota.AlumnoID equals alumno.Id
                join materia in materias on nota.SubjectID equals materia.Id
                select new ReporteCalificaciones
                {
                    StudentId = alumno.Id,
                    StudentName = alumno.FullName,
                    SubjectId = materia.Id,
                    SubjectName = materia.Name,
                    Nota = nota.Nota
                }
            ).ToList();

            return resultado;
        }

        public List<ReporteCalificaciones> NotasxMateria(int id)
        {
            var alumnos = _studentRepository.GetStudents();
            var materias = _subjectRepository.GetSubjects();
            var notas = _alumnoNotasRepository.GetAlumnoNotas();

            var resultado = (
                from nota in notas
                where nota.SubjectID == id
                join alumno in alumnos on nota.AlumnoID equals alumno.Id
                join materia in materias on nota.SubjectID equals materia.Id
                select new ReporteCalificaciones
                {
                    StudentId = alumno.Id,
                    StudentName = alumno.FullName,
                    SubjectId = materia.Id,
                    SubjectName = materia.Name,
                    Nota = nota.Nota
                }
            ).ToList();

            return resultado;
        }
    }
}
