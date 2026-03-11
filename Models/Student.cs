using CommunityToolkit.Mvvm.ComponentModel;

namespace UniversityMenuApp.Models;

public partial class Student : ObservableObject
{
    public int Id { get; set; }

    [ObservableProperty]
    private string fullName = "";

    [ObservableProperty]
    private string email = "";
}