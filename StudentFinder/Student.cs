using System.Globalization;
using System.IO;
using CsvHelper;



namespace StudentFinder {
    public class Student {
        public static Attributes attributes { get; private set; }
        public string name { get; private set; }
        public string eyes { get; private set; }
        public string hair { get; private set; }
        public int age { get; private set; }
        
        public Student(Attributes attributes) {
            name = attributes.name;
            eyes = attributes.eyes;
            hair = attributes.hair;
            age = attributes.age;
            Student.attributes = attributes;
        }

    }
}