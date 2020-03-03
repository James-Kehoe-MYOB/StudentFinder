using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;

namespace StudentFinder {
    public class CreateStudentHelper {
        private readonly string _path;

        public CreateStudentHelper(string path) {
            _path = path;
        }

        public List<Student> ProcessStudents() {
            List<Attributes> studentAttributes;
            using (var reader = new StreamReader(_path)) {
                using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
                studentAttributes = csv.GetRecords<Attributes>().ToList();
            }

            return studentAttributes.Select(attributeSet => new Student(attributeSet)).ToList();
        }

    }
}