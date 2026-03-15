using ClosedXML.Excel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using UniversityMenuApp.Models;
using UniversityMenuApp.Repositories;

namespace UniversityMenuApp.ViewModels;

public partial class TeachersViewModel : ObservableObject
{
    private readonly ITeacherRepository _teachersRepository;

    public ObservableCollection<Teacher> Teachers { get; } = new();

    [ObservableProperty]
    private Teacher? selectedTeacher;

    [ObservableProperty]
    private string? formName;
    [ObservableProperty]
    private string? formEmail;

    public TeachersViewModel()
    {
        _teachersRepository = new TeacherRepository();
        LoadTeachers();
    }

    private void LoadTeachers()
    {
        Teachers.Clear();
        var lista = _teachersRepository.GetTeachers();
        foreach (var teacher in lista)
        {
            Teachers.Add(teacher);
        }
    }

    partial void OnSelectedTeacherChanged(Teacher? value)
    {
        if (value != null)
        {
            FormName = value.Name;
            FormEmail = value.Email;
        }
    }

    [RelayCommand]
    private void AddTeacher()
    {
        if (string.IsNullOrWhiteSpace(FormName))
            return;
        int newId = Teachers.Count > 0 ? Teachers.Max(t => t.Id) + 1 : 1;
        var newTeacher = new Teacher { Id = newId, Name = FormName, Email = FormEmail };
        _teachersRepository.Add(newTeacher);
        Teachers.Add(newTeacher);
        FormName = "";
        FormEmail = "";
    }

    [RelayCommand]
    private void UpdateTeacher()
    {
        if (SelectedTeacher == null)
            return;
        SelectedTeacher.Name = FormName!;
        SelectedTeacher.Email = FormEmail!;
        _teachersRepository.Update(SelectedTeacher);
    }

    [RelayCommand]
    private void DeleteTeacher()
    {
        if (SelectedTeacher == null)
            return;
        _teachersRepository.Delete(SelectedTeacher.Id);
        Teachers.Remove(SelectedTeacher);
        FormName = "";
        FormEmail = "";
    }

    [RelayCommand]
    private void ExportExcel()
    {
        var dialog = new SaveFileDialog
        {
            Filter = "Excel Workbook (*.xlsx)|*.xlsx",
            FileName = "Teachers.xlsx"
        };
        if (dialog.ShowDialog() != true)
            return;
        using var wb = new XLWorkbook();
        var ws = wb.Worksheets.Add("Teachers");
        ws.Cell(1, 1).Value = "ID";
        ws.Cell(1, 2).Value = "Nombre";
        ws.Cell(1, 3).Value = "Email";
        ws.Row(1).Style.Font.Bold = true;
        int row = 2;
        foreach (var teacher in Teachers)
        {
            ws.Cell(row, 1).Value = teacher.Id;
            ws.Cell(row, 2).Value = teacher.Name;
            ws.Cell(row, 3).Value = teacher.Email;
            row++;
        }
        ws.Columns().AdjustToContents();
        wb.SaveAs(dialog.FileName);
    }
}
