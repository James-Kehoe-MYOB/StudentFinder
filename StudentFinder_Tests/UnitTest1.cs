using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using StudentFinder;
using Xunit;

namespace StudentFinder_Tests {
    public class UnitTest1 {
        static string _data = "../../../TestData.csv";
        static CreateStudentHelper _studentHelper = new CreateStudentHelper(_data);
        static List<Student> _students = _studentHelper.ProcessStudents();
        School _school = new School(_students);
        
        [Fact]
        public void SchoolIsNotEmpty() {
            Assert.NotEmpty(_school.Students);
        }

        [Fact]
        public void SchoolHasValidStudents() {
            Assert.IsType<Student>(_school.Students[0]);
        }

        [Fact]
        public void CanAddStudentsToSchool() {
            Attributes frankAttributes = new Attributes("Frank", Attributes.EyeColour.Hazel, Attributes.HairColour.Gray, 15);
            Student frank = new Student(frankAttributes);
            _school.AddStudent(frank);
            
            Assert.Equal(frank, _school.Students.Last());
        }

        [Fact]
        public void CanRemoveStudentsFromSchool() {
            Attributes bettyAttributes = new Attributes("Betty", Attributes.EyeColour.Brown, Attributes.HairColour.Red, 13);
            Student betty = new Student(bettyAttributes);
            _school.AddStudent(betty);
            
            _school.RemoveStudent(betty.Attributes);
            
            Assert.DoesNotContain(betty, _school.Students);
        }

        [Fact]
        public void CanParseEyeColour() {
            string eyes = "blue";
            Attributes.EyeColour? eyesParsed = Parser.ParseEyes(eyes);
            
            Assert.Equal(Attributes.EyeColour.Blue, eyesParsed);
        }
        
        [Fact]
        public void CanParseHairColour() {
            string hair = "blonde";
            Attributes.HairColour? hairParsed = Parser.ParseHair(hair);
            
            Assert.Equal(Attributes.HairColour.Blonde, hairParsed);
        }

        [Fact]
        public void CanSearchForStudent() {
            List<Student> result = new List<Student>();
            result.Add(new Student(new Attributes("Libby", Attributes.EyeColour.Brown, Attributes.HairColour.Brown, 12)));
            
            Assert.NotStrictEqual(result[0].Attributes, _school.GetMatchingStudents(Attributes.EyeColour.Brown, Attributes.HairColour.Brown)[0].Attributes);
        }
    }
}