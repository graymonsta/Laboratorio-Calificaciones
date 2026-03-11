using CommunityToolkit.Mvvm.ComponentModel;

namespace UniversityMenuApp.Models
{
    public partial class Teacher : ObservableObject
    {
        public int Id { get; set; }

        [ObservableProperty]
        private string fullName = "";

        [ObservableProperty]
        private string email = "";
    }
}
