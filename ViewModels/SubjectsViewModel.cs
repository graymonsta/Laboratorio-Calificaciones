using ClosedXML.Excel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using UniversityMenuApp.Models;
using UniversityMenuApp.Repositories;

namespace UniversityMenuApp.ViewModels;

public partial class SubjectsViewModel : ObservableObject
{
    private readonly ISubjectRepository _subjectRepo;

    public ObservableCollection<Subject> Subjects { get; } = new();

    [ObservableProperty]
    private Subject? selectedSubject;

    [ObservableProperty]
    private string? formName;

    public SubjectsViewModel()
    {
        LoadSubjects();
    }
    private void LoadSubjects()
    {
        Subjects.Clear();
        Subjects.Add(new Subject { Id = 1, Name = "Ecuaciones Diferenciales" });
        Subjects.Add(new Subject { Id = 2, Name = "Física" });
        Subjects.Add(new Subject { Id = 3, Name = "Inglés I" });
        Subjects.Add(new Subject { Id = 4, Name = "Diseño Gráfico" });
    }
    [RelayCommand]

    private void ExportToExcel()
    {
        var dialog = new SaveFileDialog
        {
            Filter = "Excel Files|*.xlsx",
            Title = "Export Subjects to Excel"
        };
        if (dialog.ShowDialog() != true)
            return;

        using var wb = new XLWorkbook();
        var ws = wb.Worksheets.Add("Subjects");

        ws.Cell(1, 1).Value = "Id";
        ws.Cell(1, 2).Value = "Name";
        ws.Row(1).Style.Font.Bold = true;

        int row = 2;
        foreach (var subjects in Subjects)
        {
            ws.Cell(row, 1).Value = subjects.Id;
            ws.Cell(row, 2).Value = subjects.Name;
            row++;
        }

        ws.Columns().AdjustToContents();
        wb.SaveAs(dialog.FileName);

    }
    [RelayCommand]
    private void AddSubject()
    {
        if (string.IsNullOrWhiteSpace(FormName))
            return;

        int newId = Subjects.Count > 0 ? Subjects.Max(s => s.Id) + 1 : 1;

        Subjects.Add(new Subject
        {
            Id = newId,
            Name = FormName
        });

        FormName = "";
    }
    [RelayCommand]
    private void DeleteSubject()
    {
        if (SelectedSubject == null)
            return;

        Subjects.Remove(SelectedSubject);
    }
    [RelayCommand]
    private void UpdateSubject()
    {
        if (SelectedSubject == null)
            return;

        SelectedSubject.Name = FormName!;
    }
    partial void OnSelectedSubjectChanged(Subject? value)
    {
        if (value != null)
        {
            FormName = value.Name;
        }
    }
}

