using ClosedXML.Excel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using UniversityMenuApp.Models;
using UniversityMenuApp.Repos;

namespace UniversityMenuApp.ViewModels;

public partial class StudentsViewModel : ObservableObject
{
    private readonly IStudentRepository _studentRepository;

    public ObservableCollection<Student> Students { get; } = new();

    [ObservableProperty]
    private Student? selectedStudent;

    [ObservableProperty]
    private string? formName;
    [ObservableProperty]
    private string? formEmail;
    [ObservableProperty]
    private int? grid;

    public StudentsViewModel()
    {
        _studentRepository = new StudentRepository();
        LoadStudents();
    }

    private void LoadStudents()
    {
        Students.Clear();
        var lista = _studentRepository.GetStudents();
        foreach (var student in lista)
        {
            Students.Add(student);
        }
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
    private void AddStudent()
    {
        if (string.IsNullOrWhiteSpace(FormName))
            return;
        int newId = Students.Count > 0 ? Students.Max(s => s.Id) + 1 : 1;
        var newStudent = new Student { Id = newId, FullName = FormName, Email = FormEmail };
        _studentRepository.Add(newStudent);
        Students.Add(newStudent);
        FormName = "";
        FormEmail = "";
    }

    [RelayCommand]
    private void UpdateStudent()
    {
        if (SelectedStudent == null)
            return;
        SelectedStudent.FullName = FormName!;
        SelectedStudent.Email = FormEmail!;
        _studentRepository.Update(SelectedStudent);
    }

    [RelayCommand]
    private void DeleteStudent()
    {
        if (SelectedStudent == null)
            return;
        _studentRepository.Delete(SelectedStudent.Id);
        Students.Remove(SelectedStudent);
        FormName = "";
        FormEmail = "";
    }

    [RelayCommand]
    private void ExportExcel()
    {
        var dialog = new SaveFileDialog
        {
            Filter = "Excel Workbook (*.xlsx)|*.xlsx",
            FileName = "Students.xlsx"
        };
        if (dialog.ShowDialog() != true)
            return;
        using var wb = new XLWorkbook();
        var ws = wb.Worksheets.Add("Students");
        ws.Cell(1, 1).Value = "ID";
        ws.Cell(1, 2).Value = "Nombre";
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
}
