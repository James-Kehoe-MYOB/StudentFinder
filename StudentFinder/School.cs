using System.Collections.Generic;
using System.Linq;

namespace StudentFinder {
    public class School {
        public List<Student> students { get; private set; }

        public School(List<Student> students) {
            this.students = students;
        }

        public List<Student> getMatchingStudents(Attributes.EyeColour eyes, Attributes.HairColour hair) {
            IEnumerable<Student> results = students.Where(m => m.attributes.eyes == eyes).Where(m => m.attributes.hair == hair);

            return results.ToList();
        }

        public void AddStudent(Student student) {
            if (!students.Contains(student)) {
                students.Add(student);
            }
        }

        public void RemoveStudent(Student student) {
            if (students.Contains(student)) {
                students.Remove(student);
            }
        }
    }
}