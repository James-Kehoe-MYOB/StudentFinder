using System;
using System.Collections.Generic;

namespace StudentFinder {
    class Program {
        static void Main(string[] args) {

            var eyes = GetEyes();
            var hair = GetHair();
            GetResults(eyes, hair);

        }

//-----------------------------

        private static School InitSchool() {
            var data = "../../../TestData.csv";
            CreateStudentHelper studentHelper = new CreateStudentHelper(data);
            List<Student> students = studentHelper.ProcessStudents();
            School school = new School(students);
            return school;
        }
        
//-----------------------------

        private static Attributes.EyeColour GetEyes() {
            Console.Write("Enter an Eye Colour: ");
            var eyes = Parser.ParseEyes(Console.ReadLine());
            while (!eyes.HasValue) {
                Console.WriteLine("Could Not Find Matching Eye Colour");
                Console.Write("Enter an Eye Colour: ");
                eyes = Parser.ParseEyes(Console.ReadLine());
            }

            return eyes.GetValueOrDefault();
        }
        
//-----------------------------
        
        private static Attributes.HairColour GetHair() {
            Console.Write("Enter a Hair Colour: ");
            var hair = Parser.ParseHair(Console.ReadLine());
            while (!hair.HasValue) {
                Console.WriteLine("Could Not Find Matching Hair Colour");
                Console.Write("Enter a Hair Colour: ");
                hair = Parser.ParseHair(Console.ReadLine());
            }

            return hair.GetValueOrDefault();
        }
        
//-----------------------------

        private static void GetResults(Attributes.EyeColour eyes, Attributes.HairColour hair) {
            var school = InitSchool();
            var results = school.GetMatchingStudents(eyes, hair);
            while (results.Count > 0) {
                Console.WriteLine($"Found {results.Count} student/s with {eyes.ToString().ToLower()} eyes and {hair.ToString().ToLower()} hair: ");
                foreach (var result in results) {
                    Console.WriteLine($"{result.Attributes.Name}, {result.Attributes.Age}");
                }
                Console.WriteLine($"Do you want to expel {results[0].Attributes.Name}?");
                var answer = Console.ReadLine();
                Console.WriteLine($"{results[0].Attributes.Name} has been expelled.\n");
                school.RemoveStudent(results[0].Attributes);
                results.Remove(results[0]);
            } 
            
            Console.WriteLine($"No results found for children with {eyes} eyes and {hair} hair");
            
        }
        
    }
}