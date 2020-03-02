using System.Globalization;
using System.IO;
using CsvHelper;



namespace StudentFinder {
    public class Student {
        public Attributes attributes { get; private set; }

        public Student(Attributes attributes) {
            this.attributes = attributes;
        }

    }
}