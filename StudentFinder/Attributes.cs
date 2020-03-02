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
        
        public string Name { get; private set; }
        public EyeColour Eyes { get; private set; }
        public HairColour Hair { get; private set; }
        public int Age { get; private set; }

        public Attributes(string name, EyeColour eyes, HairColour hair, int age) {
            this.Name = name;
            this.Eyes = eyes;
            this.Hair = hair;
            this.Age = age;
        }
        
    }
}