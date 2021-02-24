using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqApplications
{
    public static class ValidateSudoku
    {
        public static bool CheckSudoku(byte[][] square)
        {
            ThrowNullException(square);
            int count = square.Length;
            int squareSize = (int)Math.Sqrt(count);
            var digits = Enumerable.Range(0, count);
            var lines = square.Select(x => x);
            var columns = digits.Select(index => square.Select(column => column[index]));
            var squares = digits.Select(index => GetInnerBlock(square, index / squareSize * squareSize, index % squareSize * squareSize, squareSize));
            var sudoku = lines.Concat(columns).Concat(squares);
            return sudoku.All(y => CheckByteLine(y, count));
        }

        private static bool CheckByteLine(IEnumerable<byte> line, int count)
        {
            bool elementsIntegrity = line.Select(x => Convert.ToInt32(x)).All(x => Enumerable.Range(1, count).Contains(x));
            return elementsIntegrity && line.Count() == line.Distinct().Count();
        }

        private static IEnumerable<byte> GetInnerBlock(byte[][] square, int lineIndex, int columnIndex, int count)
        {
            return Enumerable.Range(lineIndex, count).SelectMany(x => Enumerable.Range(columnIndex, count).Select(y => square[x][y]));
        }

        private static void ThrowNullException(byte[][] source)
        {
            if (source != null)
            {
                return;
            }

            throw new ArgumentNullException(nameof(source));
        }
    }
}