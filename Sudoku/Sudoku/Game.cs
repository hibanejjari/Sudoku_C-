using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{

    public class Game
    {
        private Grid grid = new Grid();
        private bool[,] editableCells = new bool[9, 9];
        private Stack<Move> moves = new Stack<Move>();
        private Player player = new Player("Anonymous");
        private Stack<Move> movesHistory = new Stack<Move>();
        public void GeneratePuzzle(int difficulty)
        {
            
            ClearCellsBasedOnDifficulty(difficulty);
        }

        private void ClearCellsBasedOnDifficulty(int difficulty)
            {
                int cellsToClear = difficulty switch
                {
                    1 => 20, // Easy
                    2 => 30, // Medium
                    3 => 40, // Hard
                    4 => 50, // Very Hard
                    _ => 20,
                };

                // Placeholder for generating a fully solved grid before clearing cells
                grid.SolveGrid(); 

                Random random = new Random();
                for (int i = 0; i < cellsToClear; i++)
                {
                    int row, col;
                    do
                    {
                        row = random.Next(9);
                        col = random.Next(9);
                    } while (grid.GetCell(row, col) == 0); // Avoid already cleared cells

                    grid.SetCell(row, col, 0); // Clear the cell
                    editableCells[row, col] = false; // This cell becomes non-editable
                }
            }

            public bool CanSetValue(int row, int col)
            {
                return editableCells[row, col];
            }
            public void SetCellValue(int row, int col, int value)
        {
            int oldValue = grid.GetCell(row, col); // Get the current value before changing it
            if (value != oldValue) // Only record a move if the value is actually changing
            {
                grid.SetCell(row, col, value); // Update the cell's value
                moves.Push(new Move(row, col, oldValue)); // Record the move for undo functionality
            }
        }
       
        public bool UndoLastMove()
        {
            if (moves.Count > 0)
            {
                Move lastMove = moves.Pop();
                grid.SetCell(lastMove.Row, lastMove.Col, lastMove.OldValue); // Revert to the old value
                return true; // Move was undone successfully
            }
            return false; // No move to undo
        }




        public int GetCellValue(int row, int col)
        {
            return grid.GetCell(row, col);
        }

        // Check if the current grid is a valid Sudoku solution
        public bool IsValidSudoku()
        {
            // Check all rows and columns
            for (int i = 0; i < 9; i++)
            {
                if (!IsRowValid(i) || !IsColumnValid(i))
                {
                    return false;
                }
            }

            // Check all 3x3 subgrids
            for (int row = 0; row < 9; row += 3)
            {
                for (int col = 0; col < 9; col += 3)
                {
                    if (!IsSubgridValid(row, col))
                    {
                        return false;
                    }
                }
            }

            return true; // Passed all checks
        }

        private bool IsRowValid(int row)
        {
            bool[] seen = new bool[9];
            for (int col = 0; col < 9; col++)
            {
                int value = GetCellValue(row, col);
                if (value != 0)
                {
                    if (seen[value - 1])
                        return false;
                    seen[value - 1] = true;
                }
            }
            return true;
        }

        public bool IsValidMove(int row, int col, int value)
        {
            // Delegate the call to the Grid instance's IsValidMove
            return grid.IsValidMove(row, col, value);
        }
    
    private bool IsColumnValid(int col)
        {
            bool[] seen = new bool[9];
            for (int row = 0; row < 9; row++)
            {
                int value = GetCellValue(row, col);
                if (value != 0)
                {
                    if (seen[value - 1])
                        return false;
                    seen[value - 1] = true;
                }
            }
            return true;
        }

        private bool IsSubgridValid(int startRow, int startCol)
        {
            bool[] seen = new bool[9];
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    int value = GetCellValue(row + startRow, col + startCol);
                    if (value != 0)
                    {
                        if (seen[value - 1])
                            return false;
                        seen[value - 1] = true;
                    }
                }
            }
            return true;
        }
        public bool IsFullySolved()
        {
            // Check for any empty cells first
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    if (GetCellValue(row, col) == 0)
                    {
                        return false; // Found an empty cell, not fully solved
                    }
                }
            }

            // If no empty cells, check if the current configuration is valid
            return IsValidSudoku();
        }

    }
}