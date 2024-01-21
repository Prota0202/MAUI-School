using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace School
{
    public partial class EvaluationsPage : ContentPage
    {
        private ObservableCollection<Student> students = new ObservableCollection<Student>();
        private ObservableCollection<Activity> activities = new ObservableCollection<Activity>();
        private ObservableCollection<Student> studentsEvaluations = new ObservableCollection<Student>();

        SchoolDataSingleton schoolDataSingleton = SchoolDataSingleton.Instance;
        SchoolDataWriterSingleton schoolDataWriterSingleton = SchoolDataWriterSingleton.Instance;


        public EvaluationsPage()
        {
            InitializeComponent();
            evaluationTypePicker.ItemsSource = new List<string> { "Cote", "Appréciation" };
            
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadStudents();
            LoadActivities();
            LoadEvaluations();
        }

        private void LoadEvaluations()
        {
            List<Student> listStudentsEvaluations = new List<Student>();
            studentsEvaluations = new ObservableCollection<Student>();
            if (schoolDataSingleton.LoadDataEvaluation(listStudentsEvaluations))
            {
                listStudentsEvaluations.ToList().ForEach(studentsEvaluations.Add);
            }
            studentsTable.ItemsSource = studentsEvaluations;
        }

        private void LoadActivities()
        {
            activities = new ObservableCollection<Activity>();
            List<Activity> listActivities = new List<Activity>();
            if (schoolDataSingleton.LoadDataTeachersAndActivities(new List<Teacher>(), listActivities))
            {
                listActivities.ToList().ForEach(activities.Add);
            }
            activityPicker.ItemsSource = activities;

        }

        private void LoadStudents()
        {
            List<Student> listStudents = new List<Student>();
            students = new ObservableCollection<Student>();
            if (schoolDataSingleton.LoadDataStudents(listStudents))
            {
                listStudents.ToList().ForEach(students.Add);
            }
            studentPicker.ItemsSource = students;
        }

        private void OnCreateEvaluationClicked(object sender, EventArgs e)
        {
            var student = (Student)studentPicker.SelectedItem;
            var activity = (Activity)activityPicker.SelectedItem;
            var evaluationType = (string)evaluationTypePicker.SelectedItem;

            if (String.IsNullOrEmpty(evaluationValueEntry.Text) || student == null || activity == null || evaluationType == null)
            {
                DisplayAlert("Error", "Merci de saisir toutes les informations nécessaires", "OK");
                return;
            }

            if (student != null && activity != null && evaluationType != null)
            {
                if (evaluationType == "Cote")
                {
                    if (int.TryParse(evaluationValueEntry.Text, out var note))
                    {
                        var evaluation = new Cote(activity, note);
                        student.Add(evaluation);
                        schoolDataWriterSingleton.WriteDataEvaluation(student, evaluation);
                        LoadEvaluations();
                        resetForm();
                    }
                    else
                    {
                        DisplayAlert("Erreur", "La note doit être un nombre.", "OK");
                    }
                }
                else if (evaluationType == "Appréciation")
                {
                    var evaluation = new Appreciation(activity, evaluationValueEntry.Text.ToUpper());
                    student.Add(evaluation);
                    schoolDataWriterSingleton.WriteDataEvaluation(student, evaluation);
                    LoadEvaluations();
                    resetForm();
                }
            }
            else
            {
                DisplayAlert("Erreur", "Veuillez sélectionner un étudiant, une activité et un type d'évaluation.", "OK");
            }
        }

        private void resetForm()
        {
            studentPicker.SelectedItem = null;
            activityPicker.SelectedItem = null;
            evaluationTypePicker.SelectedItem = null;
            evaluationValueEntry.Text = null;
        }
    }
}