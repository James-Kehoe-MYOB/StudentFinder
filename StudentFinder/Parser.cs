using System;

namespace StudentFinder {
    public static class Parser {
        static Parser() {
            
        }

        public static Attributes.EyeColour? ParseEyes(string eyes) {
            if (Attributes.EyeColour.TryParse(eyes, true, out Attributes.EyeColour eyes_parsed)) {
                return eyes_parsed;
            }
            
            return null;
        }
        
        public static Attributes.HairColour? ParseHair(string hair) {
            if (Attributes.HairColour.TryParse(hair, true, out Attributes.HairColour hair_parsed)) {
                return hair_parsed;
            }
            return null;
        }
    }
}