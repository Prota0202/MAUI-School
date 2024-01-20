using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace School
{
    public partial class StudentsPage : ContentPage
    {
        private ObservableCollection<Student> students = new ObservableCollection<Student>();

        SchoolDataSingleton schoolDataSingleton = SchoolDataSingleton.Instance;
        SchoolDataWriterSingleton schoolDataWriterSingleton = SchoolDataWriterSingleton.Instance;
        public StudentsPage()
        {
            InitializeComponent();
            LoadStudents();
            studentsTable.ItemsSource = students;
        }
        private void LoadStudents()
        {
            List<Student> listStudents = new List<Student>();
            if (schoolDataSingleton.LoadDataStudents(listStudents))
            {
                listStudents.ToList().ForEach(students.Add);
            }
            studentsTable.ItemsSource = students;
        }

        private void OnCreateStudentClicked(object sender, EventArgs e)
        {

            if(String.IsNullOrEmpty(firstNameEntry.Text) || String.IsNullOrEmpty(lastNameEntry.Text))
            {
                DisplayAlert("Error", "Merci de saisir toutes les informations nécessaires", "OK");
                return;
            }

            if (!students.Any(t => t.Firstname.ToLower() == firstNameEntry.Text.ToLower() && t.Lastname.ToLower() == lastNameEntry.Text.ToLower()))
            {
                var student = new Student(firstNameEntry.Text, lastNameEntry.Text);
                students.Add(student);
                schoolDataWriterSingleton.WriteDataStudents(students.ToList());
                resetForm();
            }
            else
            {
                DisplayAlert("Error", "Un étudiant du même nom existe déjà.", "OK");
            }
        }
        private void resetForm()
        {
            firstNameEntry.Text = null;
            lastNameEntry.Text = null;
        }
    }
}