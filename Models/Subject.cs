using CommunityToolkit.Mvvm.ComponentModel;

namespace UniversityMenuApp.Models
{
    public partial class Subject : ObservableObject
    {
        public int Id { get; set; }

        [ObservableProperty]
        private string name = "";
    }
}
