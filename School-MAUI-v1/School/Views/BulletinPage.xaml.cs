using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace School
{
    public partial class BulletinPage : ContentPage
    {
        private ObservableCollection<Student> students = new ObservableCollection<Student>();
        SchoolDataSingleton schoolDataSingleton = SchoolDataSingleton.Instance;

        public BulletinPage()
        {
            InitializeComponent();
            LoadEvaluations();
        }


        private void LoadEvaluations()
        {
            List<Student> listStudentsEvaluations = new List<Student>();
            if (schoolDataSingleton.LoadDataEvaluation(listStudentsEvaluations))
            {
                listStudentsEvaluations.ToList().ForEach(students.Add);
            }
            studentsTable.ItemsSource = students;
        }

        private async void OnCreateBulletinsClicked(object sender, EventArgs e)
        {
            var mainDir = System.IO.Path.Combine(FileSystem.AppDataDirectory, "");
            if (students.Count > 0)
            {
                schoolDataSingleton.GenerateBulletins(students.ToList());
                DisplayAlert("Succès", "Les fichiers bulletins ont été générés\n dans "+ mainDir, "OK");

            }
            else
            {
                DisplayAlert("Erreur", "la liste des étudiants est vide !", "OK");
            }
        }
    }
}