using System.Collections.Generic;

namespace StudentFinder {
    public class School {
        public List<Student> students { get; private set; }

        public School(List<Student> students) {
            this.students = students;
        }

        public List<Student> getMatchingStudents() {
            List<Student> results = new List<Student>();

            return results;
        }

        public void AddStudent(Student student) {
            if (!students.Contains(student)) {
                students.Add(student);
            }
        }

        public void RemoveStudent(Student student) {
            //Check if student already in school
            if (students.Contains(student)) {
                students.Remove(student);
            }
            //if so, remove
        }
    }
}