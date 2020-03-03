using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using StudentFinder;
using Xunit;

namespace StudentFinder_Tests {
    public class UnitTest1 {
        private const string Data = "../../../TestData.csv";
        private static readonly CreateStudentHelper StudentHelper = new CreateStudentHelper(Data);
        private static readonly List<Student> Students = StudentHelper.ProcessStudents();
        private readonly School _school = new School(Students);
        
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
            var frankAttributes = new Attributes("Frank", Attributes.EyeColour.Hazel, Attributes.HairColour.Gray, 15);
            var frank = new Student(frankAttributes);
            _school.AddStudent(frank);
            
            Assert.Equal(frank, _school.Students.Last());
        }

        [Fact]
        public void CanRemoveStudentsFromSchool() {
            var bettyAttributes = new Attributes("Betty", Attributes.EyeColour.Brown, Attributes.HairColour.Red, 13);
            var betty = new Student(bettyAttributes);
            _school.AddStudent(betty);
            
            _school.RemoveStudent(betty.Attributes);
            
            Assert.DoesNotContain(betty, _school.Students);
        }

        [Fact]
        public void CanParseEyeColour() {
            const string eyes = "blue";
            var eyesParsed = Parser.ParseEyes(eyes);
            
            Assert.Equal(Attributes.EyeColour.Blue, eyesParsed);
        }
        
        [Fact]
        public void CanParseHairColour() {
            const string hair = "blonde";
            var hairParsed = Parser.ParseHair(hair);
            
            Assert.Equal(Attributes.HairColour.Blonde, hairParsed);
        }

        [Fact]
        public void CanSearchForStudent() {
            var result = new List<Student> {
                new Student(new Attributes("Libby", Attributes.EyeColour.Brown, Attributes.HairColour.Brown, 12))
            };

            Assert.NotStrictEqual(result[0].Attributes, _school.GetMatchingStudents(Attributes.EyeColour.Brown, Attributes.HairColour.Brown)[0].Attributes);
        }
    }
}