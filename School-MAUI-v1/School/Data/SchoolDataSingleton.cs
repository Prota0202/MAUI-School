using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace School
{
    public class SchoolDataSingleton
    {
        private const string teachersFile = "Teachers.txt";
        private const string activitiesFile = "Activities.txt";
        private const string studentsFile = "Students.txt";
        private const string evaluationsFile = "Evaluations.txt";

        private static SchoolDataSingleton instance = null;

        private SchoolDataSingleton() { }

        public static SchoolDataSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SchoolDataSingleton();
                }
                return instance;
            }
        }

        public bool LoadDataStudents(List<Student> students)
        {

            if (!File.Exists(System.IO.Path.Combine(FileSystem.AppDataDirectory, studentsFile)))
            {
                return false;
            }

            // charger students
            foreach (var line in File.ReadLines(System.IO.Path.Combine(FileSystem.AppDataDirectory, studentsFile)))
            {
                var parts = line.Split(',');
                students.Add(new Student(parts[0], parts[1]));
            }
            return true;

        }

        public bool LoadDataTeachers(List<Teacher> teachers)
        {

            if (!File.Exists(System.IO.Path.Combine(FileSystem.AppDataDirectory, teachersFile))
                )
            {
                return false;
            }

            // charger teachers
            foreach (var line in File.ReadLines(System.IO.Path.Combine(FileSystem.AppDataDirectory, teachersFile)))
            {
                var parts = line.Split(',');
                teachers.Add(new Teacher(parts[0], parts[1], int.Parse(parts[2])));
            }
            return true;

        }
        public bool LoadDataTeachersAndActivities(List<Teacher> teachers, List<Activity> activities)
        {

            if (!File.Exists(System.IO.Path.Combine(FileSystem.AppDataDirectory, teachersFile))
            || !File.Exists(System.IO.Path.Combine(FileSystem.AppDataDirectory, activitiesFile))
                )
            {
                return false;
            }
            // charger teachers
            foreach (var line in File.ReadLines(System.IO.Path.Combine(FileSystem.AppDataDirectory, teachersFile)))
            {
                var parts = line.Split(',');
                teachers.Add(new Teacher(parts[0], parts[1], int.Parse(parts[2])));
            }

            // charger activities
            foreach (var line in File.ReadLines(System.IO.Path.Combine(FileSystem.AppDataDirectory, activitiesFile)))
            {
                var parts = line.Split(',');
                var teacher = teachers.First(t => t.Firstname == parts[3] && t.Lastname == parts[4]);
                activities.Add(new Activity(parts[0], parts[1], int.Parse(parts[2]), teacher));
            }
            return true;

        }

        public bool LoadDataEvaluation(List<Student> students)
        {
            List<Teacher> teachers = new List<Teacher>();
            List<Activity> activities = new List<Activity>();

            if (!File.Exists(System.IO.Path.Combine(FileSystem.AppDataDirectory, teachersFile))
            || !File.Exists(System.IO.Path.Combine(FileSystem.AppDataDirectory, activitiesFile))
            || !File.Exists(System.IO.Path.Combine(FileSystem.AppDataDirectory, studentsFile))
            || !File.Exists(System.IO.Path.Combine(FileSystem.AppDataDirectory, evaluationsFile))) {
                return false;
            }


            // charger teachers
            foreach (var line in File.ReadLines(System.IO.Path.Combine(FileSystem.AppDataDirectory, teachersFile)))
            {
                var parts = line.Split(',');
                teachers.Add(new Teacher(parts[0], parts[1], int.Parse(parts[2])));
            }

            // charger activities
            foreach (var line in File.ReadLines(System.IO.Path.Combine(FileSystem.AppDataDirectory, activitiesFile)))
            {
                var parts = line.Split(',');
                var teacher = teachers.First(t => t.Firstname == parts[3] && t.Lastname == parts[4]);
                activities.Add(new Activity(parts[0], parts[1], int.Parse(parts[2]), teacher));
            }

            // charger students
            foreach (var line in File.ReadLines(System.IO.Path.Combine(FileSystem.AppDataDirectory, studentsFile)))
            {
                var parts = line.Split(',');
                students.Add(new Student(parts[0], parts[1]));
            }

            // charger evaluations
            foreach (var line in File.ReadLines(System.IO.Path.Combine(FileSystem.AppDataDirectory, evaluationsFile)))
            {
                var parts = line.Split(',');
                var student = students.First(s => s.Firstname == parts[0] && s.Lastname == parts[1]);
                var activity = activities.First(a => a.Code == parts[2]);
                if (parts[3] == "Cote")
                {
                    Cote cote = new Cote(activity, int.Parse(parts[4]));
                    
                    student.Add(cote);
                }
                else if (parts[3] == "Appreciation")
                {
                    Appreciation appreciation = new Appreciation(activity, parts[4]);
                    
                    student.Add(appreciation);
                }
            }
            return true;

        }
        
        public bool LoadData(List<Teacher> teachers, List<Activity> activities, List<Student> students)
        {

            if (!File.Exists(System.IO.Path.Combine(FileSystem.AppDataDirectory, teachersFile))
            || !File.Exists(System.IO.Path.Combine(FileSystem.AppDataDirectory, activitiesFile))
            || !File.Exists(System.IO.Path.Combine(FileSystem.AppDataDirectory, studentsFile))
            || !File.Exists(System.IO.Path.Combine(FileSystem.AppDataDirectory, evaluationsFile))) {
                return false;
            }


            // charger teachers
            foreach (var line in File.ReadLines(System.IO.Path.Combine(FileSystem.AppDataDirectory, teachersFile)))
            {
                var parts = line.Split(',');
                teachers.Add(new Teacher(parts[0], parts[1], int.Parse(parts[2])));
            }

            // charger activities
            foreach (var line in File.ReadLines(System.IO.Path.Combine(FileSystem.AppDataDirectory, activitiesFile)))
            {
                var parts = line.Split(',');
                var teacher = teachers.First(t => t.Firstname == parts[3] && t.Lastname == parts[4]);
                activities.Add(new Activity(parts[0], parts[1], int.Parse(parts[2]), teacher));
            }

            // charger students
            foreach (var line in File.ReadLines(System.IO.Path.Combine(FileSystem.AppDataDirectory, studentsFile)))
            {
                var parts = line.Split(',');
                students.Add(new Student(parts[0], parts[1]));
            }

            // charger evaluations
            foreach (var line in File.ReadLines(System.IO.Path.Combine(FileSystem.AppDataDirectory, evaluationsFile)))
            {
                var parts = line.Split(',');
                var student = students.First(s => s.Firstname == parts[0] && s.Lastname == parts[1]);
                var activity = activities.First(a => a.Code == parts[2]);
                if (parts[3] == "Cote")
                {
                    student.Add(new Cote(activity, int.Parse(parts[4])));
                }
                else if (parts[3] == "Appreciation")
                {
                    student.Add(new Appreciation(activity, parts[4]));
                }
            }
            return true;

        }

        public void GenerateBulletins(List<Student> students)
        {
            foreach (var student in students)
            {
                File.WriteAllText(System.IO.Path.Combine(FileSystem.AppDataDirectory, $"{student.Firstname}_{student.Lastname}_Bulletin.txt"), student.Bulletin);
            }
        }
    }
}
