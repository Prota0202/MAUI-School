using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace School
{
    public partial class ActivitiesPage : ContentPage
    {
        private ObservableCollection<Activity> Activities = new ObservableCollection<Activity>();
        private ObservableCollection<Teacher> teachers = new ObservableCollection<Teacher>();

        SchoolDataSingleton schoolDataSingleton = SchoolDataSingleton.Instance;
        SchoolDataWriterSingleton schoolDataWriterSingleton = SchoolDataWriterSingleton.Instance;
        public ActivitiesPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Activities = new ObservableCollection<Activity>();
            teachers = new ObservableCollection<Teacher>();
            LoadTeachersAndActivities();
            activitiesTable.ItemsSource = Activities;
        }

        private void LoadTeachersAndActivities()
        {
            List<Activity> listActivities = new List<Activity>();
            Activities = new ObservableCollection<Activity>();
            if (schoolDataSingleton.LoadDataTeachersAndActivities(new List<Teacher>(), listActivities))
            {
                listActivities.ToList().ForEach(Activities.Add);
            }
            activitiesTable.ItemsSource = Activities;

            List<Teacher> listTeachers = new List<Teacher>();
            teachers = new ObservableCollection<Teacher>();

            if (schoolDataSingleton.LoadDataTeachers(listTeachers))
            {
                listTeachers.ToList().ForEach(teachers.Add);
            }
            teacherPicker.ItemsSource = teachers;
        }

        private void OnCreateActivityClicked(object sender, EventArgs e)
        {
            if (int.TryParse(ects.Text, out var ectsValue))
            {

                var teacher = (Teacher)teacherPicker.SelectedItem;
                if (teacher != null)
                {
                    if (!Activities.Any(t => t.Code.ToLower() == code.Text.ToLower()))
                    {
                        if (!Activities.Any(t => t.Code.ToLower() == code.Text.ToLower() && t.Teacher.Lastname == teacher.Lastname && t.Teacher.Firstname == teacher.Firstname))
                        {
                            var activity = new Activity(nom.Text, code.Text, ectsValue, teacher);
                            Activities.Add(activity);
                            schoolDataWriterSingleton.WriteDataActivities(Activities.ToList());
                            resetForm();
                        }
                        else
                        {
                            DisplayAlert("Erreur", "Cet enseignant a déjà cette activité", "OK");
                        }
                    }
                    else
                    {
                        DisplayAlert("Erreur", "Une activité de même code existe déjà.", "OK");
                    }


                }
                else
                {
                    DisplayAlert("Erreur", "Merci de séléctionner un enseignant.", "OK");
                }



                
            }
            else
            {
                DisplayAlert("Erreur", "ECTS doit être un nombre.", "OK");
            }
        }
        private void resetForm()
        {
            teacherPicker.SelectedItem = null;
            code.Text = null;
            ects.Text = null;
            nom.Text = null;
        }
    }
}