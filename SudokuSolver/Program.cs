namespace SudokuSolver;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        var board = new int[9][];
    }

    static bool SolveSudoku(int[][] board)
    {
        return true;
    }

    bool isValid(int[][] board, int row, int col, int num)
    {
        // Is 'num' in current row?
        for (var x = 0; x < 9; x++)
        {
            if (board[row][x] == num)
            {
                return false;
            }
        }

        // Is 'num' in current column?
        for (var x = 0; x < 9; x++)
        {
            if (board[x][col] == num)
            {
                return false;
            }
        }

        // Is 'num' in current 3x3 box?
        int startRow = row - row % 3, startCol = col - col % 3;
        for (var i = 0; i < 3; i++)
        {
            for (var j = 0; j < 3; j++)
            {
                if (board[i + startRow][j + startCol] == num)
                    return false;
            }
        }

        return true;
    }
}