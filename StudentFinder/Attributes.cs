namespace StudentFinder {
    public class Attributes {
        
        public string name { get; private set; }
        public string eyes { get; private set; }
        public string hair { get; private set; }
        public int age { get; private set; }

        public Attributes(string name, string eyes, string hair, int age) {
            this.name = name;
            this.eyes = eyes;
            this.hair = hair;
            this.age = age;
        }
        
    }
}