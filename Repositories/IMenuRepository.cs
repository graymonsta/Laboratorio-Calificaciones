using UniversityMenuApp.Models;

namespace UniversityMenuApp.Repositories;

public interface IMenuRepository
{
    IEnumerable<MenuOption> GetMenuOptions();
}
