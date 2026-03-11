using ClosedXML.Excel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using UniversityMenuApp.Models;

namespace UniversityMenuApp.ViewModels;

public partial class TeachersViewModel : ObservableObject
{
    public ObservableCollection<Teacher> Teachers { get; } = new();
    [ObservableProperty]
    private Teacher? selectedTeacher;

    [ObservableProperty]
    private string? formName;
    [ObservableProperty]
    private string? formEmail;

    public TeachersViewModel()
    {
        LoadTeachers();
    }

    private void LoadTeachers()
    {
        Teachers.Clear();
        Teachers.Add(new Teacher { Id = 1, FullName = "Carlos Amador", Email = "camador@unicah.edu" });
        Teachers.Add(new Teacher { Id = 2, FullName = "Julio Hernández", Email = "jechersa@unicah.edu" });
    }

    [RelayCommand]

    private void ExportToExcel()
    {
        var dialog = new SaveFileDialog
        {
            Filter = "Excel Files|*.xlsx",
            Title = "Export Teachers to Excel"
        };
        if (dialog.ShowDialog() != true)
            return;

        using var wb = new XLWorkbook();
        var ws = wb.Worksheets.Add("Teachers");

        ws.Cell(1, 1).Value = "Id";
        ws.Cell(1, 2).Value = "Full Name";
        ws.Cell(1, 3).Value = "Email";
        ws.Row(1).Style.Font.Bold = true;

        int row = 2;
        foreach (var teachers in Teachers)
        {
            ws.Cell(row, 1).Value = teachers.Id;
            ws.Cell(row, 2).Value = teachers.FullName;
            ws.Cell(row, 3).Value = teachers.Email;
            row++;
        }

        ws.Columns().AdjustToContents();
        wb.SaveAs(dialog.FileName);

    }
    [RelayCommand]
    private void AddTeacher()
    {
        if (string.IsNullOrWhiteSpace(FormName) || string.IsNullOrWhiteSpace(FormEmail))
            return;

        int newId = Teachers.Count > 0 ? Teachers.Max(t => t.Id) + 1 : 1;

        Teachers.Add(new Teacher
        {
            Id = newId,
            FullName = FormName,
            Email = FormEmail
        });

        FormName = "";
        FormEmail = "";
    }
    [RelayCommand]
    private void DeleteTeacher()
    {
        if (SelectedTeacher == null)
            return;

        Teachers.Remove(SelectedTeacher);
    }
    [RelayCommand]
    private void UpdateTeacher()
    {
        if (SelectedTeacher == null)
            return;

        SelectedTeacher.FullName = FormName!;
        SelectedTeacher.Email = FormEmail!;
    }
    partial void OnSelectedTeacherChanged(Teacher? value)
    {
        if (value != null)
        {
            FormName = value.FullName;
            FormEmail = value.Email;
        }
    }

}
