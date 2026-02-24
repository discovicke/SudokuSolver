using System.Diagnostics;

namespace SudokuSolver;

class Program
{
    static void Main(string[] args)
    {
        var board = new int[9][];
        for (var i = 0; i < 9; i++)
        {
            board[i] = new int[9];
        }

        board[0] = [0, 0, 1, 0, 0, 4, 9, 0, 0];
        board[1] = [0, 0, 9, 0, 0, 0, 8, 0, 0];
        board[2] = [0, 2, 0, 1, 0, 0, 0, 7, 0];
        board[3] = [8, 0, 0, 0, 0, 5, 0, 0, 0];
        board[4] = [1, 0, 0, 7, 0, 0, 3, 4, 2];
        board[5] = [0, 0, 7, 0, 9, 0, 0, 0, 0];
        board[6] = [0, 0, 0, 0, 0, 7, 0, 0, 5];
        board[7] = [9, 0, 0, 2, 0, 0, 0, 0, 0];
        board[8] = [6, 0, 0, 0, 0, 0, 0, 1, 0];

        Console.WriteLine("Starting Board:");
        PrintBoard(board);
        
        var stopwatch = Stopwatch.StartNew();
        Console.WriteLine("Starting Sudoku Solver");
        long attempts = 0;
        SolveSudoku(board, ref attempts);
        stopwatch.Stop();
        
        Console.WriteLine("\nSolved Board:");
        PrintBoard(board);
        Console.WriteLine($"Time taken: {stopwatch.ElapsedMilliseconds}ms");
        Console.WriteLine($"Total attempts: {attempts}");
    }

    private static bool SolveSudoku(int[][] board, ref long attempts)
    {
        for (var row = 0; row < 9; row++)
        {
            for (var col = 0; col < 9; col++)
            {
                if (board[row][col] == 0)
                {
                    for (var num = 1; num <= 9; num++)
                    {
                        if (IsValid(board, row, col, num))
                        {
                            attempts++;
                            board[row][col] = num;
                            Console.WriteLine($"Attempting {row},{col} with {num}");

                            if (SolveSudoku(board, ref attempts))
                            {
                                Console.WriteLine($"Success at {row},{col} with {num}");
                                return true;
                            }

                            Console.WriteLine($"Failed at {row},{col} with {num}");
                            board[row][col] = 0;
                        }
                    }

                    return false;
                }
            }
        }

        return true;
    }

    private static bool IsValid(int[][] board, int row, int col, int num)
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

    private static void PrintBoard(int[][] board)
    {
        for (var row = 0; row < 9; row++)
        {
            if (row % 3 == 0 && row != 0)
                Console.WriteLine("------+-------+------");

            for (var col = 0; col < 9; col++)
            {
                if (col % 3 == 0 && col != 0)
                    Console.Write("| ");

                Console.Write(board[row][col] == 0 ? ". " : board[row][col] + " ");
            }

            Console.WriteLine();
        }
    }
}