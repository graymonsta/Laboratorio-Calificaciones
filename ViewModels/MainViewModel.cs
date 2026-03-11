using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using UniversityMenuApp.Models;
using UniversityMenuApp.Repositories;

namespace UniversityMenuApp.ViewModels;

public partial class MainViewModel : ObservableObject
{
    private readonly IMenuRepository _menuRepo;
    private readonly HomeViewModel _homeVM = new();
    private readonly StudentsViewModel _studentsVM = new();
    private readonly TeachersViewModel _teachersVM = new();
    private readonly SubjectsViewModel _subjectsVM = new();

    public ObservableCollection<MenuOption> MenuOptions { get; } = new();

    [ObservableProperty]
    private object? currentViewModel;

    public MainViewModel(IMenuRepository menuRepo)
    {
        _menuRepo = menuRepo;

        foreach (var option in _menuRepo.GetMenuOptions())
            MenuOptions.Add(option);

        CurrentViewModel = _homeVM;
    }

    [RelayCommand]
    private void Navigate(MenuOption? option)
    {
        if (option is null) return;
        CurrentViewModel = option.Route switch
        {
            "Home" => _homeVM,
            "Students" => _studentsVM,
            "Teachers" => _teachersVM,
            "Subjects" => _subjectsVM,
            _ => _homeVM
        };
    }
}
