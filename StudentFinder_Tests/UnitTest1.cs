using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using StudentFinder;
using Xunit;

namespace StudentFinder_Tests {
    public class UnitTest1 {
        static string data = "/Users/james.kehoe/RiderProjects/StudentFinderSolution/StudentFinder/TestData.csv";
        static CreateStudentHelper studentHelper = new CreateStudentHelper(data);
        static List<Student> students = studentHelper.ProcessStudents();
        School school = new School(students);
        
        [Fact]
        public void SchoolIsNotEmpty() {
            Assert.NotEmpty(school.students);
        }

        [Fact]
        public void SchoolHasValidStudents() {
            Assert.Equal("John", school.students[0].name);
        }

        [Fact]
        public void CanAddStudentsToSchool() {
            Attributes frank_attributes = new Attributes("Frank", "Hazel", "Blonde", 15);
            Student Frank = new Student(frank_attributes);
            school.AddStudent(Frank);
            
            Assert.Equal(Frank, school.students.Last());
        }

        [Fact]
        public void CanRemoveStudentsFromSchool() {
            int length_before = school.students.Count;
            school.RemoveStudent(school.students.First());
            
            Assert.Equal(length_before - 1, school.students.Count);
        }
    }
}