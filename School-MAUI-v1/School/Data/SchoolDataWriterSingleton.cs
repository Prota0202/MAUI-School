using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace School
{
    public class SchoolDataWriterSingleton
    {
        private static SchoolDataWriterSingleton instance = null;

        private SchoolDataWriterSingleton() { }

        public static SchoolDataWriterSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SchoolDataWriterSingleton();
                }
                return instance;
            }
        }

        private void EnsureDirectoryExists(string filePath)
        {
            string directoryPath = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
        }

        public void WriteData(List<Teacher> teachers, List<Student> students)
        {
            // Ensure directory exists before writing files
            string teachersPath = Path.Combine(FileSystem.AppDataDirectory, "Teachers.txt");
            EnsureDirectoryExists(teachersPath);
            File.WriteAllLines(teachersPath, teachers.Select(t => $"{t.Firstname},{t.Lastname},{t.Salary}"));
            
            var evaluations = students.SelectMany(t => t.Evaluations);
            
            string activitiesPath = Path.Combine(FileSystem.AppDataDirectory, "Activities.txt");
            EnsureDirectoryExists(activitiesPath);
            var activities = evaluations.Select(t => t.Activity);
            File.WriteAllLines(activitiesPath, activities.Select(a => $"{a.Name},{a.Code},{a.ECTS},{a.Teacher.Firstname},{a.Teacher.Lastname}"));

            WriteDataStudents(students); // Call the method that writes student data
            
            string evaluationsPath = Path.Combine(FileSystem.AppDataDirectory, "Evaluations.txt");
            EnsureDirectoryExists(evaluationsPath);
            File.WriteAllLines(evaluationsPath, students.SelectMany(e =>
            {
                List<string> list = new List<string>();
                foreach (var eval in e.Evaluations)
                {
                    list.Add($"{e.Firstname},{e.Lastname},{eval.Activity.Code},{(eval is Cote ? "Cote" : "Appreciation")},{(eval is Cote ? ((Cote)eval).Note() : ((Appreciation)eval).GetAppreciation())}");
                }
                return list;
            }));
        }

        public void WriteDataStudents(List<Student> students)
        {
            string studentsPath = Path.Combine(FileSystem.AppDataDirectory, "Students.txt");
            EnsureDirectoryExists(studentsPath);
            File.WriteAllLines(studentsPath, students.Select(t => $"{t.Firstname},{t.Lastname}"));
        }

        public void WriteDataTeachers(List<Teacher> teachers)
        {
            string teachersPath = Path.Combine(FileSystem.AppDataDirectory, "Teachers.txt");
            EnsureDirectoryExists(teachersPath);
            File.WriteAllLines(teachersPath, teachers.Select(t => $"{t.Firstname},{t.Lastname},{t.Salary}"));
        }

        public void WriteDataActivities(List<Activity> activities)
        {
            string activitiesPath = Path.Combine(FileSystem.AppDataDirectory, "Activities.txt");
            EnsureDirectoryExists(activitiesPath);
            File.WriteAllLines(activitiesPath, activities.Select(a => $"{a.Name},{a.Code},{a.ECTS},{a.Teacher.Firstname},{a.Teacher.Lastname}"));
        }

        public void WriteDataEvaluation(Student e, Evaluation eval)
        {
            string evaluationsPath = Path.Combine(FileSystem.AppDataDirectory, "Evaluations.txt");
            EnsureDirectoryExists(evaluationsPath);
            
            string line = $"{e.Firstname},{e.Lastname},{eval.Activity.Code},{(eval is Cote ? "Cote" : "Appreciation")},{(eval is Cote ? ((Cote)eval).Note() : ((Appreciation)eval).GetAppreciation())}";
            using (StreamWriter sw = File.AppendText(evaluationsPath))
            {
                sw.WriteLine(line);
            }
        }
    }
}
