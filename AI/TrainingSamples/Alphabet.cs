using System;
using System.Collections.Generic;

namespace AI.TrainingSamples
{
    public static class Alphabet
    {
        public static readonly string Letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public static readonly int Length = 26;
        public static readonly int DataLength = 49;

        public static Dictionary<char, Character> All => new Dictionary<char, Character>
        {
            {'A', A},
            {'B', B},
            {'C', C},
            {'D', D},
            {'E', E},
            {'F', F},
            {'G', G},
            {'H', H},
            {'I', I},
            {'J', J},
            {'K', K},
            {'L', L},
            {'M', M},
            {'N', N},
            {'O', O},
            {'P', P},
            {'Q', Q},
            {'R', R},
            {'S', S},
            {'T', T},
            {'U', U},
            {'V', V},
            {'W', W},
            {'X', X},
            {'Y', Y},
            {'Z', Z}
        };

        public static Character A = new Character('A',
            ".#####." +
            "#.....#" +
            "#.....#" +
            "#######" +
            "#.....#" +
            "#.....#" +
            "#.....#");

        public static Character B = new Character('B',
            "######." +
            "#.....#" +
            "#.....#" +
            "#######" +
            "#.....#" +
            "#.....#" +
            "######.");

        public static Character C = new Character('C',
            ".######" +
            "#......" +
            "#......" +
            "#......" +
            "#......" +
            "#......" +
            ".######");

        public static Character D = new Character('D',
            "######." +
            "#.....#" +
            "#.....#" +
            "#.....#" +
            "#.....#" +
            "#.....#" +
            "######.");

        public static Character E = new Character('E',
            "#######" +
            "#......" +
            "#......" +
            "######." +
            "#......" +
            "#......" +
            "#######");

        public static Character F = new Character('F',
            "#######" +
            "#......" +
            "#......" +
            "######." +
            "#......" +
            "#......" +
            "#......");

        public static Character G = new Character('G',
            ".#####." +
            "#......" +
            "#......" +
            "#...###" +
            "#.....#" +
            "#.....#" +
            ".#####.");

        public static Character H = new Character('H',
            "#.....#" +
            "#.....#" +
            "#.....#" +
            "#######" +
            "#.....#" +
            "#.....#" +
            "#.....#");

        public static Character I = new Character('I',
            "...#..." +
            "...#..." +
            "...#..." +
            "...#..." +
            "...#..." +
            "...#..." +
            "...#...");
        public static Character J = new Character('J',
            "......#" +
            "......#" +
            "......#" +
            "......#" +
            "#.....#" +
            "#.....#" +
            ".####.");
        public static Character K = new Character('K',
            "#....#." +
            "#...#.." +
            "#..#..." +
            "###...." +
            "#..#..." +
            "#...#.." +
            "#....#.");
        public static Character L = new Character('L',
            "#......" +
            "#......" +
            "#......" +
            "#......" +
            "#......" +
            "#......" +
            "#######");
        public static Character M = new Character('M',
            "#.....#" +
            "##...##" +
            "#.#.#.#" +
            "#..#..#" +
            "#.....#" +
            "#.....#" +
            "#.....#");
        public static Character N = new Character('N',
            "#.....#" +
            "##....#" +
            "#.#...#" +
            "#..#..#" +
            "#...#.#" +
            "#....##" +
            "#.....#");
        public static Character O = new Character('O',
            ".#####." +
            "#.....#" +
            "#.....#" +
            "#.....#" +
            "#.....#" +
            "#.....#" +
            ".#####.");
        public static Character P = new Character('P',
            ".#####." +
            "#.....#" +
            "#.....#" +
            "######." +
            "#......" +
            "#......" +
            "#......");
        public static Character Q = new Character('Q',
            ".#####." +
            "#.....#" +
            "#.....#" +
            "#.....#" +
            "#..##.#" +
            "#....##" +
            ".#####.");
        public static Character R = new Character('R',
            ".#####." +
            "#.....#" +
            "#.....#" +
            "######." +
            "#..#..." +
            "#...#.." +
            "#....#.");
        public static Character S = new Character('S',
            ".#####." +
            "#.....#" +
            "#......" +
            ".#####." +
            "......#" +
            "#.....#" +
            ".#####.");
        public static Character T = new Character('T',
            "#######" +
            "...#..." +
            "...#..." +
            "...#..." +
            "...#..." +
            "...#..." +
            "...#...");
        public static Character U = new Character('U',
            "#.....#" +
            "#.....#" +
            "#.....#" +
            "#.....#" +
            "#.....#" +
            "#.....#" +
            ".#####.");
        public static Character V = new Character('V',
            "#.....#" +
            "#.....#" +
            "#.....#" +
            "#.....#" +
            ".#...#." +
            "..#.#.." +
            "...#...");
        public static Character W = new Character('W',
            "#.....#" +
            "#.....#" +
            "#.....#" +
            "#..#..#" +
            "#.#.#.#" +
            "##...##" +
            "#.....#");
        public static Character X = new Character('X',
            "#.....#" +
            ".#...#." +
            "..#.#.." +
            "...#..." +
            "..#.#.." +
            ".#...#." +
            "#.....#");
        public static Character Y = new Character('Y',
            "#.....#" +
            ".#...#." +
            "..#.#.." +
            "...#..." +
            "...#..." +
            "...#..." +
            "...#...");
        public static Character Z = new Character('Z',
            "#######" +
            ".....#." +
            "....#.." +
            "...#..." +
            "..#...." +
            ".#....." +
            "#######");
    }
}
