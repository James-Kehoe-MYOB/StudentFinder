namespace StudentFinder {
    public class Attributes {
        
        public enum EyeColour {
            Blue,
            Brown,
            Hazel,
            Green,
            Gray,
            Amber
        }

        public enum HairColour {
            Blonde,
            Black,
            Red,
            Brown,
            Gray
        }
        
        public string name { get; private set; }
        public EyeColour eyes { get; internal set; }
        public HairColour hair { get; private set; }
        public int age { get; private set; }

        public Attributes(string name, EyeColour eyes, HairColour hair, int age) {
            this.name = name;
            this.eyes = eyes;
            this.hair = hair;
            this.age = age;
        }
        
    }
}