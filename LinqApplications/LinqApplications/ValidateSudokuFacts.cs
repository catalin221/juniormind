using Xunit;

namespace LinqApplications
{
    public class ValidateSudokuFacts
    {
        [Fact]
        public void CheckValidSudoku()
        {
            byte[][] testSquare =
            {
                new byte[] { 4, 3, 5, 2, 6, 9, 7, 8, 1 },
                new byte[] { 6, 8, 2, 5, 7, 1, 4, 9, 3 },
                new byte[] { 1, 9, 7, 8, 3, 4, 5, 6, 2 },
                new byte[] { 8, 2, 6, 1, 9, 5, 3, 4, 7 },
                new byte[] { 3, 7, 4, 6, 8, 2, 9, 1, 5 },
                new byte[] { 9, 5, 1, 7, 4, 3, 6, 2, 8 },
                new byte[] { 5, 1, 9, 3, 2, 6, 8, 7, 4 },
                new byte[] { 2, 4, 8, 9, 5, 7, 1, 3, 6 },
                new byte[] { 7, 6, 3, 4, 1, 8, 2, 5, 9 }
            };

            Assert.True(ValidateSudoku.CheckSudoku(testSquare));
        }

        [Fact]
        public void CheckInvalidSudokuOnFirstLine()
        {
            byte[][] testSquare =
            {
                new byte[] { 4, 3, 5, 2, 5, 9, 7, 8, 1 },
                new byte[] { 6, 8, 2, 5, 7, 1, 4, 9, 3 },
                new byte[] { 1, 9, 7, 8, 3, 4, 5, 6, 2 },
                new byte[] { 8, 2, 6, 1, 9, 5, 3, 4, 7 },
                new byte[] { 3, 7, 4, 6, 8, 2, 9, 1, 5 },
                new byte[] { 9, 5, 1, 7, 4, 3, 6, 2, 8 },
                new byte[] { 5, 1, 9, 3, 2, 6, 8, 7, 4 },
                new byte[] { 2, 4, 8, 9, 5, 7, 1, 3, 6 },
                new byte[] { 7, 6, 3, 4, 1, 8, 2, 5, 9 }
            };

            Assert.False(ValidateSudoku.CheckSudoku(testSquare));
        }

        [Fact]
        public void CheckInvalidSudokuInFirstBlock()
        {
            byte[][] testSquare =
            {
                new byte[] { 4, 3, 5, 2, 6, 9, 7, 8, 1 },
                new byte[] { 6, 3, 2, 5, 7, 1, 4, 9, 3 },
                new byte[] { 1, 9, 7, 8, 3, 4, 5, 6, 2 },
                new byte[] { 8, 2, 6, 1, 9, 5, 3, 4, 7 },
                new byte[] { 3, 7, 4, 6, 8, 2, 9, 1, 5 },
                new byte[] { 9, 5, 1, 7, 4, 3, 6, 2, 8 },
                new byte[] { 5, 1, 9, 3, 2, 6, 8, 7, 4 },
                new byte[] { 2, 4, 8, 9, 5, 7, 1, 3, 6 },
                new byte[] { 7, 6, 3, 4, 1, 8, 2, 5, 9 }
            };

            Assert.False(ValidateSudoku.CheckSudoku(testSquare));
        }

        [Fact]
        public void CheckInvalidSudokuOnFirstColumn()
        {
            byte[][] testSquare =
            {
                new byte[] { 4, 3, 5, 2, 6, 9, 7, 8, 1 },
                new byte[] { 6, 8, 2, 5, 7, 1, 4, 9, 3 },
                new byte[] { 1, 9, 7, 8, 3, 4, 5, 6, 2 },
                new byte[] { 8, 2, 6, 1, 9, 5, 3, 4, 7 },
                new byte[] { 4, 7, 4, 6, 8, 2, 9, 1, 5 },
                new byte[] { 9, 5, 1, 7, 4, 3, 6, 2, 8 },
                new byte[] { 5, 1, 9, 3, 2, 6, 8, 7, 4 },
                new byte[] { 2, 4, 8, 9, 5, 7, 1, 3, 6 },
                new byte[] { 7, 6, 3, 4, 1, 8, 2, 5, 9 }
            };

            Assert.False(ValidateSudoku.CheckSudoku(testSquare));
        }
    }
}
