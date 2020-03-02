using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;

namespace StudentFinder {
    public class CreateStudentHelper {
        private string _path;

        public CreateStudentHelper(string path) {
            _path = path;
        }

        public List<Student> ProcessStudents() {
            List<Student> students = new List<Student>();
            List<Attributes> student_attributes = new List<Attributes>();
            using (var reader = new StreamReader(_path))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {    
                student_attributes = csv.GetRecords<Attributes>().ToList();
            }

            foreach (var attribute_set in student_attributes) {
                students.Add(new Student(attribute_set));
            }

            return students;
        }

    }
}