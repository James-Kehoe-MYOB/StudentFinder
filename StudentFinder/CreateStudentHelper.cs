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
            List<Attributes> studentAttributes = new List<Attributes>();
            using (var reader = new StreamReader(_path))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {    
                studentAttributes = csv.GetRecords<Attributes>().ToList();
            }

            foreach (var attributeSet in studentAttributes) {
                students.Add(new Student(attributeSet));
            }

            return students;
        }

    }
}