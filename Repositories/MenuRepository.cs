using UniversityMenuApp.Models;

namespace UniversityMenuApp.Repositories;

public class MenuRepository : IMenuRepository
{
    public IEnumerable<MenuOption> GetMenuOptions()
    {
        return new List<MenuOption>
        {
            new() { Title="Inicio", ImagePath="Assets/home.png", Route="Home" },
            new() { Title="Alumnos", ImagePath="Assets/students.png", Route="Students" },
            new() { Title="Maestros", ImagePath="Assets/teachers.png", Route="Teachers" },
            new() { Title="Asignaturas", ImagePath="Assets/subjects.png", Route="Subjects" },
            new() { Title="Reportes", ImagePath="Assets/reports.png", Route="Reports" },
            new() { Title="Configuración", ImagePath="Assets/settings.png", Route="Settings" },
        };
    }
}
