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
            Assert.IsType<Student>(school.students[0]);
        }

        [Fact]
        public void CanAddStudentsToSchool() {
            Attributes frank_attributes = new Attributes("Frank", Attributes.EyeColour.Hazel, Attributes.HairColour.Gray, 15);
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

        [Fact]
        public void CanParseEyeColour() {
            string eyes = "blue";
            Attributes.EyeColour? eyes_parsed = Parser.ParseEyes(eyes);
            
            Assert.Equal(Attributes.EyeColour.Blue, eyes_parsed);
        }
        
        [Fact]
        public void CanParseHairColour() {
            string hair = "blonde";
            Attributes.HairColour? hair_parsed = Parser.ParseHair(hair);
            
            Assert.Equal(Attributes.HairColour.Blonde, hair_parsed);
        }

        [Fact]
        public void CanSearchForStudent() {
            List<Student> result = new List<Student>();
            result.Add(new Student(new Attributes("Libby", Attributes.EyeColour.Brown, Attributes.HairColour.Brown, 12)));
            
            Assert.NotStrictEqual(result[0].attributes, school.getMatchingStudents(Attributes.EyeColour.Brown, Attributes.HairColour.Brown)[0].attributes);
        }
    }
}