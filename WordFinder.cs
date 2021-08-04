using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WordFinder.Exceptions;
using WordFinder.Interfaces;

namespace WordFinder
{
    public class WordFinder : IWordFinder
    {
        private IEnumerable<string> _matrix;
        private Dictionary<string, int> wordsThatHaveBeenFound = new Dictionary<string, int>();

        public WordFinder(IEnumerable<string> matrix)
        {
            ValidateMatrix(matrix);
            _matrix = matrix;
        }

        public IEnumerable<string> Find(IEnumerable<string> wordstream)
        {
            var leftToRightWords = GetLeftToRightWords();
            var topToBottomWords = GetTopToBottomWords();

            foreach (var word in wordstream)
            {
                if (wordsThatHaveBeenFound.ContainsKey(word))
                {
                    wordsThatHaveBeenFound[word] += 1;
                }
                else if (leftToRightWords.Contains(word) || topToBottomWords.Contains(word)) {
                    wordsThatHaveBeenFound.Add(word, 1);
                }
            }

            return GetTop10FoundWords();
        }

        private void ValidateMatrix(IEnumerable<string> matrix)
        {
            if (matrix.Count() > 64)
            {
                throw new MatrixSizeExceededException();
            }

            int wordLength = -1;
            foreach (string word in matrix)
            {
                if (wordLength == -1)
                {
                    wordLength = word.Length;
                }

                if (word.Length > 64)
                {
                    throw new MatrixSizeExceededException();
                }

                if (wordLength != word.Length)
                {
                    throw new MatrixDifferentWordSizeException();
                }
            }
        }

        private string GetLeftToRightWords()
        {
            return string.Join(" ", _matrix);
        }

        private string GetTopToBottomWords()
        {
            var topToBottomSB = new StringBuilder();
            var matrixLength = _matrix.First().Length;

            for (int i = 0; i < matrixLength; i++)
            {
                for (int j = 0; j < matrixLength; j++)
                {
                    topToBottomSB.Append(_matrix.ElementAt(j)[i]);

                    if (j == matrixLength - 1)
                    {
                        topToBottomSB.Append(" ");
                    }
                }
            }

            return topToBottomSB.ToString();
        }

        private IEnumerable<string> GetTop10FoundWords()
        {
            return wordsThatHaveBeenFound.OrderByDescending(kv => kv.Value).Take(10).Select(kv => kv.Key);
        }
    }
}
