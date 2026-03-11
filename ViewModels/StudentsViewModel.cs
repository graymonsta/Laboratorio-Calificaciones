using ClosedXML.Excel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using UniversityMenuApp.Models;

namespace UniversityMenuApp.ViewModels;

public partial class StudentsViewModel : ObservableObject
{
    public ObservableCollection<Student> Students { get; } = new();

    [ObservableProperty]
    private Student? selectedStudent;

    [ObservableProperty]
    private string? formName;

    [ObservableProperty]
    private string? formEmail;
    public StudentsViewModel()
    {
        LoadStudents();
    }
    private void LoadStudents()
    {
        Students.Clear();
        Students.Add(new Student { Id = 1, FullName = "Juan Sánchez", Email = "jsanchez@gmail.com" });
        Students.Add(new Student { Id = 2, FullName = "Cristian Ávila", Email = "crisavila@gmail.com" });
    }


    [RelayCommand]
    
    private void ExportToExcel()
    {
        var dialog = new SaveFileDialog
        {
            Filter = "Excel Files|*.xlsx",
            Title = "Export Students to Excel"
        };
        if (dialog.ShowDialog() != true)
            return;

        using var wb = new XLWorkbook();
        var ws = wb.Worksheets.Add("Students");

        ws.Cell(1, 1).Value = "Id";
        ws.Cell(1, 2).Value = "Full Name";
        ws.Cell(1, 3).Value = "Email";
        ws.Row(1).Style.Font.Bold = true;

        int row = 2;
        foreach (var student in Students)
        {
            ws.Cell(row, 1).Value = student.Id;
            ws.Cell(row, 2).Value = student.FullName;
            ws.Cell(row, 3).Value = student.Email;
            row++;
        }

        ws.Columns().AdjustToContents();    
        wb.SaveAs(dialog.FileName);

    }
    [RelayCommand]
    private void AddStudent()
    {
        if (string.IsNullOrWhiteSpace(FormName) || string.IsNullOrWhiteSpace(FormEmail))
            return;

        int newId = Students.Count > 0 ? Students.Max(s => s.Id) + 1 : 1;

        Students.Add(new Student
        {
            Id = newId,
            FullName = FormName,
            Email = FormEmail
        });

        FormName = "";
        FormEmail = "";
    }
    partial void OnSelectedStudentChanged(Student? value)
    {
        if (value != null)
        {
            FormName = value.FullName;
            FormEmail = value.Email;
        }
    }

    [RelayCommand]
    private void DeleteStudent()
    {
        if (SelectedStudent == null)
            return;

        Students.Remove(SelectedStudent);
    }
    [RelayCommand]
    private void UpdateStudent()
    {
        if (SelectedStudent == null)
            return;

        SelectedStudent.FullName = FormName!;
        SelectedStudent.Email = FormEmail!;
    }
}
