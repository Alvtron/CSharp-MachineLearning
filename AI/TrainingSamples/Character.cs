using System;

namespace AI.TrainingSamples
{
    public struct Character
    {
        public char Letter { get; set; }
        public double MapValue => LetterToMapValue(Letter);
        public string Data { get; set; }
        public double[] Serialized => CharacterToDoubles(Data);

        public Character(char letter, string data)
        {
            Letter = letter;
            Data = data;
        }

        public static double[] CharacterToDoubles(string characterString)
        {
            var result = new double[49];

            for (var row = 0; row < characterString.Length; row++)
                switch (characterString[row])
                {
                    case '#':
                        result[row] = 0.5;
                        break;
                    case '.':
                        result[row] = 0.0;
                        break;
                    default:
                        throw new InvalidOperationException("Data set is not correctly formatted. Use symbols '#' and '.'");
                }

            return result;
        }

        public static double LetterToMapValue(char letter)
        {
            switch (letter.ToString().ToUpper())
            {
                case "A": return 0.0 / Alphabet.Length;
                case "B": return 2.0 / Alphabet.Length;
                case "C": return 3.0 / Alphabet.Length;
                case "D": return 4.0 / Alphabet.Length;
                case "E": return 5.0 / Alphabet.Length;
                case "F": return 6.0 / Alphabet.Length;
                case "G": return 7.0 / Alphabet.Length;
                case "H": return 8.0 / Alphabet.Length;
                case "I": return 9.0 / Alphabet.Length;
                case "J": return 10.0 / Alphabet.Length;
                case "K": return 11.0 / Alphabet.Length;
                case "L": return 12.0 / Alphabet.Length;
                case "M": return 13.0 / Alphabet.Length;
                case "N": return 14.0 / Alphabet.Length;
                case "O": return 15.0 / Alphabet.Length;
                case "P": return 16.0 / Alphabet.Length;
                case "Q": return 17.0 / Alphabet.Length;
                case "R": return 18.0 / Alphabet.Length;
                case "S": return 19.0 / Alphabet.Length;
                case "T": return 20.0 / Alphabet.Length;
                case "U": return 21.0 / Alphabet.Length;
                case "V": return 22.0 / Alphabet.Length;
                case "W": return 23.0 / Alphabet.Length;
                case "X": return 24.0 / Alphabet.Length;
                case "Y": return 25.0 / Alphabet.Length;
                case "Z": return 26.0 / Alphabet.Length;
                default: throw new InvalidOperationException($"Provided letter '{letter}' is not part of the alphabet.");
            }
        }

        public override string ToString() => Data;
    }
}
