using System.Windows;
using UniversityMenuApp.Repositories;
using UniversityMenuApp.ViewModels;

namespace UniversityMenuApp;

public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        var menuRepo = new MenuRepository();
        var mainVm = new MainViewModel(menuRepo);

        var window = new MainWindow
        {
            DataContext = mainVm
        };
        window.Show();
    }
}
