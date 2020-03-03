using System;

namespace StudentFinder {
    public static class Parser {
        static Parser() {
            
        }

        public static Attributes.EyeColour? ParseEyes(string eyes) {
            if (Enum.TryParse(eyes, true, out Attributes.EyeColour eyesParsed)) {
                return eyesParsed;
            }
            
            return null;
        }
        
        public static Attributes.HairColour? ParseHair(string hair) {
            if (Enum.TryParse(hair, true, out Attributes.HairColour hairParsed)) {
                return hairParsed;
            }
            return null;
        }
    }
}