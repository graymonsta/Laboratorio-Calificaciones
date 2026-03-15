using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityMenuApp.Models;

namespace UniversityMenuApp.Repositories
{
    public interface ITeacherRepository
    {
        IEnumerable<Teacher> GetTeachers();
        void Add(Teacher teacher);
        void Update(Teacher teacher);
        void Delete(int id);
    }
}
