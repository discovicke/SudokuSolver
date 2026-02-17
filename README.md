# SudokuSolver
![C#](https://img.shields.io/badge/C%23-239120?style=flat&logo=csharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET_10-512BD4?style=flat&logo=dotnet&logoColor=white)

A fast Sudoku solver written in C# that uses recursive backtracking to crack any valid Sudoku puzzle.

## How it works

The solver scans the board for empty cells and tries placing digits 1–9, validating each attempt against the standard Sudoku rules — no duplicates in the same row, column, or 3×3 box. If a placement leads to a dead end, it backtracks and tries the next candidate.

## Running it

```bash
dotnet run
```

The board is hardcoded in `Program.cs`. Swap out the values in the `board[x]` arrays to solve a different puzzle. Use `0` for empty cells.

## Output

```
Starting Board:
. . 1 | . . 4 | 9 . .
. . 9 | . . . | 8 . .
. 2 . | 1 . . | . 7 .
------+-------+------
...

Solved Board:
...
Time taken: 3ms
```

## Requirements

.NET 8+
