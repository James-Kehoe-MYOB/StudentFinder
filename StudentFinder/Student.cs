using System.Globalization;
using System.IO;
using CsvHelper;



namespace StudentFinder {
    public class Student {
        public Attributes Attributes { get; private set; }

        public Student(Attributes attributes) {
            this.Attributes = attributes;
        }

    }
}