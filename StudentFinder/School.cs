using System.Collections.Generic;
using System.Linq;

namespace StudentFinder {
    public class School {
        public List<Student> Students { get; private set; }

        public School(List<Student> students) {
            this.Students = students;
        }

        public List<Student> GetMatchingStudents(Attributes.EyeColour eyes, Attributes.HairColour hair) {
            var results = Students.Where(m => m.Attributes.Eyes == eyes).Where(m => m.Attributes.Hair == hair);

            return results.ToList();
        }

        public void AddStudent(Student student) {
            if (!Students.Contains(student)) {
                Students.Add(student);
            }
        }

        public void RemoveStudent(Attributes attributes) {
            if (Students.Exists(m => m.Attributes == attributes)) {
                Students.Remove(Students.Find(m => m.Attributes == attributes));
            }
        }
    }
}