using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityMenuApp.Models;
using UniversityMenuApp.Repos;
using UniversityMenuApp.Repositories;
using UniversityMenuApp.Service;

namespace UniversityMenuApp.ViewModels
{
    public partial class ReportesViewModel : ObservableObject
    {
        private readonly ICalificaciones _calificaciones;

        public ObservableCollection<ReporteCalificaciones> Reportes { get; } = new();

        [ObservableProperty]
        private int filtroId;

        public ReportesViewModel()
        {
            _calificaciones = new Calificaciones(
                new StudentRepository(),
                new SubjectRepository(),
                new AlumnoNotasRepository()
            );
            LoadTodo();
        }

        private void LoadTodo()
        {
            Reportes.Clear();
            var lista = _calificaciones.GetReporteCalificaciones();
            foreach (var reporte in lista)
            {
                Reportes.Add(reporte);
            }
        }

        [RelayCommand]
        private void VerTodo()
        {
            LoadTodo();
        }

        [RelayCommand]
        private void FiltrarPorAlumno()
        {
            Reportes.Clear();
            var lista = _calificaciones.NotasxAlumno(FiltroId);
            foreach (var reporte in lista)
            {
                Reportes.Add(reporte);
            }
        }

        [RelayCommand]
        private void FiltrarPorMateria()
        {
            Reportes.Clear();
            var lista = _calificaciones.NotasxMateria(FiltroId);
            foreach (var reporte in lista)
            {
                Reportes.Add(reporte);
            }
        }
    }
}
