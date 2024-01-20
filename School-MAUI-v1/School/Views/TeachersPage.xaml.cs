using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace School
{
    public partial class TeachersPage : ContentPage
    {
        private ObservableCollection<Teacher> teachers = new ObservableCollection<Teacher>();

        SchoolDataSingleton schoolDataSingleton = SchoolDataSingleton.Instance;
        SchoolDataWriterSingleton schoolDataWriterSingleton = SchoolDataWriterSingleton.Instance;
        public TeachersPage()
        {
            InitializeComponent();
            LoadTeachers();
            teachersTable.ItemsSource = teachers;
        }
        private void LoadTeachers()
        {
            List<Teacher> listTeachers = new List<Teacher>();
            if (schoolDataSingleton.LoadDataTeachers(listTeachers))
            {
                listTeachers.ToList().ForEach(teachers.Add);
            }
            teachersTable.ItemsSource = teachers;
        }

        private void OnCreateTeacherClicked(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(firstNameEntry.Text) || String.IsNullOrEmpty(lastNameEntry.Text) || String.IsNullOrEmpty(salaryEntry.Text))
            {
                DisplayAlert("Error", "Merci de saisir toutes les informations nécessaires", "OK");
                return;
            }
            if (int.TryParse(salaryEntry.Text, out var salary))
            {
                if (!teachers.Any(t => t.Firstname.ToLower() == firstNameEntry.Text.ToLower() && t.Lastname.ToLower() == lastNameEntry.Text.ToLower()))
                {
                    var teacher = new Teacher(firstNameEntry.Text, lastNameEntry.Text, salary);
                    teachers.Add(teacher);
                    schoolDataWriterSingleton.WriteDataTeachers(teachers.ToList());
                    resetForm();
                }
                else
                {
                    DisplayAlert("Error", "Un enseignant du même nom existe déjà.", "OK");
                }
            }
            else
            {
                DisplayAlert("Error", "Le salaire doit être un nombre.", "OK");
            }
        }

        private void resetForm()
        {
            firstNameEntry.Text = null;
            lastNameEntry.Text = null;
            salaryEntry.Text = null;
        }
    }
}