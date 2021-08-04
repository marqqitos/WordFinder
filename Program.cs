using System;
using System.Collections.Generic;

namespace WordFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            var wordstreamExample = new string[] { "chill", "wind", "snow", "cold" };
            var matrixExample = new string[] { "abcdc", "fgwio", "chill", "pqnsd", "uvdxy" };

            var hugeWordstream = GetWordstream(100000);
            var m64 = GetMatrix(32);

            var result = new WordFinder(m64).Find(hugeWordstream);
            Console.WriteLine(string.Join(", ", result));
        }

        private static List<string> GetWordstream(int size)
        {
            return GetListOfWords(size, 5, 11);
        }

        private static List<string> GetMatrix(int size)
        {
            return GetListOfWords(size, size, size);
        }

        private static List<string> GetListOfWords(int size, int startRandomSize, int endRandomSize)
        {
            var list = new List<string>();
            Random random = new Random();
            for (int i = 0; i < size; i++)
            {
                list.Add(WordGenerator(random.Next(startRandomSize, endRandomSize)));
            }

            return list;
        }

        private static string WordGenerator(int requestedLength)
        {
            Random rnd = new Random();
            string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "n", "p", "q", "r", "s", "t", "v", "w", "x", "y", "z" };
            string[] vowels = { "a", "e", "i", "o", "u" };

            string word = "";

            if (requestedLength == 1)
            {
                word = GetRandomLetter(rnd, vowels);
            }
            else
            {
                for (int i = 0; i < requestedLength; i += 2)
                {
                    word += GetRandomLetter(rnd, consonants) + GetRandomLetter(rnd, vowels);
                }
            }

            return word;
        }

        private static string GetRandomLetter(Random rnd, string[] letters)
        {
            return letters[rnd.Next(0, letters.Length - 1)];
        }
    }
}
