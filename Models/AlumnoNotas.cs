using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityMenuApp.Models
{
    public class AlumnoNotas
    {
        public int AlumnoID { get; set; }
        public int SubjectID { get; set; } 
        public int Nota { get; set; }
    }
}
