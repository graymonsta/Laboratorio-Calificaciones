using ClosedXML.Excel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using UniversityMenuApp.Models;
using UniversityMenuApp.Repositories;

namespace UniversityMenuApp.ViewModels;

public partial class SubjectsViewModel : ObservableObject
{
    private readonly ISubjectRepository _subjectsRepository;

    public ObservableCollection<Subject> Subjects { get; } = new();

    [ObservableProperty]
    private Subject? selectedSubject;

    [ObservableProperty]
    private string? formName;

    public SubjectsViewModel()
    {
        _subjectsRepository = new SubjectRepository();
        LoadSubjects();
    }

    private void LoadSubjects()
    {
        Subjects.Clear();
        var lista = _subjectsRepository.GetSubjects();
        foreach (var subject in lista)
        {
            Subjects.Add(subject);
        }
    }

    partial void OnSelectedSubjectChanged(Subject? value)
    {
        if (value != null)
        {
            FormName = value.Name;
        }
    }

    [RelayCommand]
    private void AddSubject()
    {
        if (string.IsNullOrWhiteSpace(FormName))
            return;
        int newId = Subjects.Count > 0 ? Subjects.Max(s => s.Id) + 1 : 1;
        var newSubject = new Subject { Id = newId, Name = FormName };
        _subjectsRepository.Add(newSubject);
        Subjects.Add(newSubject);
        FormName = "";
    }

    [RelayCommand]
    private void UpdateSubject()
    {
        if (SelectedSubject == null)
            return;
        SelectedSubject.Name = FormName!;
        _subjectsRepository.Update(SelectedSubject);
    }

    [RelayCommand]
    private void DeleteSubject()
    {
        if (SelectedSubject == null)
            return;
        _subjectsRepository.Delete(SelectedSubject.Id);
        Subjects.Remove(SelectedSubject);
        FormName = "";
    }

    [RelayCommand]
    private void ExportExcel()
    {
        var dialog = new SaveFileDialog
        {
            Filter = "Excel Workbook (*.xlsx)|*.xlsx",
            FileName = "Subjects.xlsx"
        };
        if (dialog.ShowDialog() != true)
            return;
        using var wb = new XLWorkbook();
        var ws = wb.Worksheets.Add("Subjects");
        ws.Cell(1, 1).Value = "ID";
        ws.Cell(1, 2).Value = "Nombre";
        ws.Row(1).Style.Font.Bold = true;
        int row = 2;
        foreach (var subject in Subjects)
        {
            ws.Cell(row, 1).Value = subject.Id;
            ws.Cell(row, 2).Value = subject.Name;
            row++;
        }
        ws.Columns().AdjustToContents();
        wb.SaveAs(dialog.FileName);
    }
}

